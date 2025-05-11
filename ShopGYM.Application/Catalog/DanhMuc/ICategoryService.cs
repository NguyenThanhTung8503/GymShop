using ShopGYM.ViewModels.Catalog.DanhMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Application.Catalog.DanhMuc
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll();
        Task<CategoryVm> GetById( int id);
    }
}
