using SolidDistilled.Models;

namespace SolidDistilled.Data;

public class BookRepository
{
    public List<Book> ListAll()
    {
        return [
            new () { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 42.99m, Thumbnail = "clean-code.jpg" },
            new () { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt, David Thomas", Price = 39.99m, Thumbnail = "pragmatic-programmer.jpg" },
            new () { Id = 3, Title = "Design Patterns:  Elements of Reusable Object-Oriented Software", Author = " Erich Gamma,Richard Helm,Ralph Johnson,John Vlissides.", Price = 49.99m, Thumbnail = "design-patterns.jpg" },
            new () { Id = 4, Title = "Refactoring", Author = "Martin Fowler", Price = 45.50m, Thumbnail = "refactoring.jpg" },
            new () { Id = 5, Title = "Domain-Driven Design", Author = "Eric Evans", Price = 59.99m, Thumbnail = "ddd.jpg" },
            new () { Id = 6, Title = "Working Effectively with Legacy Code", Author = "Michael Feathers", Price = 44.00m, Thumbnail = "legacy-code.jpg" },
            new () { Id = 7, Title = "Continuous Delivery", Author = "Jez Humble, David Farley", Price = 47.95m, Thumbnail = "continuous-delivery.jpg" },
            new () { Id = 8, Title = "Clean Architecture", Author = "Robert C. Martin", Price = 43.99m, Thumbnail = "clean-architecture.jpg" },
            new () { Id = 9, Title = "Software Engineering at Google", Author = " Tom Manshreck,Hyrum Wright,Titus Winters", Price = 46.99m, Thumbnail = "google-se.jpg" },
            new () { Id = 10, Title = "Structure and Interpretation of Computer Programs", Author = "Harold Abelson, Gerald Jay Sussman", Price = 55.00m, Thumbnail = "sicp.jpg" },
            new () { Id = 11, Title = "The Mythical Man-Month", Author = "Frederick P. Brooks Jr.", Price = 37.95m, Thumbnail = "mythical-man-month.jpg" },
            new () { Id = 12, Title = "Peopleware", Author = "Tom DeMarco, Timothy Lister", Price = 34.95m, Thumbnail = "peopleware.jpg" },
            new () { Id = 13, Title = "You Don’t Know JS", Author = "Kyle Simpson", Price = 29.99m, Thumbnail = "ydkjs.jpg" },
            new () { Id = 14, Title = "Soft Skills", Author = "John Sonmez", Price = 35.99m, Thumbnail = "soft-skills.jpg" },
            new () { Id = 15, Title = "Code Complete", Author = "Steve McConnell", Price = 54.99m, Thumbnail = "code-complete.jpg" },
            new () { Id = 16, Title = "The Phoenix Project", Author = "Gene Kim et al.", Price = 39.95m, Thumbnail = "phoenix-project.jpg" },
            new () { Id = 17, Title = "Extreme Programming Explained", Author = "Kent Beck", Price = 38.50m, Thumbnail = "xp-explained.jpg" },
            new () { Id = 18, Title = "Accelerate", Author = " Nicole Forsgren,Jez Humble, Gene Kim", Price = 41.95m, Thumbnail = "accelerate.jpg" },
            new () { Id = 19, Title = "Fundamentals of Software Architecture", Author = "Mark Richards, Neal Ford", Price = 49.95m, Thumbnail = "fundamentals-architecture.jpg" },
            new () { Id = 20, Title = "Grokking Algorithms", Author = "Aditya Y. Bhargava", Price = 52.00m, Thumbnail = "grokking.jpg" },
        ];
    }
}