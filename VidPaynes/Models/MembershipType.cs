using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidPaynes.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short signUpFee { get; set; }
        public byte MonthDuration { get; set; }
        public byte DiscountRate { get; set; }
        public string MembershipName { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}