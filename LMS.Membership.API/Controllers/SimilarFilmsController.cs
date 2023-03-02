namespace LMS.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmsController : ControllerBase
    {
        private readonly IDbService _db;

        public SimilarFilmsController(IDbService db) => _db = db;

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<SimilarFilmsDTO>? similar = await _db.GetAsync<SimilarFilms, SimilarFilmsDTO>();

                return Results.Ok(similar);
            }
            catch { }

            return Results.NotFound();
        }

        [HttpPost]
        public async Task<IResult> Post(SimilarFilmsCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                var filmgenre = await _db.AddAsync<SimilarFilms, SimilarFilmsCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Ok();
            }
            catch { }

            return Results.NotFound();
        }

        [HttpDelete]
        public async Task<IResult> Delete(SimilarFilmsCreateDTO dto)
        {
            try
            {
                var exist = _db.Delete<SimilarFilms, SimilarFilmsCreateDTO>(dto);

                if (!exist) return Results.NotFound();

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }
    }
}
