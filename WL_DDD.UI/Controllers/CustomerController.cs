﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WL_DDD.Logic;
using WL_DDD.Logic.Common;

namespace WL_DDD.UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel customerModel)
        {
            Result<CustomerName> customerNameResult = CustomerName.Create(customerModel.Name);
            Result<Email> emailResult = Email.Create(customerModel.Email);

            if (customerNameResult.IsFailure)
                ModelState.AddModelError("Name", customerNameResult.Error);
            if (emailResult.IsFailure)
                ModelState.AddModelError("Email", emailResult.Error);

            if (!ModelState.IsValid)
                return View(customerModel);

            var customer = new Customer(customerNameResult.Value, emailResult.Value);

            return RedirectToAction("Index");
        }
    }

    public class CustomerModel
    {
        public string Name { get;set;}
        public string Email { get;set;}
    }
}