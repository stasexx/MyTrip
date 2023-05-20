using Domain.Models;

namespace Persistence;

public class Seed
{
    public static async Task SeedDataUsers(DataContext contex)
    {
        if (contex.Users.Any()) return;
        var users = new List<User>()
        {
            new User
            {
                Password = "12345",
                Login = "first",
                Email = "somebody@gmail.com",
                OrgRights = true,
                Agency = "ALABAMA",
                Experience = 120,
                firstName = "Stanislav",
                lastName = "Kovac",
                phoneNumber = "12345",
                City = "Kharkiv",
                Avatar = "23rfregy43r32gw4g",
                availabilityOfProfile = true,
                availabilityOfTours = true,
                IsBanned = false,
                RegDate = DateTime.Today

            },

            new User
            {
                Password = "12345",
                Login = "first",
                Email = "somebody@gmail.com",
                OrgRights = true,
                Agency = "ALABAMA",
                Experience = 120,
                firstName = "Stanislav",
                lastName = "Kovac",
                phoneNumber = "12345",
                City = "Kharkiv",
                Avatar = "23rfregy43r32gw4g",
                availabilityOfProfile = true,
                availabilityOfTours = true,
                IsBanned = false,
                RegDate = DateTime.Today
            }
        };
        await contex.Users.AddRangeAsync(users);
        await contex.SaveChangesAsync();
    }
    public static async Task SeedDataTours(DataContext contex)
    {
        if (contex.Tours.Any()) return;
        var tours = new List<Tour>()
        {
            new Tour()
            {
                Name = "Paris",
                Description = "You can see beautiful country side in capital of France - Paris",
                Rate = 5,
                typeOfTour = "orh",
                Category = "Romantic",
                startDate = DateTime.Now,
                endDate = DateTime.Today,
                Destination = "Paris",
                placeOfDeparture = "Odessa",
                countOfUser = 6,
                mainPhoto = "ergoierg;1",
                allPhotos = "fdsfdsf",
                Tags = "super; puper; class;"
            },
            new Tour()
            {
                Name = "London",
                Description = "You can see beautiful country side in capital of France - Paris",
                Rate = 5,
                typeOfTour = "orh",
                Category = "Romantic",
                startDate = DateTime.Now,
                endDate = DateTime.Today,
                Destination = "Paris",
                placeOfDeparture = "Odessa",
                countOfUser = 6,
                mainPhoto = "ergoierg;1",
                allPhotos = "fdsfdsf",
                Tags = "super; puper; class;"
            }
        };
        await contex.Tours.AddRangeAsync(tours);
        await contex.SaveChangesAsync();
    }
    
}