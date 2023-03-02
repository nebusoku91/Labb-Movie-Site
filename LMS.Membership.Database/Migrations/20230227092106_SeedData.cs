using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The Wachowskis" },
                    { 2, "Ridley Scott" },
                    { 3, "Guillermo del Toro" },
                    { 4, "Damien Chazelle" },
                    { 5, "Christopher Nolan" },
                    { 6, "Quentin Tarantino" },
                    { 7, "Robert Eggers" },
                    { 8, "Tommy Wiseau" },
                    { 9, "Chris Williams" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Science Fiction" },
                    { 3, "Drama" },
                    { 4, "Adventure" },
                    { 5, "Horror" },
                    { 6, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DirectorId", "FilmUrl", "Free", "Released", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum", 1, "https://www.youtube.com/watch?v=vKQi3bBA1y8", true, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 2, "Lorem ipsum", 2, "https://www.youtube.com/watch?v=P5ieIbInFpg", false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator" },
                    { 3, "Lorem ipsum", 3, "https://www.youtube.com/watch?v=Od2NW1sfRdA", false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guillermo del Toro's Pinocchio" },
                    { 4, "Lorem ipsum", 4, "https://www.youtube.com/watch?v=7d_jQycdQGo", true, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiplash" },
                    { 5, "Lorem ipsum", 2, "https://www.youtube.com/watch?v=LjLamj-b0I8", false, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien" },
                    { 6, "Lorem ipsum", 5, "https://www.youtube.com/watch?v=4CV41hoyS8A", false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Memento" },
                    { 7, "Lorem ipsum", 6, "https://www.youtube.com/watch?v=0fUCuvNlOCg", false, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Django Unchained" },
                    { 8, "Lorem ipsum", 6, "https://www.youtube.com/watch?v=s7EdQ4FqbhY", true, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { 9, "Lorem ipsum", 7, "https://www.youtube.com/watch?v=iQXmlf3Sefg", false, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witch" },
                    { 10, "Lorem ipsum", 8, "https://www.youtube.com/watch?v=tfMTHIwTUXA", false, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Room" },
                    { 11, "Lorem ipsum", 9, "https://www.youtube.com/watch?v=tfMTHIwTUXA", false, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sea Beast" }
                });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 3 },
                    { 5, 2 },
                    { 5, 5 },
                    { 6, 3 },
                    { 6, 6 },
                    { 7, 1 },
                    { 7, 3 },
                    { 7, 5 },
                    { 8, 1 },
                    { 8, 3 },
                    { 9, 5 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 6 },
                    { 11, 4 }
                });

            migrationBuilder.InsertData(
                table: "SimilarFilms",
                columns: new[] { "FilmId", "SimilarFilmId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 5 },
                    { 2, 7 },
                    { 3, 11 },
                    { 4, 6 },
                    { 4, 8 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 9 },
                    { 6, 4 },
                    { 7, 2 },
                    { 7, 8 },
                    { 8, 4 },
                    { 8, 7 },
                    { 9, 5 },
                    { 11, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
