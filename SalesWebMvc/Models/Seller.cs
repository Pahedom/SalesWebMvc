using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} length must be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(0.0, 100000.0, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Base salary")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSale(SalesRecord sale)
        {
            Sales.Add(sale);
        }

        public void RemoveSale(SalesRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime? inicial, DateTime? final)
        {
            var sales = Sales.Where(obj => true);

            if (inicial.HasValue)
            {
                sales = Sales.Where(obj => obj.Date >= inicial);
            }
            if (final.HasValue)
            {
                sales = Sales.Where(obj => obj.Date <= final);
            }

            return sales.Sum(sr => sr.Value);
        }
    }
}