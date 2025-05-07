using Microsoft.EntityFrameworkCore;
using webapiLearn.Data;

namespace webapiLearn.Endpoints;

public static class GenresEndpoints
{
  const string genresRoute = "genres";
  public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
  {
    var group = app.MapGroup(genresRoute)
    .WithParameterValidation();

    //get all game
    group.MapGet("/", async (GamesStoreContext dbContext) =>
    {
      return await dbContext.Genres
      .AsNoTracking()
      .OrderByDescending(genre => genre.Id)
      .ToListAsync();
    });

    return group;
  }
}