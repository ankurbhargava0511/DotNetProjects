using System.ComponentModel.DataAnnotations;

namespace MinimalApi
{
    public class MyContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }


    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public override string ToString()
        {
            return $"Product ID: {Id}, Product Name: {ProductName}";
        }
    }


    public class Employee
    {
        [Required(ErrorMessage ="Id is required")]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
