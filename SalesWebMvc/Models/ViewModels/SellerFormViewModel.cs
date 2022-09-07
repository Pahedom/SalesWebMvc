using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }

        public ICollection<Department> Departments { get; set; }

        public SellerFormViewModel()
        {
        }

        public SellerFormViewModel(Seller seller)
        {
            Seller = seller;
        }

        public SellerFormViewModel(ICollection<Department> departments)
        {
            Departments = departments;
        }

        public SellerFormViewModel(Seller seller, ICollection<Department> departments)
        {
            Seller = seller;
            Departments = departments;
        }
    }
}