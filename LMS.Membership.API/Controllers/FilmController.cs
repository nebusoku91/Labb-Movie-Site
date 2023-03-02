namespace LMS.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmController(IDbService db) => _db = db;

        [HttpGet]
        public async Task<IResult> Get(bool freeOnly)
        {
            try
            {
                _db.Include<Director>();
                _db.Include<FilmGenre>();
                _db.Include<SimilarFilms>();

                List<FilmDTO>? films = freeOnly ?
                    await _db.GetAsync<Film, FilmDTO>(c => c.Free.Equals(freeOnly)) :
                    await _db.GetAsync<Film, FilmDTO>();

                return Results.Ok(JsonUtility.HandleLoops(films));
            }
            catch
            {
                return Results.NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Director>();
                _db.Include<FilmGenre>();
                _db.Include<SimilarFilms>();

                var film = await _db.SingleAsync<Film, FilmDTO>(c => c.Id.Equals(id));

                return Results.Ok(JsonUtility.HandleLoops(film));
            }
            catch
            {
                return Results.NotFound();
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Ok();
            }
            catch
            {
            }
            return Results.BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                if (!id.Equals(dto.Id)) return Results.BadRequest();

                var exist = await _db.AnyAsync<Director>(d => d.Id.Equals(dto.DirectorId));
                if (!exist) return Results.NotFound();

                exist = await _db.AnyAsync<Film>(f => f.Id.Equals(id));
                if (!exist) return Results.NotFound();

                _db.Update<Film, FilmEditDTO>(dto.Id, dto);

                var success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {
            }

            return Results.BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success = await _db.DeleteAsync<Film>(id);
                if (!success) return Results.NotFound();
                success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {
            }

            return Results.BadRequest();
        }
    }
}
