namespace LMS.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;

        public DirectorController(IDbService db) => _db = db;

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<DirectorDTO> directors = await _db.GetAsync<Director, DirectorDTO>();
                return Results.Ok(directors);
            }
            catch { }

            return Results.NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Film>();
                var director = await _db.SingleAsync<Director, DirectorDTO>(d => d.Id.Equals(id));
                if (director is null) return Results.NotFound();

                return Results.Ok(JsonUtility.HandleLoops(director));
            }
            catch { }

            return Results.NotFound();
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Director>(director), director);
            }
            catch { }

            return Results.BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                if (!id.Equals(dto.Id)) return Results.BadRequest();

                var success = await _db.AnyAsync<Director>(c => c.Id.Equals(id));

                if (!success) return Results.NotFound();

                _db.Update<Director, DirectorEditDTO>(dto.Id, dto);

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success = await _db.DeleteAsync<Director>(id);

                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }
    }
}
