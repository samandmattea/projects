using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneV2.Models.Data
{
    public class ContactForm
    {
        public int ContactFormId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime DateSent { get; set; }
    }
}
