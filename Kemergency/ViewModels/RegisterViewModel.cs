using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "برښنالیک داخل کړي")]
        [EmailAddress(ErrorMessage = "  برښنالیک سم نه دي ")]
        // [Remote(action: "IsEmailInUse", controller: "Account")]
        [Display(Name = "برښنالیک")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پټ نوم داخل کړي")]
        [DataType(DataType.Password)]
        [Display(Name = "پټ نوم")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "پټ نوم تا ید کړي")]
        [Compare("Password",
            ErrorMessage = "پټ نوم یوشي نه دي")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = " نوم داخل کړي")]
        [DataType(DataType.Text)]
        [Display(Name = " نوم")]
        public string Name { get; set; }
        [Required(ErrorMessage = " تليفون نمبر داخل کړي")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "تليفون")]
        public string Phone { get; set; }
        [Display(Name = " عکس")]
        public string Image { get; set; }
        [Display(Name = " ادرس")]
        public string Address { get; set; }
        [Required(ErrorMessage = " ى تذکیري نمبر داخل کړي")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "تذکیري نمبر")]
        public string NicNubmer { get; set; }
    }
}
