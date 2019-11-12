using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sispar.UI.WebApp.Controllers
{
    [Authorize]
    public class TithersController : Controller
    {

//        private readonly TitherRepository _ctx = new TitherRepository();

        public dynamic MaterialStatus { get; private set; }

        public ActionResult Index()
        {
            //          var tithers = _ctx.GetAll().OrderBy(t => t.Name);
            //            return View(tithers);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add(Tither tither)
        //{
        //    _ctx.Add(tither);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit(int id)
        //{
        //    var tither = _ctx.GetById(id);

        //    if (tither == null)
        //        return HttpNotFound();

        //    var strDateBirthSpouse = "";
        //    if (tither.DateBirthSpouse != null)
        //    {
        //        DateTime myDateBirthSpouse = (DateTime)tither.DateBirthSpouse;
        //        strDateBirthSpouse = myDateBirthSpouse.ToString("yyyy-MM-dd");
        //    }

        //    var strMarriegeDate = "";

        //    if (tither.MarriegeDate != null)
        //    {
        //        DateTime myMarriegeDate = (DateTime)tither.MarriegeDate;
        //        strMarriegeDate = myMarriegeDate.ToString("yyyy-MM-dd");
        //    }

        //    ViewBag.DateBirthSpouse = strDateBirthSpouse;
        //    ViewBag.MarriegeDate = strMarriegeDate;

        //    return View(tither);
        //}

        //[HttpPost]
        //public ActionResult Edit(Tither tither)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _ctx.Edit(tither);
        //        return RedirectToAction("Index");
        //    }

        //    return View("Edit", tither);

        //}

        //public ActionResult Delete(int id)
        //{
        //    var tither = _ctx.GetById(id);

        //    if (tither == null)
        //        return HttpNotFound();

        //    return View(tither);
        //}

        //[HttpPost]
        //public ActionResult Delete(Tither tAux)
        //{
        //    var tither = _ctx.GetById(tAux.Id);
        //    _ctx.Delete(tither);

        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
//            _ctx.Dispose();
        }
    }
}