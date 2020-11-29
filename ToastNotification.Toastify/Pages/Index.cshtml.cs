using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToastNotification.Toastify.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IToastifyService toastify;

        public IndexModel(ILogger<IndexModel> logger, IToastifyService toastify)
        {
            _logger = logger;
            this.toastify = toastify;
        }

        public void OnGet()
        {
            toastify.Error("Hello Mukesh");
            toastify.Warning("Hello Mukesh", 10);
            toastify.Information("Hello Mukesh", 10);
            toastify.Custom("Hello Mukesh", 10);
            toastify.Success("Hello Mukesh", 10);
            toastify.Success("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", 10);
            
        }
    }
}
