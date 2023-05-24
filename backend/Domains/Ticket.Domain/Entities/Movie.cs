namespace Ticket.Domain.Entities;

public class Movie : Entity<string>, IEntity<string>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public string BannerSrc { get; set; }

    public Movie(
        string title,
        string description,
        TimeSpan duration,
        string bannerSrc)
    {
        Title = title;
        Description = description;
        Duration = duration;
        BannerSrc = bannerSrc;
    }
    public Movie(
        string id,
        bool deleted,
        string title,
        string description,
        TimeSpan duration,
        string bannerSrc)
        : base(id, deleted)
    {
        Title = title;
        Description = description;
        Duration = duration;
        BannerSrc = bannerSrc;
    }
}
