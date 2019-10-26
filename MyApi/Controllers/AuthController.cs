using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApi.Model;
using MyApi.Repository;

namespace MyApi.Controllers
{
  [Route("api/[controller]")]
  public class AuthController : Controller
  {
    private UserManager<ApplicationUser> userManager;
    public AuthController(UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }
    private IRepository<ApplicationUser> _repo;
    private IRepository<Log> _repoLog;
    public AuthController(IRepository<ApplicationUser> repo,IRepository<Log> repoLog)
    {
      _repo = repo;
      _repoLog = repoLog;
    }


    [Route("Register")]
    [HttpPost]
    public IActionResult Register(RegisterModel model)
    {
      try
      {
        ApplicationUser newUser = new ApplicationUser(); //Yeni kullanıcı oluşturma.
        newUser.Email = model.Email;
        newUser.PhoneNumber = model.PhoneNumber;
        newUser.UserName = model.UserName;
        newUser.PasswordHash = userManager.PasswordHasher.HashPassword(newUser, model.Password);
        _repo.Add(newUser);
        Log log = new Log // Kayıt Başarılı log.
        {
          Date = System.DateTime.Now,
          Exception = "",
          Description = "Yeni User Oluşturuldu."
        };
        _repoLog.Add(log);
        return Json(true);
      }
      catch (Exception ex)
      {
        Log log = new Log // Kayıt Hatası Log.
        {
          Date = System.DateTime.Now,
          Exception = ex.Message,
          Description = "Yeni User Oluşturulamadı!."
        };
        return Json(false);
      }
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {

      // _repo kullanılarakda yapılabilirdi.
      var user = await userManager.FindByNameAsync(model.UserName);
      if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
      {

        var claims = new[]
        {
                    new Claim (JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

        var token = new JwtSecurityToken(
            issuer: "http://oec.com",
            audience: "http://oec.com",
            expires: DateTime.Now.AddHours(1),
            claims: claims,
            signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
        return Ok(new
        {
          token = new JwtSecurityTokenHandler().WriteToken(token),
          expiration = token.ValidTo
        }); //Kullanıcı için bir token oluşturuluyor. Api ye bu token ile gelmeli ve expire oldugunda tekrar token almalı.
      }
      return Unauthorized();
    }

    [Route("ResetPassword")]
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ResetPassword(string email, string newPassword)
    {
      ApplicationUser user = await userManager.FindByEmailAsync(email);
      if(user!=null)
      {
        try
        {

          user.PasswordHash = userManager.PasswordHasher.HashPassword(user, newPassword);
          _repo.Update(user);
          Log log = new Log // Kayıt Başarılı log.
          {
            Date = System.DateTime.Now,
            Exception = "",
            Description =user.UserName+ "Kullanıcısı için Şifre Güncellendi."
          };
          _repoLog.Add(log);
          return Json(true);
        }
        catch (Exception ex)
        {
          Log log = new Log // Kayıt Hatası Log.
          {
            Date = System.DateTime.Now,
            Exception = ex.Message,
            Description = user.UserName +" Kullanıcısı için Şifre Güncellenemedi!."
          };
          return Json(false);
        }
      }
      else
      {
        return Json(false);
      }     
    }


    public IActionResult LogOut(string token)
    {
      //Logout için api'ye gelmeye gerek yok js ile tarayıcıda oluşan çerezi silmek yeterli.
      return Json(false);
    }
  }
}