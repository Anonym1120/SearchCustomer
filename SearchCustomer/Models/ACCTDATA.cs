using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.Models
{
    public class ACCTDATA
    {
        public string ACCT_NO { get; set; }
        public string CUST_ID { get; set; }
        public string CUST_TYPE { get; set; }
        public string LICENSE_NUM { get; set; }
        public string REP_NM { get; set; }
        public string ACCT_CUST_ID { get; set; }
        public string ACCT_NM { get; set; }
        public string ACCT_ADDR_IND { get; set; }
        public string ACCT_CITY { get; set; }
        public string ACCT_DISTRICT { get; set; }
        public string ACCT_VILIAGE { get; set; }
        public string ACCT_ADDRESS { get; set; }
        public string CONTACT_NM { get; set; }
        public string CONTACT_AREA_CD { get; set; }
        public string CONTACT_TEL { get; set; }
        public string CONTACT_TEL_EXT { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string CUST_LVL { get; set; }
        public string ORD_INST_CD { get; set; }
        public string ACCT_CYCLE { get; set; }
        public string TAXFREE_CARDNUM { get; set; }
        public Nullable<System.DateTime> TAXFREE_END_DT { get; set; }
        public string APCARRIERCODE { get; set; }
        public string AGENT_COLL { get; set; }
        public string APACCTNO { get; set; }
        public string AGENT_NM { get; set; }
        public string AGENT_CITY { get; set; }
        public string AGENT_DISTRICT { get; set; }
        public string AGENT_VILIAGE { get; set; }
        public string AGENT_ADDRESS { get; set; }
        public string AGENT_TEL { get; set; }
        public string AGENT_FAX { get; set; }
        public string CREATE_EMP_ID { get; set; }
        public string UPDATE_EMP_ID { get; set; }
        public System.DateTime CREATE_DT { get; set; }
        public System.DateTime UPDATE_DT { get; set; }
    }
}