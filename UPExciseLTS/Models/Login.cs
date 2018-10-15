using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UPExciseLTS.Models
{
    public class Login
    {
        public string clientCaptcha { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConFirmPassword { get; set; }


        public string DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string RoleId { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
    }


    public class ForgotRegistration
    {
        [Required(ErrorMessage = "Please Enter Aadhar Number")]
        public string AadharNo { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please Enter Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Select Radio Button")]
        public string Chk { get; set; }



        public string RegistrationCode { get; set; }
        public string Password { get; set; }
        public int otp { get; set; }
        public string otpValue { get; set; }
        public string Captcha { get; set; }
    }
}