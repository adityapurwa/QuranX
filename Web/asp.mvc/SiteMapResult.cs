﻿using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace System.Web.Mvc
{
	public class SiteMapResult : ActionResult
	{
		List<string> Urls;

		public SiteMapResult(IEnumerable<string> urls)
		{
			this.Urls = new List<string>(urls);
		}

		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Clear();
			context.HttpContext.Response.ContentType = "text/xml";
			var builder = new StringBuilder();
			builder.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
			builder.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");
			foreach (string url in Urls)
			{
				builder.AppendLine("<url>");
				builder.AppendLine("  <loc>" + url + "</loc>");
				builder.AppendLine("</url>");
			}
			builder.AppendLine("</urlset>");
			string response = builder.ToString();
			context.HttpContext.Response.Write(response);
			context.HttpContext.Response.End();
		}
	}
}