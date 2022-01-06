﻿using backendWeb.Controllers;
using backendWeb.Models.ViewModel;
using backendWeb.Service.InterFace;
using backendWeb.Service.ServiceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace backendWeb.Areas.ApplyForm.Controllers
{
    public class RecevieController : BaseController
    {
        // GET: ApplyForm/Recevie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Table()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Table(int draw, int start, int length)
        {
            IBaseCrudService<viewModelRecevieCases> crudService = new recevieCasesService();
            IList<viewModelRecevieCases> list= crudService.GetList(new viewModelRecevieCases { draw = draw, start = start, length = length });
            var returnObj =
                  new
                  {
                      draw = draw,
                      recordsTotal = 4,
                      recordsFiltered = 4,
                      data = list == null ? new List<viewModelRecevieCases>() : list//分頁後的資料 
                  };
            return Json(returnObj);
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}