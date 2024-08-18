﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Views
{

    public class AdminPageFlyoutMenuItem
    {
        public AdminPageFlyoutMenuItem()
        {
            TargetType = typeof(AdminPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}