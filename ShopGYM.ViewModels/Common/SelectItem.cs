﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Common
{
    public class SelectItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }

        public object Select()
        {
            throw new NotImplementedException();
        }
    }
}
