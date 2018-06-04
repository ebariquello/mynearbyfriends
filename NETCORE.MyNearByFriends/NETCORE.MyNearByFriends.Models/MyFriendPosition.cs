using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE.MyNearByFriends.Models
{
    public class MyFriendPosition
    {
        public MyFriendPosition() { }
        public MyFriendPosition(string name, int longitude, int latitude)
        {
            FriendName = name;
            Longitude = longitude;
            Latitude = latitude;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MyFriendPositionId { get; set; }
        public string FriendName { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        [NotMapped]
        public double?  Calc { get; set; }
    }

}
