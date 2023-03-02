﻿namespace LMS.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmGenreController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmGenreController(IDbService db) => _db = db;

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<FilmGenreDTO>? filmGenre = await _db.GetAsync<FilmGenre, FilmGenreDTO>();

                return Results.Ok(filmGenre);
            }
            catch { }

            return Results.NotFound();
        }

        [HttpPost]
        public async Task<IResult> Post(FilmGenreCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                var filmgenre = await _db.AddAsync<FilmGenre, FilmGenreCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Ok();
            }
            catch { }

            return Results.NotFound();
        }

        [HttpDelete]
        public async Task<IResult> Delete(FilmGenreCreateDTO dto)
        {
            try
            {
                var exist = _db.Delete<FilmGenre, FilmGenreCreateDTO>(dto);

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
