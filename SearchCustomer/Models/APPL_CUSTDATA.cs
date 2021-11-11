using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.Models
{
    public class APPL_CUSTDATA
    {
        public string APPL_NUM { get; set; }
        public string CUST_ID { get; set; }
        public string ADD_IND { get; set; }
        public string CUST_NM { get; set; }
        public string SELL_IND { get; set; }
        public string CUST_CITY { get; set; }
        public string CUST_DISTRICT { get; set; }
        public string CUST_VILIAGE { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string CREATE_EMP_ID { get; set; }
        public string UPDATE_EMP_ID { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public Nullable<System.DateTime> UPDATE_DT { get; set; }
    }
}