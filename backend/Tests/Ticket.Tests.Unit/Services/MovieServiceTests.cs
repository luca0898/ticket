using Ticket.Domain.Contracts.Repositories;
using Ticket.Domain.Contracts.Services;
using Ticket.Domain.Entities;
using Ticket.Services.Implementations;
using Moq;
using System.Linq.Expressions;

namespace Ticket.Tests.Unit.Services;

public class MovieServiceTests
{
    private readonly Mock<IMovieRepository> _movieRepository;
    private readonly IMovieService _movieService;

    public MovieServiceTests()
    {
        _movieRepository = new Mock<IMovieRepository>();
        _movieService = new MovieService(_movieRepository.Object);
    }

    [Fact]
    public async Task CountAsync_ShouldCallRepositoryCountAsync()
    {
        // Arrange
        var cancellationToken = new CancellationToken();

        _movieRepository.Setup(x => x.CountAsync(cancellationToken))
            .ReturnsAsync(3);

        // Act
        var result = await _movieService.CountAsync(cancellationToken);

        // Assert
        Assert.Equal(3, result);
        _movieRepository.Verify(x => x.CountAsync(cancellationToken), Times.Once);
    }

    [Fact]
    public async Task CountAsync_WithFilter_ShouldCallRepositoryCountAsyncWithFilter()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        Expression<Func<Movie, bool>> filter = m => m.Title.Contains("Godfather");

        _movieRepository.Setup(x => x.CountAsync(filter, cancellationToken))
            .ReturnsAsync(2);

        // Act
        var result = await _movieService.CountAsync(filter, cancellationToken);

        // Assert
        Assert.Equal(2, result);
        _movieRepository.Verify(x => x.CountAsync(filter, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_ShouldCallRepositoryCreateAsync()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        var movie = new Movie(Guid.NewGuid().ToString(), false, "The Shawshank Redemption", "", new TimeSpan(), "");

        _movieRepository.Setup(x => x.CreateAsync(movie, cancellationToken))
            .ReturnsAsync(movie);

        // Act
        var result = await _movieService.CreateAsync(movie, cancellationToken);

        // Assert
        Assert.Equal(movie, result);
        _movieRepository.Verify(x => x.CreateAsync(movie, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WithMultipleEntities_ShouldCallRepositoryCreateAsync()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        var movies = new List<Movie>
        {
            new Movie(Guid.NewGuid().ToString(), false, "The Shawshank Redemption", "", new TimeSpan(), ""),
            new Movie (Guid.NewGuid().ToString(), false, "The Godfather", "", new TimeSpan(), "")
        };

        _movieRepository.Setup(x => x.CreateAsync(movies, cancellationToken))
            .ReturnsAsync(movies);

        // Act
        var result = await _movieService.CreateAsync(movies, cancellationToken);

        // Assert
        Assert.Equal(movies, result);
        _movieRepository.Verify(x => x.CreateAsync(movies, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        var id = Guid.NewGuid().ToString();

        // Act
        await _movieService.DeleteAsync(id, cancellationToken);

        // Assert
        _movieRepository.Verify(x => x.DeleteAsync(id, cancellationToken), Times.Once);
    }
    
    [Fact]
    public async Task CountAsync_ShouldReturnCount()
    {
        // Arrange
        _movieRepository.Setup(x => x.CountAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(5);

        // Act
        var result = await _movieService.CountAsync(CancellationToken.None);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public async Task CountAsync_WithFilter_ShouldReturnFilteredCount()
    {
        // Arrange
        Expression<Func<Movie, bool>> filter = m => m.Title.Contains("Godfather");

        _movieRepository.Setup(x => x.CountAsync(filter, It.IsAny<CancellationToken>()))
            .ReturnsAsync(2);

        // Act
        var result = await _movieService.CountAsync(filter, CancellationToken.None);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreatedEntity()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var movieToCreate = new Movie("The Godfather", "", new TimeSpan(), "");
        _movieRepository.Setup(x => x.CreateAsync(movieToCreate, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Movie (id, false, "The Godfather", "", new TimeSpan(), ""));

        // Act
        var result = await _movieService.CreateAsync(movieToCreate, CancellationToken.None);

        // Assert
        Assert.Equal(id, result.Id);
        Assert.Equal("The Godfather", result.Title);
    }

    [Fact]
    public async Task ExistAsync_ShouldCallRepositoryExistAsync()
    {
        // Arrange
        var movieId = Guid.NewGuid().ToString();
        _movieRepository.Setup(x => x.ExistAsync(movieId, default)).ReturnsAsync(true);

        // Act
        var result = await _movieService.ExistAsync(movieId);

        // Assert
        Assert.True(result);
        _movieRepository.Verify(x => x.ExistAsync(movieId, default), Times.Once);
    }

    [Fact]
    public async Task ExistAsync_WithFilter_ShouldCallRepositoryExistAsync()
    {
        // Arrange
        Expression<Func<Movie, bool>> filter = m => m.Title.Contains("Godfather");
        _movieRepository.Setup(x => x.ExistAsync(filter, default)).ReturnsAsync(true);

        // Act
        var result = await _movieService.ExistAsync(filter);

        // Assert
        Assert.True(result);
        _movieRepository.Verify(x => x.ExistAsync(filter, default), Times.Once);
    }
}