using System.ComponentModel.DataAnnotations.Schema;

namespace G5.NetITIMVCDay03.Models
{
    public class Employee
    {
        /*---------------------------------------------------------*/
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "decimal(8,2)")]   // Total 8, After 2 => 123456.78
        public decimal Salary { get; set; }
        /*---------------------------------------------------------*/
        // One To Many
        // Department have Many Employees
        // FK
        public int DepartmentId { get; set; }
        // Navigation Prop
        public virtual Department? Department { get; set; }
        /*---------------------------------------------------------*/
    }
}
