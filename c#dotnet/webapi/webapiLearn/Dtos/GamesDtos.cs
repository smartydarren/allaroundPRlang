using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace webapiLearn.Dtos;

// a record is immutable, once its set it cannot be changed, remember the init keyword
public record GameDto(int? Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);

public record class GameDtoSummaryContext(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);

public record GameDtoDetailContext(int Id, string Name, int GenreId, decimal Price, DateOnly ReleaseDate);

public record CreateGameDto(
  [Required][StringLength(maximumLength: 30)] string Name,
  [Required][StringLength(20)] string Genre,
  [Range(1, 100)] decimal Price,
  DateOnly ReleaseDate);

public record CreateGameDtoContext(
[Required][StringLength(maximumLength: 30)] string Name,
int GenreId,
[Range(1, 100)] decimal Price,
DateOnly ReleaseDate);

// its best practise to create a separate dto for updating a record, as we do not want to mess with the other contract.
public record UpdateGameDto(
  [Required][StringLength(maximumLength: 30)] string Name,
  [Required][StringLength(20)] string Genre,
  [Range(1, 100)] decimal? Price,
  DateOnly? ReleaseDate);

public record UpdateGameDtoContext(
  [Required][StringLength(maximumLength: 30)] string Name,
  int GenreId,
  [Range(1, 100)] decimal? Price,
  [Optional] DateOnly? ReleaseDate);

public record DeleteGameDto(int Id);







