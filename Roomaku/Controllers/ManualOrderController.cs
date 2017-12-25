using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.Models;
using CaptchaMvc.HtmlHelpers;
using RoomakuRepository;

namespace Roomaku.Controllers
{
    public class ManualOrderController : Controller
    {
        // GET: ManualOrder
        public ActionResult Index(FormCollection form)
        {
            // Code for validating the Captcha  
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                tblT_Roomaku data = new tblT_Roomaku();
                data.Nama = form["NAMA"];
                data.Email = form["EMAIL"];
                data.Lokasi = form["LOKASI"];
                data.Material = form["MATERIAL"];
                data.Nama = form["NAMA"];
                data.Telp = form["TELP"];
                
                tblT_RoomakuODataController datas = new tblT_RoomakuODataController();
                datas.Post(data);
            }
            else
            {
                ViewBag.ErrMessage = "Please input the correct text";
            }

            return View();
        }
        
        public ActionResult SubmitRequest()
        {
            // Code for validating the Captcha  
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                ViewBag.ErrMessage = "Validation Message";
            }
            else
            {

            }

            //tblT_RoomakuODataController t = new tblT_RoomakuODataController();
            //t.Post(item);
            return View();
        }
    }
}