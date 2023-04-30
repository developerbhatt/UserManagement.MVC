using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Areas.Identity.Pages.Account.Manage
{
    public class APIRequestModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public string APIUrl { get; set; }

        public APIRequestModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string MethodName { get; set; }
            public string RequestUrl { get; set; }
            public string RequestBody { get; set; }
            public string ResponseBody { get; set; }
            public string ProcessType { get; set; }
            public string ProcessName { get; set; }
            public string SyncTimer { get; set; }
            public string sourceField { get; set; }
            public string destinationField { get; set; }
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

                if (!string.IsNullOrEmpty(Request.Form["method"]))
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

        public void SaveProcess([FromBody] SaveProcess saveProcess)
        {
            if (ModelState.IsValid)
            {
                if (saveProcess.RequestMethodType.ToUpper() == "POST")
                {
                    if (!string.IsNullOrEmpty(saveProcess.RequestBody))
                    {
                        _dbContext.SaveProcesses.Add(saveProcess);
                        _dbContext.SaveChanges();
                    }
                }
                else
                {
                    _dbContext.SaveProcesses.Add(saveProcess);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void OnPostSaveProcess([FromBody] SaveProcess saveProcess)
        {
            if (ModelState.IsValid)
            {
                if (saveProcess.RequestMethodType.ToUpper() == "POST")
                {
                    if (!string.IsNullOrEmpty(saveProcess.RequestBody))
                    {
                        _dbContext.SaveProcesses.Add(saveProcess);
                        _dbContext.SaveChanges();
                    }
                }
                else
                {
                    _dbContext.SaveProcesses.Add(saveProcess);
                    _dbContext.SaveChanges();
                }
            }
        }

        public async Task<IActionResult> OnPostCreateAsync([FromBody] SaveProcess saveProcess)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SaveProcesses"] = _dbContext.SaveProcesses.ToList();
                return Page();
            }

            if (saveProcess.RequestMethodType.ToUpper() == "POST")
            {
                if (!string.IsNullOrEmpty(saveProcess.RequestBody))
                {
                    _dbContext.SaveProcesses.Add(saveProcess);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                _dbContext.SaveProcesses.Add(saveProcess);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("/APIRequest");
        }

        public async Task<IActionResult> OnPostCreateProcessSettingAsync([FromBody] SaveProceeSettingDetailModel saveProceeSettingDetailModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SaveProceeSettingDetail"] = _dbContext.SaveProceeSettingDetailModels.ToList();
                return Page();
            }

            saveProceeSettingDetailModel.IDate = DateTime.Now;
            _dbContext.SaveProceeSettingDetailModels.Add(saveProceeSettingDetailModel);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/APIRequest");
        }

        public async Task<IActionResult> OnPostCreateSourceLoginAPIAsync([FromBody] SourceLoginAPIModel sourceLoginAPIModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SourceLoginAPIModel"] = _dbContext.SourceLoginAPIModels.ToList();
                return Page();
            }

            sourceLoginAPIModel.IDate = DateTime.Now;
            _dbContext.SourceLoginAPIModels.Add(sourceLoginAPIModel);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/APIRequest");
        }

        public async Task<IActionResult> OnPostCreateSourceDataAPIAsync([FromBody] SourceDataAPIModel sourceDataAPIModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SourceDataAPIModel"] = _dbContext.SourceDataAPIModels.ToList();
                return Page();
            }

            sourceDataAPIModel.IDate = DateTime.Now;
            _dbContext.SourceDataAPIModels.Add(sourceDataAPIModel);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/APIRequest");
        }

        public async Task<IActionResult> OnPostCreateDestinationLoginAPIAsync([FromBody] DestinationLoginAPIModel destinationLoginAPIModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DestinationLoginAPIModel"] = _dbContext.DestinationLoginAPIModels.ToList();
                return Page();
            }

            destinationLoginAPIModel.IDate = DateTime.Now;
            _dbContext.DestinationLoginAPIModels.Add(destinationLoginAPIModel);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/APIRequest");
        }

        public async Task<IActionResult> OnPostCreateDestinationDataAPIAsync([FromBody] DestinationDataAPIModel destinationDataAPIModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DestinationDataAPIModel"] = _dbContext.DestinationDataAPIModels.ToList();
                return Page();
            }

            destinationDataAPIModel.IDate = DateTime.Now;
            _dbContext.DestinationDataAPIModels.Add(destinationDataAPIModel);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/APIRequest");
        }
    }
}
