using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using models;
using models.Data;

namespace dartswebsite.Pages
{
    public class ApiModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public void OnGet()
        {

        }

    }
}
