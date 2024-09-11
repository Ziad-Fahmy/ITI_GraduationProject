using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITI_GraduationProject.Models
{
    public class Product
    {
        public int Id { get; set; }


        [StringLength(15, MinimumLength = 3, ErrorMessage = "Title Must be between 3 and 15 character.")]
        [Required(ErrorMessage = "Title is Required.")]
        [DisplayName("Product Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Quantity is Required.")]
        [DisplayName("Product Quantity")]
        public int Quantity { get; set; }


        [Range(1, 50000, ErrorMessage = "Price must be between 1 and 50000.")]
        [DisplayName("Product Price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Description is Required.")]
        [MinLength(7, ErrorMessage = "Discription must be more than 10 character")]
        [MaxLength(200, ErrorMessage = "Discription must be less than 200 character")]
        [DisplayName("Product Description")]
        public string Description { get; set; }


        public string ImagePath { get; set; }



        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }




    }
}
