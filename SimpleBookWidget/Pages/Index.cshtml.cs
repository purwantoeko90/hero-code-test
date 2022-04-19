using Booking.Services;
using Booking.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBookWidget.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IBookingServices _svc;

        public IndexModel(ILogger<IndexModel> logger, IBookingServices svc)
        {
            _logger = logger;
            _svc = svc;
        }

        public List<Product> productList { get; set; }
        public Product product { get; set; }
        public List<Schedule> schedulesList { get; set; }
        public bool hiddenSearch { get; set; }
        public bool hiddenBook { get; set; }
        public bool showSchedule { get; set; }
        public int currentProductId { get; set; }

        public void OnGet()
        {
            var res = _svc.getProducts();
            productList = res.Result;
            hiddenBook = true;
        }

        public void OnPostSearch()
        {
            var filter = Request.Form["txtSearch"].ToString();
            var result = _svc.getProducts();
            productList = filter == string.Empty ? result.Result : result.Result.Where(a => a.name.Contains(filter)).ToList();
        }

        public void OnPostBook()
        {
            var productId = Request.Form["id"].ToString();
            var id = Convert.ToInt16(productId);
            product = _svc.getProductById(id).Result;
            currentProductId = product.id;
            hiddenBook = false;
            hiddenSearch = true;
        }

        public void OnPostBack()
        {
            if (hiddenBook == true)
            {
                var productId = Convert.ToInt16(Request.Form["currentProductId"].ToString());
                product = _svc.getProductById(productId).Result;
                hiddenBook = false;
                hiddenSearch = true;
                showSchedule = false;
            }
            else if (hiddenBook == false)
            {
                hiddenBook = true;
                hiddenSearch = false;
                var res = _svc.getProducts();
                productList = res.Result;
            }
        }

        public void OnPostCheck()
        {
            var dtStart = Request.Form["dtStart"].ToString();
            var dtEnd = Request.Form["dtEnd"].ToString();
            var productId = Convert.ToInt16(Request.Form["productId"].ToString());
            currentProductId = productId;
            product = _svc.getProductById(productId).Result;
            schedulesList = _svc.getSchedule(productId, dtStart, dtEnd).Result;
            showSchedule = true;
            hiddenBook = false;
            hiddenSearch = true;
        }
    }
}
