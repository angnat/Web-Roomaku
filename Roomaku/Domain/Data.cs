using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Roomaku.Models;

namespace Roomaku.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
            return menu.ToList();
        }
    }
}