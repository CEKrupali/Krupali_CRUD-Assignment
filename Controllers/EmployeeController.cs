using Krupali_CRUD_Assignment.DAL;
using Krupali_CRUD_Assignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Krupali_CRUD_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        #region Employee List
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDBHandle employeeDBHandle = new EmployeeDBHandle();
            ModelState.Clear();
            return View(employeeDBHandle.GetEmployee());
        }

        #endregion


        #region Create Employee
        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee model, HttpPostedFileBase[] files)
        {
            try
            {
                // TODO: Add insert logic here
                try
                {
                    if (ModelState.IsValid)
                    {
                        EmployeeDBHandle employeeDBHandle = new EmployeeDBHandle();
                        int empId = employeeDBHandle.AddEmployee(model);
                        if (empId > 0)
                        {
                            //iterating through multiple file collection 
                            List<EmployeeDetial> employeeDetials = new List<EmployeeDetial>();
                            int count = Request.Files.Count;
                            if (count > 0)
                            {
                                var listfiles = Request.Files;
                                foreach (string str in listfiles)
                                {
                                    employeeDetials = new List<EmployeeDetial>();
                                    HttpPostedFileBase httpPostedFileBase = Request.Files[str] as HttpPostedFileBase;
                                    if (httpPostedFileBase != null)
                                    {
                                        var fileName = Path.GetFileName(httpPostedFileBase.FileName);
                                        if (!String.IsNullOrEmpty(fileName))
                                        {
                                            string ServerSavePath = "/UploadedFiles/" + fileName;
                                            var file = httpPostedFileBase;
                                            string path = "~/UploadedFiles/";
                                            //var itemFileName = System.Guid.NewGuid().ToString("N") + System.IO.Path.GetFileName(file.FileName);
                                            var itemFileName = System.IO.Path.GetFileName(file.FileName);
                                            path = System.IO.Path.Combine(Server.MapPath(path), itemFileName.ToString());//FileUpload.FileName
                                            file.SaveAs(path);

                                            employeeDetials.Add(new EmployeeDetial()
                                            {
                                                FileName = itemFileName,
                                                FilePath = ServerSavePath,
                                                EmpId = empId
                                            });
                                            if (employeeDBHandle.AddEmployeeDtl(employeeDetials))
                                            {
                                                ModelState.Clear();
                                            }
                                        }
                                    }
                                }
                            }
                            TempData["Message"] = "Employee Added Successfully";
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region Edit Employee

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeDBHandle employeeDBHandle = new EmployeeDBHandle();
            Employee employee = new Employee();
            employee = employeeDBHandle.GetEmployee().Find(smodel => smodel.EmpId == id);
            employee.EmployeeDtlList = employeeDBHandle.GetEmployeeDtl(id);

            //return View(employeeDBHandle.GetEmployee().Find(smodel => smodel.EmpId == id));
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Employee model)
        {
            try
            {
                // TODO: Add update logic here
                try
                {
                    EmployeeDBHandle employeeDBHandle = new EmployeeDBHandle();
                    employeeDBHandle.UpdateEmployee(model);

                    int count = Request.Files.Count;
                    if (count > 0)
                    {
                        List<EmployeeDetial> employeeDetials = new List<EmployeeDetial>();
                        var listfiles = Request.Files;
                        //employeeDBHandle.DeleteEmployeeDtlbyEmpId(Convert.ToInt32(model.EmpId));
                        foreach (string str in listfiles)
                        {
                            employeeDetials = new List<EmployeeDetial>();
                            HttpPostedFileBase httpPostedFileBase = Request.Files[str] as HttpPostedFileBase;
                            if (httpPostedFileBase != null)
                            {
                                var fileName = Path.GetFileName(httpPostedFileBase.FileName);
                                if (!String.IsNullOrEmpty(fileName))
                                {
                                    string ServerSavePath = "/UploadedFiles/" + fileName;
                                    var file = httpPostedFileBase;
                                    string path = "~/UploadedFiles/";
                                    var itemFileName = System.IO.Path.GetFileName(file.FileName);
                                    path = System.IO.Path.Combine(Server.MapPath(path), itemFileName.ToString());//FileUpload.FileName
                                    file.SaveAs(path);

                                    employeeDetials.Add(new EmployeeDetial()
                                    {
                                        FileName = fileName,
                                        FilePath = ServerSavePath,
                                        EmpId = model.EmpId
                                    });
                                    if (employeeDBHandle.UpdateEmployeeDtl(employeeDetials))
                                    {
                                        ModelState.Clear();
                                    }
                                }

                            }
                        }
                    }
                    TempData["Message"] = "Employee Updated Successfully";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region Delete Employee

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeDBHandle employeeDBHandle = new EmployeeDBHandle();
                if (employeeDBHandle.DeleteEmployee(id))
                {
                    TempData["Message"] = "Employee Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            //return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region Delete Employee Detail

        // GET: Employee/Delete/5
        public ActionResult DeleteEmployeeDtl(string EmpDtlid)
        {
            try
            {
                EmployeeDBHandle employeeDBHandle = new EmployeeDBHandle();
                if (employeeDBHandle.DeleteEmployeeDtl(Convert.ToInt32(EmpDtlid)))
                {
                    ViewBag.AlertMsg = "Employee Detail Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            //return View();
        }

        #endregion
    }
}
