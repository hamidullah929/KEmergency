using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class LoginViewModel
    {


        /*
         The following is the model class for the User Registration View. Notice,
        we have decorated the Email property with the [Remote] attribute
        pointing it to the action method that should be invoked when the email value changes.
         */
        [Required (ErrorMessage = "برښنالیک داخل کړي")]
        [EmailAddress (ErrorMessage = "برښنالیک  مو سم نه دي")]
        // [Remote(action: "IsEmailInUse", controller: "Account")]
        [Display(Name = "برښنالیک")]
        public string Email { get; set; }

        [Required (ErrorMessage = "پټ نوم داخل کړي")]
        [DataType(DataType.Password, ErrorMessage = "پټ نوم باید حروف او حساب ولري ")]
        [Display(Name = "پټ نوم")]
        public string Password { get; set; }

        [Display(Name = "یاد ساتل")]
        public bool RememberMe { get; set; }
    }
}
