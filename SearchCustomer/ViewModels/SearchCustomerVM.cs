using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchCustomer.ViewModels
{
    public class SearchCustomerVM
    {
        [StringLength(10)]
        public string CUST_ID { get; set; }

        [Phone]
        public string CONTACT_TEL { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string EQUIP_NBR { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public string SIMCARDNO { get; set; }
    }
}