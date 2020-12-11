using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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
            toastify.Warning("Hello Mukesh", 3);
            toastify.Information("Hello Mukesh", 2);
            toastify.Custom("Hello Mukesh", 2);
            toastify.Success("Hello Mukesh", 4);
            toastify.Success("Lorem of Lorem Ipsum.", 5);
            
        }
    }
}
