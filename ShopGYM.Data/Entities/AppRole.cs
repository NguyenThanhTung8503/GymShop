using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class AppRole :IdentityRole<Guid>
    {
        public String MoTa {  get; set; }
    }
}
