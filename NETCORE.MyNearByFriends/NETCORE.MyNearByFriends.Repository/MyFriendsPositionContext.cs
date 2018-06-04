
using Microsoft.EntityFrameworkCore;
using NETCORE.MyNearByFriends.Models;

namespace NETCORE.MyNearByFriends.Repository
{
    public class MyFriendsPositionContext : DbContext
    {
        public MyFriendsPositionContext(DbContextOptions<MyFriendsPositionContext> options) : base(options)
        {

        }
        public DbSet<NETCORE.MyNearByFriends.Models.MyFriendPosition> MyFriendsPositions { get; set; }

        public DbSet<NETCORE.MyNearByFriends.Models.CalcHistoryLog> CalcHistoryLogs { get; set; }

        public DbSet<NETCORE.MyNearByFriends.Models.User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyFriendPosition>().ToTable("FriendPosition");
            modelBuilder.Entity<CalcHistoryLog>().ToTable("CalcHistoryLog");
            modelBuilder.Entity<User>().ToTable("UsersKeys");
        }

    }
}
