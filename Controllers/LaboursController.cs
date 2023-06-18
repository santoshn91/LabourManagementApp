using LabourManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabourManagementApp.Controllers
{
    public class LaboursController : Controller
    {
        // GET: Labours
        public ViewResult GetAllLabours()
        {
            List<LabourViewModel> labourViewModels = new List<LabourViewModel>();
            DataSet dataSet = new DataSet();
            LabourModelManager labourModelManager = new LabourModelManager();
            dataSet = labourModelManager.GetLabours();
            foreach(DataRow dr in dataSet.Tables[0].Rows)
            {
                labourViewModels.Add(new LabourViewModel
                {
                    Lid = Convert.ToInt32(dr["lid"]),
                    Fname = dr["fname"].ToString(),
                    Lname = dr["lname"].ToString(),
                    Gender = dr["gender"].ToString(),
                    Age = Convert.ToInt32(dr["age"]),
                    Bg = dr["bg"].ToString(),
                    Number = Convert.ToInt64(dr["number"])
                });
            }
            return View(labourViewModels);
            //LabourModelManager modelManager = new LabourModelManager();
            //List<LabourViewModel> labours = modelManager.GetLabours();
            //return View(labours);
        }
        [HttpGet]
        public ViewResult CreateLabour()
        {
            LabourViewModel labour = new LabourViewModel();
            return View(labour);
        }
        [HttpPost]
        public ActionResult CreateLabour(LabourViewModel labour)
        {
            if (ModelState.IsValid || labour.Lid == 0 && labour.IsPolicyAccepted)
            {
                LabourModelManager modelManager = new LabourModelManager();
                int insertedRow = modelManager.CreateLabour(labour);
                if (insertedRow > 0)
                {
                    return RedirectToAction("GetAllLabours");
                }
            }
            return View(labour);
        }
        [HttpGet]
        public ActionResult UpdateLabour(int id)
        {
            LabourModelManager modelManager = new LabourModelManager();
            LabourViewModel labour = modelManager.GetLabourById(id);
            return View(labour);
        }
        [HttpPost]
        public ActionResult UpdateLabour(LabourViewModel labour)
        {
            if (ModelState.IsValid)
            {
                LabourModelManager modelManager = new LabourModelManager();
                int updatedRow = modelManager.UpdateLabour(labour);
                if (updatedRow > 0)
                {
                    return RedirectToAction("GetAllLabours");
                }
            }
            return View(labour);
        }
        public ActionResult DeleteLabour(int id)
        {
            LabourModelManager modelManager = new LabourModelManager();
            int deletedRow = modelManager.DeleteLabour(id);
            if (deletedRow > 0)
            {
                return RedirectToAction("GetAllLabours");
            }
            return View();
        }
    }
}