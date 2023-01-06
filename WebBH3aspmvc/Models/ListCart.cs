using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBH3aspmvc.Models
{
    public class ListCart
    {
        public static List<cartItem> c = new List<cartItem>();
    }
    public class cartItem
    {
        public int iid;
        public int iqty;
    }
}