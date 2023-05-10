using Domain.Models;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext contex)
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
                phoneNumber = 12345,
                City = "Kharkiv",
                Avatar = "23rfregy43r32gw4g",
                availabilityOfProfile = true,
                availabilityOfTours = true

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
                phoneNumber = 12345,
                City = "Kharkiv",
                Avatar = "23rfregy43r32gw4g",
                availabilityOfProfile = true,
                availabilityOfTours = true

            }
        };
        await contex.Users.AddRangeAsync(users);
        await contex.SaveChangesAsync();
    }
    
}