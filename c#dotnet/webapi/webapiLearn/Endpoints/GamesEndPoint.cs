using Microsoft.AspNetCore.Mvc;
using webapiLearn.Dtos;

namespace webapiLearn.Endpoints;
public static class GamesEndpoint
{
  const string gamesRoute = "games";
  private static readonly List<GameDto> games = [
  new (1,"Final Fantasy XIV","RolePlaying",59.99M,new DateOnly(2010, 9, 30)),
  new (2,"Fifa 23","RolePlaying",84.78M,new DateOnly(2007, 10, 16)),
];

  public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup(gamesRoute)
    .WithParameterValidation();

    //get all games
    group.MapGet("/", () => games);

    //get a game by id
    group.MapGet("/{id}", (int id) =>
    {
      GameDto? game = games.Find(game => game.Id == id);

      return game is null ? Results.NotFound() : Results.Ok(game);
    })
    .WithName(gamesRoute);

    //post a new game
    group.MapPost("/", (CreateGameDto newGame) =>
    {
      GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);

      games.Add(game);

      return Results.CreatedAtRoute(gamesRoute, new { id = game.Id }, game);
    });

    //update a game
    group.MapPut("/", ([FromQuery] int id, [FromBody] UpdateGameDto updatedGame) =>
    {
      int index = games.FindIndex(game => game.Id == id);

      if (index == -1)
      {
        return Results.NotFound();
      }

      games[index] = new GameDto(
        games[index].Id,
        updatedGame.Name ?? games[index].Name,
        updatedGame.Genre ?? games[index].Genre,
        updatedGame.Price ?? games[index].Price,
        updatedGame.ReleaseDate ?? games[index].ReleaseDate
      );

      return Results.NoContent();
    });


    //delete a game
    group.MapDelete("/{id}", (int id) =>
    {
      int index = games.FindIndex(game => game.Id == id);

      if (index == -1)
      {
        return Results.NotFound();
      }

      games.RemoveAll(game => game.Id == id);

      return Results.NoContent();
    });

    return group;
  }

}