using System.ComponentModel.DataAnnotations;
using BookStore_WebApi.Validations;

namespace BookStore_WebApi.Models
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "لطفا عنوان کتاب را وارد کنید")]
        [Bankeyword]
        public string Title { get; set; }
        [StringLength(30, ErrorMessage = "توضیحات نباید بیش از 30 حرف باشد")]
        public string Description { get; set; }
        public int Amount { get; set; }
        [Range(10, 2000, ErrorMessage = "تعداد صفحات باید عددی بین 10 تا 2000 باشد")]
        public int page { get; set; }

        /* [Required]
         public string Password { get; set; }
         [Required]
         [Compare(nameof(Password))]
         public string RepeatPassword { get; set; }*/
    }
}
