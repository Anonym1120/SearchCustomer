using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.Models
{
    public class VW_IBMS_ACCT_RNTL
    {
        public string CARI_CD { get; set; }
        public string CURCY_CD { get; set; }
        public Nullable<decimal> CHRGAMT { get; set; }
        public int PPID { get; set; }
        public string PPDESC { get; set; }
    }
}