using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XBDAppPortalMvcCoreApp.BLL;
using XBDAppPortalMvcCoreApp.DTO;
using XBDAppPortalMvcCoreAppPrj.Models;

namespace XBDAppPortalMvcCoreAppPrj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private XBDAppPortalListBLL xBDAppPortalListBLL;
        private IList<XDbAppDTO> portals;
        private IList<FilterDTO> appFilters;
        private IList<FilterDTO> appTypeFilters;
        private FiltersModel filtersModel;
        //private 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //var aa = this.HttpContext.Session.  
            this.appFilters = GetFilters(FilterEnum.App);
            this.appTypeFilters = GetFilters(FilterEnum.AppType);
            this.filtersModel = new FiltersModel();
        }

        //[HttpGet("{appId}")]
        //public IActionResult Index(int appId = 0)
        public IActionResult Index()
        {

            //ViewBag.Portals = this.GetPortalList();
            ViewBag.AppFilters = this.GetFilters(FilterEnum.App);
            ViewBag.AppTypeFilters = this.GetFilters(FilterEnum.AppType);
            

            //Load the poral list according to filters
            string appSelected = Request.Cookies["appSelected"];
            string appTypeSelected = Request.Cookies["appTypeSelected"];
            int intAppSelected = 0;
            int intAppTypeSelected = 0;
            if (!string.IsNullOrEmpty(appSelected))
                intAppSelected = Convert.ToInt32(appSelected);
            if (!string.IsNullOrEmpty(appTypeSelected))
                intAppTypeSelected = Convert.ToInt32(appTypeSelected);
            ViewBag.Portals = this.GetPortalListByFilters(intAppSelected, intAppTypeSelected);


            ViewBag.MyAppSelectList = this.ToSelectList(this.appFilters, appSelected);
            ViewBag.MyAppTypeSelectList = this.ToSelectList(this.appTypeFilters, appTypeSelected);
            //this.filtersModel.AppSlectedValue = appSelected;
            //this.filtersModel.AppTypeSlectedValue = appTypeSelected;
            //this.filtersModel.AppFilters = this.appFilters;
            this.filtersModel.AppFilters = this.ToSelectList(this.appFilters, appSelected);
            //this.filtersModel.AppTypeFilters = this.appTypeFilters;
            this.filtersModel.AppTypeFilters = this.ToSelectList(this.appTypeFilters, appTypeSelected);
            return View(this.filtersModel);
            
            //return View(this.ToSelectList(this.filtersModel.AppFilters));
        }

        ////[HttpPost]
        ////[HttpPost("{appId}/{appTypeId}")]
        //[HttpPost("{appId}")]
        //public IActionResult Index(int appId)
        ////public IActionResult Index()
        //{
        //    //ViewBag.Portals = this.GetPortalListByFilters(0,0);
        //    ViewBag.Portals = this.GetPortalListByFilters(appId, 0);
        //    ViewBag.AppFilters = this.GetFilters(FilterEnum.App);
        //    ViewBag.AppTypeFilters = this.GetFilters(FilterEnum.AppType);
        //    this.portals = ViewBag.Portals;

        //    return View(this.filtersModel);
        //    //return RedirectToAction("Index");
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IList<XDbAppDTO> GetPortalList()
        {
            xBDAppPortalListBLL = new XBDAppPortalListBLL();
 
            var ret = xBDAppPortalListBLL.GetXBDAppList();
            //return appPortals;
            return ret;
        }
        private IList<XDbAppDTO> GetPortalListByFilters(int appId, int appTypeId)
        {
            xBDAppPortalListBLL = new XBDAppPortalListBLL();
            //var ret = xBDAppPortalListBLL.GetXBDAppList();
            IList<FilterDTO> filters = new List<FilterDTO>();
            FilterDTO filter = new FilterDTO
            {
                Selected = true,
                ItemId = appId,
                FilterName = FilterEnum.App,
            };
            filters.Add(filter);
            filter = new FilterDTO
            {
                Selected = true,
                ItemId = appTypeId,
                FilterName = FilterEnum.AppType,
            };
            filters.Add(filter);
            var ret = xBDAppPortalListBLL.GetXBDAppListByFilter(filters);
            //return appPortals;
            return ret;
        }


        private IList<FilterDTO> GetFilters(FilterEnum filterEnum)
        {
            xBDAppPortalListBLL = new XBDAppPortalListBLL();
            if (filterEnum == FilterEnum.App)
            {
                //App filters get
                var ret = xBDAppPortalListBLL.FilterGet(FilterEnum.App);
                return ret;
            }
            else
            {
                //App Type filters get
                var ret = xBDAppPortalListBLL.FilterGet(FilterEnum.AppType);
                return ret;
            }

        }
  

        [NonAction]
        //public SelectList ToSelectList(DataTable table, string valueField, string textField)
        public SelectList ToSelectList(IList<FilterDTO> filters, string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list = filters.Select(filter => new SelectListItem 
            { 
                Text = filter.Item.ToString(), 
                Value = filter.ItemId.ToString(),
                //Selected = (selected == filter.ItemId.ToString())? true: false
            }).ToList();
            var ret = new SelectList(list, "Value", "Text", selected);
            
            return ret;
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //public ActionResult Edit( IFormCollection collection)
        public ActionResult Go(IFormCollection collection)
        {
            try
            {
                string appSelected = collection["ddlApp"][0];
                string appTypeSelected = collection["ddlAppType"][0];
                //Store the value to the cookies
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddSeconds(10);
                Response.Cookies.Append("appSelected", appSelected, options);
                Response.Cookies.Append("appTypeSelected", appTypeSelected, options);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        

    }
}
