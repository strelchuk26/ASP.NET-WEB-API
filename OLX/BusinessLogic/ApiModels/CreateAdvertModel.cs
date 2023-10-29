using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiModels
{
    public class CreateAdvertModel
    {
        CultureInfo culture = new CultureInfo("uk-UA");
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public string UserId { get; set; }
        public byte[] ImageFile { get; set; }
        public string Description { get; set; }
        public string? Location { get; set; }
        public string Date => DateTime.Now.ToString("dd MMM", culture);
        public int? Price { get; set; }
    }
}
