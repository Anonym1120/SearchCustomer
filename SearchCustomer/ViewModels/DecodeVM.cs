using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.ViewModels
{
    public class DecodeVM
    {
        public string CUST_ID { get; set; }
        public string CUST_NM { get; set; }
        public string CUST_CITY { get; set; }
        public string CUST_DISTRICT { get; set; }
        public string CUST_VILIAGE { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string CUST_ADDRESS_Format { get { return $"{CUST_CITY} {CUST_DISTRICT} {CUST_ADDRESS}"; } }
        public string REP_NM { get; set; }
        public string ACCT_NO { get; set; }
        public string ACCT_CUST_ID { get; set; }
        public string ACCT_NM { get; set; }
        public string ACCT_CYCLE { get; set; }
        public string ACCT_CITY { get; set; }
        public string ACCT_DISTRICT { get; set; }
        public string ACCT_VILIAGE { get; set; }
        public string ACCT_ADDRESS { get; set; }
        public string CONTACT_NM { get; set; }
        public string CONTACT_AREA_CD { get; set; }
        public string CONTACT_TEL { get; set; }
        public string CONTACT_TEL_EXT { get; set; }
        public string EMAIL { get; set; }
        public string AGENT_NM { get; set; }
        public string AGENT_TEL { get; set; }
        public string AGENT_CITY { get; set; }
        public string AGENT_DISTRICT { get; set; }
        public string AGENT_VILIAGE { get; set; }
        public string AGENT_ADDRESS { get; set; }
        public string ERROR_MSG { get; set; }
        public bool IsDecode { get; set; }

    }
}