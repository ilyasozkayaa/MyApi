using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApi.Model;
using MyApi.Repository;

namespace MyApi.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  public class UserController : Controller
  {
    private IRepository<ApplicationUser> _repo;
    private IRepository<Log> _repoLog;
    private IRepository<Adverts> _repoAdvert;
    private IRepository<Bids> _repoBid;
    private IRepository<Messages> _repoMessage;

    public UserController(IRepository<ApplicationUser> repo, IRepository<Log> repoLog, IRepository<Adverts> repoAdvert, IRepository<Bids> repoBid, IRepository<Messages> repoMessage)
    {
      _repo = repo;
      _repoLog = repoLog;
      _repoAdvert = repoAdvert;
      _repoBid = repoBid;
      _repoMessage = repoMessage;
    }

    [Route("AddAdvert")]
    [HttpPost]
    public IActionResult AddAdvert([FromBody] Adverts model)
    {
      try
      {
        _repoAdvert.Add(model);
        //success log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log at
        return Json(false);
      }
    }

    [Route("AddImage")]
    [HttpPost]
    public IActionResult AddImage()
    {
      //
      return Json(true);
    }

    [Route("UpdateAdvert")]
    [HttpPost]
    public IActionResult UpdateImageAdvert(int imageId,Images model)
    {
      return Json(true);
    }

    [Route("GetMyAdverts")]
    [HttpGet]
    public IActionResult GetMyAdverts(string userId)
    {
      try
      {
        return Json(_repoAdvert.Where(x => x.UserId == userId).ToList());
        //log
      }
      catch (Exception ex)
      {
        return Json(false);
      }
      
    }

    [Route("SendMessage")]
    [HttpPost]
    public IActionResult SendMessage(string senderId, string receipentId, string message)
    {
      try
      {
        Messages m = new Messages();
        m.SenderUserId = senderId;
        m.ReceipentUserId = receipentId;
        m.MessageContent = message;
        m.SendDate = System.DateTime.Now;
        _repoMessage.Add(m);
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }

    }

    [Route("GiveBid")]
    [HttpPost]
    public IActionResult GiveBid([FromBody]Bids model)
    {
      try
      {
        _repoBid.Add(model);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }

    [Route("AdvertUpdate")]
    [HttpPost]
    public IActionResult AdvertUpdate(int advertId,[FromBody]Adverts newAdvert)
    {
      try
      {
        Adverts old = _repoAdvert.Where(x => x.Id == advertId).FirstOrDefault();
        old.IsConfirmed = newAdvert.IsConfirmed;
        old.IsDeleted = newAdvert.IsDeleted;
        old.IsSold = newAdvert.IsSold;
        old.ModelId = newAdvert.ModelId;
        old.SubCategoryId = newAdvert.SubCategoryId;
        old.Title = newAdvert.Title;
        old.TrademarkId = newAdvert.TrademarkId;
        old.View = newAdvert.View;
        old.Warranty = newAdvert.Warranty;
        _repoAdvert.Update(old);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("AdvertDelete")]
    [HttpPost]
    public IActionResult AdvertDelete(int advertId)
    {
      try
      {
        Adverts old = _repoAdvert.Where(x => x.Id == advertId).FirstOrDefault();
        old.IsDeleted = true;       
        _repoAdvert.Update(old);
        //log
        return Json(true);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
    [Route("FindAdvert")]
    [HttpPost]
    public IActionResult FindAdvert(int? categoryId,int? subCategoryId, int? trademarkId, int? modelId)
    {
      try
      {
        var advertList = _repoAdvert.All();
        if (categoryId != null)
          advertList = advertList.Where(x => x.CategoryId == categoryId);
        if(subCategoryId!=null)
          advertList = advertList.Where(x => x.SubCategoryId == subCategoryId);
        if(trademarkId!=null)
          advertList = advertList.Where(x => x.TrademarkId == trademarkId);
        if(modelId!=null)
          advertList = advertList.Where(x => x.ModelId == modelId);
        //log
        return Json(advertList);
      }
      catch (Exception ex)
      {
        //log
        return Json(false);
      }
    }
  }
}