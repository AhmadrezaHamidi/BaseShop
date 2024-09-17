using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.Models.InputDtos.User;

public class LoginInput
{
    [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]

    public string username { get; set; }
    [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
    public string password { get; set; }

}
