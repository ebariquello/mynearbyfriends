using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NETCORE.MyNearByFriends.Models
{
    public class CalcHistoryLog
    {
        public CalcHistoryLog()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CalcHistoryLogId { get; set; }
        public int MyFriendPositionId { get; set; }

        public string FriendName { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public string FriendName1 { get; set; }
        public int Latitude1 { get; set; }
        public int Longitude1 { get; set; }
        public double? CalcNearFriend1 { get; set; }

        public string FriendName2 { get; set; }
        public int Latitude2 { get; set; }
        public int Longitude2 { get; set; }
        public double? CalcNearFriend2 { get; set; }

        public string FriendName3 { get; set; }
        public int Latitude3 { get; set; }
        public int Longitude3 { get; set; }
        public double? CalcNearFriend3 { get; set; }


        
        public DateTime LogCreated { get; set; }
        public string LogCreatedBy { get; set; }

       

    }
}
