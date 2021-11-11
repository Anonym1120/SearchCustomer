using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.Models
{
    public class EQUIP
    {
        public string ACCT_NO { get; set; }
        public string EQUIP_NBR { get; set; }
        public string SIMCARDNO { get; set; }
        public string CARI_CD { get; set; }
        public string INST_CD { get; set; }
        public string OFFICE_CD { get; set; }
        public System.DateTime START_DT { get; set; }
        public Nullable<System.DateTime> END_DT { get; set; }
        public string EQUIP_USE_ST { get; set; }
        public string RENT_FLAG { get; set; }
        public int EQUIP_PPID { get; set; }
        public Nullable<decimal> RNTL_AMT { get; set; }
        public Nullable<decimal> COST_AMT { get; set; }
        public string RNTL_CURCY_CD { get; set; }
        public Nullable<System.DateTime> SETUP_DT { get; set; }
        public string PROHIBITCDR { get; set; }
        public string ACCT_INST_CD { get; set; }
        public string ACCT_NUM { get; set; }
        public string ANSBACK { get; set; }
        public string BARRING { get; set; }
        public string SVC_CD { get; set; }
        public string SVC_RNTL_CD { get; set; }
        public string RNTL_CD { get; set; }
        public Nullable<System.DateTime> RNTL_BEG_DT { get; set; }
        public string SVC_EQUIP_TYPE { get; set; }
        public string DLVY_LOC_FLAG { get; set; }
        public string DLVY_CITY { get; set; }
        public string DLVY_DISTRICT { get; set; }
        public string DLVY_VILIAGE { get; set; }
        public string DLVY_ADDRESS { get; set; }
        public string SETUP_LOC_CHN { get; set; }
        public string SETUP_LOC_ENG { get; set; }
        public string MEMO { get; set; }
        public string REMIT_NUM { get; set; }
        public string PO_NUM { get; set; }
        public string SVC_CNTR_ID { get; set; }
        public string CNTRCT_ID { get; set; }
        public string EMP_ID { get; set; }
        public string CREATE_EMP_ID { get; set; }
        public string UPDATE_EMP_ID { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public Nullable<System.DateTime> UPDATE_DT { get; set; }
    }
}