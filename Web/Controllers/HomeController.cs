﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuranX.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult About()
		{
			ViewBag.HideChapterVerseQuickJump = true;
			return View();
		}

	}
}
