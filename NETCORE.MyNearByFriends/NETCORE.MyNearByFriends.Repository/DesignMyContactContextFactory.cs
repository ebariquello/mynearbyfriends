using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NETCORE.MyNearByFriends.Repository
{
   
    public class DesignMyFriendPostionContextFactory : IDesignTimeDbContextFactory<MyFriendsPositionContext>
    {

        MyFriendsPositionContext IDesignTimeDbContextFactory<MyFriendsPositionContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<MyFriendsPositionContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new MyFriendsPositionContext(builder.Options);
        }
    }
}
