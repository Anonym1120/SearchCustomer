using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.ViewModels
{
    public class DeviceVM
    {
        public string CARI_CD { get; set; }
        public string ITM_NM { get; set; }
        public string CARI_CD_Format { get { return $"{CARI_CD} {ITM_NM}"; } }
        public string SVC_CD { get; set; }
        public string SVC_NM { get; set; }
        public string SVC_CD_Format { get { return $"{SVC_CD} {SVC_NM}"; } }
        public string EQUIP_NBR { get; set; }
        public decimal EQUIP_PPID { get; set; }
        public string PPDESC { get; set; }
        public string EQUIP_PPID_Format { get { return $"{EQUIP_PPID} {PPDESC}"; } }
        public string ACCT_NUM { get; set; }
        public System.DateTime START_DT { get; set; }
        public Nullable<System.DateTime> END_DT { get; set; }
        public string START_DT_Format { get; set; }
        public string END_DT_Format { get; set; }
        public string ACCT_NO { get; set; }
        public int INDEX { get; set; }
    }
}