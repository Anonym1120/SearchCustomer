using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCustomer.ViewModels
{
    public class ErrorMessageVM
    {
        //驗證錯誤的訊息
        public string SYSMSG_CD_ITM_NM { get; set; }

        //申請處理事項
        public string APPL_PROC_CD { get; set; }

        //身份證驗證失敗
        public string ERRORMSG { get; set; }

        //欄位驗證失敗
        public string ModelStateMSG { get; set; }

        public bool IsModelState { get; set; }
    }
}