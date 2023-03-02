var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices()
{
    builder.Services.AddDbContext<LMSContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("LMSConnection")));

    builder.Services.AddScoped<IDbService, DbService>();

    builder.Services.AddCors(policy =>
    {
        policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Film, FilmDTO>().ReverseMap();
        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
        cfg.CreateMap<SimilarFilms, SimilarFilmsDTO>().ReverseMap();

        cfg.CreateMap<FilmCreateDTO, Film>()
        .ForMember(d => d.Director, s => s.Ignore())
        .ForMember(d => d.Genres, s => s.Ignore())
        .ForMember(d => d.SimilarFilms, s => s.Ignore());

        cfg.CreateMap<DirectorCreateDTO, Director>().ReverseMap();
        cfg.CreateMap<DirectorEditDTO, Director>().ReverseMap();
        cfg.CreateMap<GenreCreateDTO, Genre>().ReverseMap();
        cfg.CreateMap<FilmGenreCreateDTO, FilmGenre>().ReverseMap();
        cfg.CreateMap<SimilarFilmsCreateDTO, SimilarFilms>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
