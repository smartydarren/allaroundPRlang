using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapiLearn.Data;
using webapiLearn.Dtos;
using webapiLearn.Entities;

namespace webapiLearn.Endpoints;

public static class GamesEndpointContext
{
  const string gamesRoute = "gamescontext";

  public static RouteGroupBuilder MapGamesEndpointsContext(this WebApplication app)
  {
    var group = app.MapGroup(gamesRoute)
    .WithParameterValidation();


    #region GetGames
    //get all games with EFcore
    group.MapGet("/", async (GamesStoreContext dbContext) =>
    {
      Console.WriteLine("Starting Async Await");

      Task.Delay(5000).Wait();

      var lst = await dbContext.Games
      .Include(games => games.Genre)
      .AsNoTracking()
      .OrderByDescending(g => g.Id)
      .Select(game => new GameDtoSummaryContext(
        game.Id,
        game.Name,
        game.Genre!.Name,
        game.Price,
        game.ReleaseDate
        ))
      .ToListAsync();

      Console.WriteLine("Ending Async Await");

      return Results.Ok(lst);
    });

    //Get all games with Dapper
    //group.MapGet("/dapper", ())
    #endregion

    //get a game by id
    group.MapGet("/{id}", async (int id, GamesStoreContext dbContext) =>
    {
      Game? gameEntity = await dbContext.Games.FindAsync(id);

      return gameEntity is null ? Results.NotFound() : Results.Ok(new GameDtoDetailContext(
        gameEntity!.Id,
        gameEntity!.Name,
        gameEntity!.GenreId,
        gameEntity!.Price,
        gameEntity!.ReleaseDate
      ));
    })
    .WithName(gamesRoute);

    //post a new game
    group.MapPost("/", async (CreateGameDtoContext newGame, GamesStoreContext dbContext) =>
    {

      Game gameEntity = new()
      {
        Name = newGame.Name,
        Genre = dbContext.Genres.Find(newGame.GenreId),
        GenreId = newGame.GenreId,
        Price = newGame.Price,
        ReleaseDate = newGame.ReleaseDate
      };
      dbContext.Games.Add(gameEntity);
      await dbContext.SaveChangesAsync();

      GameDtoSummaryContext game = new(
        gameEntity.Id,
        gameEntity.Name,
        gameEntity.Genre!.Name,
        gameEntity.Price,
        gameEntity.ReleaseDate
      );

      return Results.CreatedAtRoute(gamesRoute, new { id = gameEntity.Id }, game);
    });

    //update a game
    group.MapPut("/", async ([FromQuery] int id, [FromBody] UpdateGameDtoContext updatedGame, GamesStoreContext dbContext) =>
    {
      var existingGame = await dbContext.Games.FindAsync(id);

      if (existingGame is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame);

      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });


    //delete a game
    group.MapDelete("/{id}", async (int id, GamesStoreContext dbContext) =>
    {
      var existingGame = await dbContext.Games.FindAsync(id);

      if (existingGame is null)
      {
        return Results.NotFound();
      }

      await dbContext.Games.
      Where(games => games.Id == id)
      .ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }

}