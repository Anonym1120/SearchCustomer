using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.ViewModels
{
    public class AcctDetailVM
    {
        public string CUST_TYPE { get; set; }
        public string CUST_TYPE_NM { get; set; }
        public string CUST_TYPE_Format { get { return $"{CUST_TYPE} {CUST_TYPE_NM}"; } }
        public string LICENSE_NUM { get; set; }
        public string SELL_IND { get; set; }
        public string REP_NM { get; set; }
        public string CUST_LVL { get; set; }
        public string CUSTLVL_NM { get; set; }
        public string CUST_LVL_Format { get { return $"{CUST_LVL} {CUSTLVL_NM}"; } }
        public string ACCT_CUST_ID { get; set; }
        public string ACCT_NM { get; set; }
        public string ACCT_CITY { get; set; }
        public string ACCT_DISTRICT { get; set; }
        public string ACCT_VILIAGE { get; set; }
        public string ACCT_ADDRESS { get; set; }
        public string ACCT_ADDRESS_Fromat { get { return $"{ACCT_CITY} {ACCT_DISTRICT} {ACCT_VILIAGE} {ACCT_ADDRESS}"; } }
        public string CONTACT_NM { get; set; }
        public string CONTACT_AREA_CD { get; set; }
        public string CONTACT_TEL { get; set; }
        public string CONTACT_TEL_EXT { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string ORD_INST_CD { get; set; }
        public string INST_CD_NM { get; set; }
        public string ORD_INST_CD_Format { get { return $"{ORD_INST_CD} {INST_CD_NM}"; } }
        public string INST_NM { get; set; }
        public string ACCT_CYCLE { get; set; }
        public string TAXFREE_CARDNUM { get; set; }
        public Nullable<System.DateTime> TAXFREE_END_DT { get; set; }
        public string TAXFREE_END_DT_Format { get; set; }
        public System.DateTime START_DT { get; set; }
        public string START_DT_Format { get; set; }
        public string AGENT_NM { get; set; }
        public string AGENT_TEL { get; set; }
        public string AGENT_CITY { get; set; }
        public string AGENT_DISTRICT { get; set; }
        public string AGENT_VILIAGE { get; set; }
        public string AGENT_ADDRESS { get; set; }
        public string AGENT_ADDRESS_Formet { get { return $"{AGENT_CITY} {AGENT_DISTRICT} {AGENT_VILIAGE} {AGENT_ADDRESS}"; } }
        public string ACCT_ADDR_IND { get; set; }
        public string ACCT_NO { get; set; }
    }
}