using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace RazorPages.Pages
{
	public class LoginModel : PageModel
	{

		private IUserService _account;
		public LoginModel(IUserService account)
		{
			_account = account;
		}
		public string? LoginMessage { get; set; }
		public void OnPost()
		{
			string email = Request.Form["txtUsername"];
			string pass = Request.Form["txtPassword"];
			User? account = _account.GetUserByUsername(email);

			if (account != null && account.Password.Equals(pass))
			{
				int? roleId = account.Role_Id;
				if (roleId == 1 || roleId == 3)
				{
					HttpContext.Session.SetString("roleId", roleId.ToString());
					Response.Redirect("/AdminPage/Index");
				}
				else if(roleId == 2)
				{
                    HttpContext.Session.SetString("roleId", roleId.ToString());
                    Response.Redirect("/UserPage/Home");
                }
				else
				{
					LoginMessage = "Invalid email or password. Please try again.";
				}

			}
			else
			{
				LoginMessage = "Invalid email or password. Please try again.";
			}
		}
	}
}
