using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Threading.Tasks;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Areas.Identity.Pages.Account.Manage
{
    public class APIRequestModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        public string APIUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string MethodName { get; set; }
            public string RequestUrl { get; set; }
            public string RequestBody { get; set; }
            public string ResponseBody { get; set; }
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (Request.Form["method"].ToString().ToLower() == RestSharp.Method.Post.ToString().ToLower())
            {
                UserCreation();
            }
            else
            {
                string requestURI = Request.Form["url"];
                var client = new RestClient(requestURI);
                var request = new RestRequest(Request.Form["method"].ToString());
                RestResponse response = client.Execute(request);
                if (response != null)
                    Input.ResponseBody = response.Content;

                if (!string.IsNullOrEmpty(requestURI))
                    Input.RequestUrl = requestURI;

                if(!string.IsNullOrEmpty(Request.Form["method"]))
                    Input.MethodName = Request.Form["method"];

                Input.RequestBody = string.Empty;
            }
        }

        public void UserCreation()
        {
            string requestURI = Request.Form["url"];
            string requestBody = Request.Form["requestbody"];
            var client = new RestClient(requestURI);
            var request = new RestRequest(RestSharp.Method.Post.ToString());
            request.AddBody(requestBody);
            RestResponse response = client.ExecutePost(request);

            if (response != null)
                Input.ResponseBody = response.Content;

            if (!string.IsNullOrEmpty(requestBody))
                Input.RequestBody = requestBody;

            if (!string.IsNullOrEmpty(requestURI))
                Input.RequestUrl = requestURI;

            if (!string.IsNullOrEmpty(Request.Form["method"]))
                Input.MethodName = Request.Form["method"];
        }
    }
}
