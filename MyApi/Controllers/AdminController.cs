using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.Model;
using MyApi.Model.Context;
using MyApi.Repository;

namespace MyApi.Controllers
{
  [Route("api/[controller]")]
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
    //Context _context;
    private readonly IRepository<Category> _RepoC;
    private readonly IRepository<SubCategory> _RepoSC;
    private readonly IRepository<Trademark> _RepoT;
    private readonly IRepository<Models> _RepoM;
    private readonly IRepository<Adverts> _RepoA;
    private readonly IRepository<ApplicationUser> _RepoU;

    public AdminController(Context context, IRepository<Category> RepoC, IRepository<SubCategory> RepoSC, IRepository<Trademark> RepoT, IRepository<Models> RepoM, IRepository<Adverts> RepoA, IRepository<ApplicationUser> repoU)
    {
      _RepoC = RepoC;
      _RepoSC = RepoSC;
      _RepoT = RepoT;
      _RepoM = RepoM;
      _RepoA = RepoA;
      _RepoU = repoU;

    }
    //public IActionResult Index()
    //{////// safasfasfafdsdfsdf/////
    //    return View();osman/////
    //}///////
    [Route("ConfirmUser")]
    [HttpPost]
    public IActionResult ConfirmUser(string userId)
    {
      try
      {
        var user = _RepoU.Where(x => x.Id == userId).FirstOrDefault();
        if (user != null)
        {
          user.IsActive = true;
          _RepoU.Update(user);
          //log
          return Json(true);
        }
        else
          return Json(false);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("Confirmddvert")]
    [HttpPost]
    public IActionResult ConfirmAdvert(int advertId)
    {
      try
      {
        var advert = _RepoA.Where(x => x.Id == advertId).FirstOrDefault();
        if (advert != null)
        {
          advert.IsConfirmed = true;
          _RepoA.Update(advert);
          //log
          return Json(true);
        }
        else
          return Json(false);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("AddCategory")]
    [HttpPost]
    public IActionResult AddCategory([FromBody]Category category)
    {
      try
      {
        _RepoC.Add(category);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("AddSubCategory")]
    [HttpPost]
    public IActionResult AddSubCategory([FromBody]SubCategory subcategory)
    {
      try
      {
        _RepoSC.Add(subcategory);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("AddTrademark")]
    [HttpPost]
    public IActionResult AddTrademark([FromBody]Trademark trademark)
    {
      try
      {
        _RepoT.Add(trademark);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("AddModel")]
    [HttpPost]
    public IActionResult AddModel([FromBody]Models model)
    {
      try
      {
        _RepoM.Add(model);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }

    [Route("DeleteCategory")]
    [HttpPost]
    public IActionResult DeleteCategory(int categoryId)
    {
      try
      {
        Category c = _RepoC.Where(x => x.Id == categoryId).FirstOrDefault();
        c.IsActive = false;
        _RepoC.Update(c);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("DeleteSubCategory")]
    [HttpPost]
    public IActionResult DeleteSubCategory(int subcategoryId)
    {
      try
      {
        SubCategory Sc = _RepoSC.Where(x => x.Id == subcategoryId).FirstOrDefault();
        Sc.IsActive = false;
        _RepoSC.Update(Sc);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("DeleteTrademark")]
    [HttpPost]
    public IActionResult DeleteTrademark(int trademarkId)
    {
      try
      {
        Trademark t = _RepoT.Where(x => x.Id == trademarkId).FirstOrDefault();
        t.isActive = false;
        _RepoT.Update(t);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("DeleteModel")]
    [HttpPost]
    public IActionResult DeleteModel(int modelId)
    {
      try
      {
        Models m = _RepoM.Where(x => x.Id == modelId).FirstOrDefault();
        m.isActive = false;
        _RepoM.Update(m);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }

    [Route("UpdateCategory")]
    [HttpPost]
    public IActionResult UpdateCategory(int categoryId,[FromBody] Category model)
    {
      try
      {
        Category c = _RepoC.Where(x => x.Id == categoryId).FirstOrDefault();
        c.Name = model.Name;
        c.Description = model.Description;
        _RepoC.Update(c);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("UpdateSubCategory")]
    [HttpPost]
    public IActionResult UpdateSubCategory(int subcategoryId,[FromBody] SubCategory model)
    {
      try
      {
        SubCategory Sc = _RepoSC.Where(x => x.Id == subcategoryId).FirstOrDefault();
        Sc.Name = model.Name;
        Sc.Description = model.Description;
        _RepoSC.Update(Sc);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("UpdateTrademark")]
    [HttpPost]
    public IActionResult UpdateTrademark(int trademarkId,[FromBody] Trademark model)
    {
      try
      {
        Trademark t = _RepoT.Where(x => x.Id == trademarkId).FirstOrDefault();
        t.Name = model.Name;
        t.Description = model.Description;
        _RepoT.Update(t);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("UpdateModel")]
    [HttpPost]
    public IActionResult UpdateModel(int modelId,[FromBody] Models model)
    {
      try
      {
        Models m = _RepoM.Where(x => x.Id == modelId).FirstOrDefault();
        m.Name = model.Name;
        m.Description = model.Description;
        _RepoM.Update(m);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }

    [Route("GetUser")]
    [HttpGet]
    public IActionResult GetUser(string Id)
    {
      try
      {
        //log
        return Json(_RepoU.Where(x=>x.Id==Id).FirstOrDefault());
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("GetAdvert")]
    [HttpGet]
    public IActionResult GetAdvert(int Id)
    {
      try
      {        
        //log
        return Json(_RepoA.Where(x => x.Id == Id).FirstOrDefault());
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("GetAdverts")]
    [HttpGet]
    public IActionResult GetAdverts(string userId, int? categoryId, int? subCategoryId, int? trademarkId, int? modelId)
    {
      try
      {
        var adverts = _RepoA.All();
        if (!string.IsNullOrEmpty(userId))
          adverts = adverts.Where(x => x.UserId == userId);
        if(categoryId!=null)
          adverts = adverts.Where(x => x.CategoryId == categoryId);
        if(subCategoryId!=null)
          adverts = adverts.Where(x => x.SubCategoryId == subCategoryId);
        if (trademarkId != null)
          adverts = adverts.Where(x => x.TrademarkId == trademarkId);
        if (modelId != null)
          adverts = adverts.Where(x => x.ModelId == modelId);

        return Json(adverts);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }

    [Route("DeleteUser")]
    [HttpPost]
    public IActionResult DeleteUser(string userId)
    {
      try
      {
        var user = _RepoU.Where(x => x.Id == userId).FirstOrDefault();
        user.IsActive = false;
        _RepoU.Update(user);
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }

    [Route("DeleteAdvert")]
    [HttpPost]
    public IActionResult DeleteAdvert(int Id)
    {
      try
      {
        var advert = _RepoA.Where(x => x.Id == Id).FirstOrDefault();
        advert.IsDeleted = true;
        _RepoA.Update(advert);
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
  }
}