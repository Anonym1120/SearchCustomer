using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.ViewModels
{
    public class AcctVM
    {
        public string ACCT_NO { get; set; }
        public string ACCT_CUST_ID { get; set; }
        public string ACCT_NM { get; set; }
        public string ACCT_CITY { get; set; }
        public string ACCT_DISTRICT { get; set; }
        public string ACCT_VILIAGE { get; set; }
        public string ACCT_ADDRESS { get; set; }
        public string ACCT_ADDRESS_Format { get { return $" {ACCT_CITY} {ACCT_DISTRICT} {ACCT_VILIAGE} {ACCT_ADDRESS} "; } }
        public string ACCT_CYCLE { get; set; }
    }
}