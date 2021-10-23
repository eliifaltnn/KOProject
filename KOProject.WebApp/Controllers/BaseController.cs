using KOProject.Data;
using KOProject.Data.Entity;
using KOProject.WebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace KOProject.WebApp.Controllers
{
	[Authorize]
	public abstract class BaseController : Controller
	{
		protected readonly string m_Name;
		protected JsonSerializerOptions m_JsonOptions;

		public KoDbContext DB { get; private set; }


		protected BaseController(string name, KoDbContext db)
		{
			m_Name = name;
			DB = db;

			m_JsonOptions = new JsonSerializerOptions();
		}


		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			ViewBag.AppUser = GetUserData();
		}


		protected ContentResult ErrorResult(string errorMessage)
		{
			return new ContentResult()
			{
				StatusCode = 500,
				Content = errorMessage,
				ContentType = "text/plain"
			};
		}

		protected ContentResult ErrorResult(string messageTitle, Exception ex)
		{
			string errDetail = ex != null ? "<br/>Detay: " + ex.Message : "";

			if (ex != null && ex.InnerException != null)
			{
				errDetail += "<br/>" + ex.InnerException.Message;
			}

			return new ContentResult()
			{
				StatusCode = 500,
				Content = messageTitle + errDetail,
				ContentType = "text/plain"
			};
		}

		protected IActionResult ErrorView(string errorMessage = null, Exception error = null)
		{
			return View("~/Views/Shared/Error.cshtml", new Models.ErrorViewModel
			{
				RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier,
				//ErrorMessage = errorMessage + (error != null ? " > Hata Detayı : " + error.Message : "")
			});
		}

        //protected JsonResult MetroTableDataResult(MtSource tableData)
        //{
        //	tableData.Validate();
        //	return Json(tableData, m_JsonOptions);
        //}

        //protected int? GetUserID()
        //{
        //	if (User == null || User.Identity == null) return null;

        //	string userIdStr = User.FindFirst(Names.ClaimUserID).Value;
        //	if (int.TryParse(userIdStr, out int userID))
        //	{
        //		return userID;
        //	}
        //	return null;
        //}

        protected User GetUserData()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                string userJson = User.FindFirst(Names.ClaimUserData).Value;
				return System.Text.Json.JsonSerializer.Deserialize<User>(userJson);
			}
            return null;
        }
	}
}
