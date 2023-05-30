using Microsoft.AspNetCore.Mvc;

namespace DeltaBall.Services
{
	public class HtmlResult : IActionResult
	{
		private string htmlCode;
		public HtmlResult(string html)
		{
			htmlCode = html;
		}

		public async Task ExecuteResultAsync(ActionContext context)
		{
			await context.HttpContext.Response.WriteAsync(htmlCode);
		}
	}
}
