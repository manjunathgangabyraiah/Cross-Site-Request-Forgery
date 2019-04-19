using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modelbinding1.Controllers
{
	public class EmployeeController : Controller
	{
		public ActionResult Index()
		{
			EmployeeBusinessLayer employeeBusinessLayer =
				new EmployeeBusinessLayer();

			List<Employee> employees = employeeBusinessLayer.Employees.ToList();
			return View(employees);
		}

		[HttpGet]
		[ValidateInput(false)]
		[Authorize]
		public ActionResult Create()
		{
			return View();
		}



		[HttpPost]
		[ActionName("Create")]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Create_Post()
		{
			Employee employee = new Employee();
			TryUpdateModel<Employee>(employee);

			if (ModelState.IsValid)
			{
				EmployeeBusinessLayer employeeBusinessLayer =
					new EmployeeBusinessLayer();
				employeeBusinessLayer.AddEmmployee(employee);
				return RedirectToAction("Index");
			}
			return View();
		}

		

		[HttpGet]
		public ActionResult Edit(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer =
				   new EmployeeBusinessLayer();
			Employee employee =
				   employeeBusinessLayer.Employees.Single(emp => emp.ID == id);

			return View(employee);
		}



		[HttpPost]
		[ActionName("Edit")]
		public ActionResult Edit_Post(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

			Employee employee = employeeBusinessLayer.Employees.Single(x => x.ID == id);
			TryUpdateModel(employee);

			if (ModelState.IsValid)
			{
				employeeBusinessLayer.SaveEmployee(employee);

				return RedirectToAction("Index");
			}

			return View(employee);
		}


		public ActionResult Delete(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer =
				new EmployeeBusinessLayer();
			employeeBusinessLayer.DeleteEmployee(id);
			return RedirectToAction("Index");
		}

		//[HttpPost]
		//[ActionName("Create")]
		//public ActionResult Create_Post(Employee employee)
		//{
		//	EmployeeBusinessLayer employeeBusinessLayer =
		//		new EmployeeBusinessLayer();

		//	if (ModelState.IsValid)
		//	{
		//		employeeBusinessLayer.AddEmmployee(employee);
		//		return RedirectToAction("Index");
		//	}
		//	else
		//	{
		//		return View();
		//	}
		//}


		//[HttpPost]
		//public ActionResult Create(FormCollection formCollection)
		//{
		//	Employee employee = new Employee();
		//	// Retrieve form data using form collection
		//	employee.Name = formCollection["Name"];
		//	employee.Gender = formCollection["Gender"];
		//	employee.City = formCollection["City"];
		//	employee.DateOfBirth =
		//		Convert.ToDateTime(formCollection["DateOfBirth"]);

		//	EmployeeBusinessLayer employeeBusinessLayer =
		//		new EmployeeBusinessLayer();

		//	employeeBusinessLayer.AddEmmployee(employee);
		//	return RedirectToAction("Index");
		//}

		//[HttpPost]
		//public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
		//{
		//	Employee employee = new Employee();
		//	employee.Name = name;
		//	employee.Gender = gender;
		//	employee.City = city;
		//	employee.DateOfBirth = dateOfBirth;

		//	EmployeeBusinessLayer employeeBusinessLayer =
		//		new EmployeeBusinessLayer();

		//	employeeBusinessLayer.AddEmmployee(employee);
		//	return RedirectToAction("Index");
		//}

	}
}