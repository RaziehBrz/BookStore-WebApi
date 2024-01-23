using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore_WebApi.Validations
{
    public class BankeywordAttribute : ValidationAttribute
    {
        public List<string> BanKeywords { get; set; }
        public BankeywordAttribute()
        {
            BanKeywords = new List<string>()
            {
                "shit"
            };
        }
        public override string FormatErrorMessage(string name)
        {
            return "لطفا از کلمات ممنوعه در عنوان استفاده نکنید";
        }
        public override bool IsValid(object value) //True or False
        {
            var title = (string)value;
            if (BanKeywords.Contains(title.ToLower())) return false;
            return true;
        }
    }
}