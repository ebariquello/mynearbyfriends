
using NETCORE.MyNearByFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCORE.MyNearByFriends.Repository
{
    public class DbInitializer
    {
        public static void Initialize(MyFriendsPositionContext context)
        {
            context.Database.EnsureCreated();
            var myFriendsPositionsList = new List<MyNearByFriends.Models.MyFriendPosition>{
                new MyFriendPosition("Eduardo Bariquello",-150, -110),
                new MyFriendPosition("MyFriend A",10, 20),
                new MyFriendPosition("MyFriend B",-63, -71),
                new MyFriendPosition("MyFriend C",20, 55),
                new MyFriendPosition("MyFriend D",40, 45),
                new MyFriendPosition("MyFriend E",-21, -09),
                new MyFriendPosition("MyFriend F",47, 53),
                new MyFriendPosition("MyFriend G",-30, -44),
                new MyFriendPosition("MyFriend H",150, 122),
                new MyFriendPosition("MyFriend I",-100, -88),
            };
           
            foreach (MyFriendPosition mfp in myFriendsPositionsList)
            {
                context.MyFriendsPositions.Add(mfp);
            }
            context.SaveChanges();

            context.Users.Add(new User
            {
                UserLogin="ebariquello",
                Password="pass@word1", 
            });
            context.Users.Add(new User
            {
                UserLogin = "aandrade",
                Password = "pass@word1",
            });


            context.SaveChanges();
        }
    }
}
