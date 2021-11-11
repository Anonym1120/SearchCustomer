using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchCustomer.Service;
using SearchCustomer.ViewModels;

namespace SearchCustomer.Controllers
{
    public class SearchCustomerController : Controller
    {
        private SearchCustomerService searchCustomerService = new SearchCustomerService();

        /// <summary>
        /// 解碼
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public JsonResult Decode(string verify) 
        {
            string CUST_ID = Session["CUST_ID"].ToString();
            string id = CUST_ID.Remove(0, 1).Substring(5, 4); //最後4碼

            List<DecodeVM> decodeData = searchCustomerService.getDecodeData(CUST_ID);

            if (id != verify)
            {
                foreach (var item in decodeData)
                {
                    item.IsDecode = false;
                }
                return Json(decodeData);
            }
            else 
            {
                Session["verify"] = verify;
                foreach (var item in decodeData) 
                {
                    item.IsDecode = true;
                }
                return Json(decodeData);
            }
        }

        /// <summary>
        /// 設備
        /// </summary>
        /// <param name="ACCT_NO"></param>
        /// <returns></returns>
        public JsonResult Device(string ACCT_NO) 
        {
            List<DeviceVM> device = searchCustomerService.getDevice(ACCT_NO);

            return Json(new { data = device });
        }

        /// <summary>
        /// 檢視功能的帳戶明細
        /// </summary>
        /// <param name="ACCT_NO"></param>
        /// <returns></returns>
        public JsonResult AccountDetail(string ACCT_NO) 
        {
            AcctDetailVM acctDetail = searchCustomerService.getAcctDetail(ACCT_NO);
            
            if (acctDetail.CUST_TYPE == "6" && Session["Verify"] == null) 
            {
                acctDetail = searchCustomerService.getHiddenAcctDetailCode(acctDetail);
            }

            return Json(acctDetail);
        }

        /// <summary>
        /// 帳戶
        /// </summary>
        /// <returns></returns>
        public JsonResult Account() 
        {
            if (Session["CUST_ID"] == null) 
            {
                return Json(null);
            }

            string CUST_ID = Session["CUST_ID"].ToString();
            List<AcctVM> acct = searchCustomerService.getAcct(CUST_ID);
            
            return Json(new { data = acct });
        }

        /// <summary>
        /// 查詢客戶資料
        /// </summary>
        /// <returns></returns>
        public JsonResult Customer(SearchCustomerVM p) 
        {
            CustomerDataVM customerData = searchCustomerService.getCustomerData(p);
            
            //驗證欄位
            string errorMSG = string.Empty;
            if (ModelState.IsValid == false || customerData == null)
            {
                ErrorMessageVM ErrorMessage = new ErrorMessageVM();
                ErrorMessage.SYSMSG_CD_ITM_NM = searchCustomerService.getErrorMessage(); //取得錯誤訊息
                ErrorMessage.IsModelState = false;
                ModelState.Values.Where(x => x.Errors.Count > 0).ToList().ForEach(x => x.Errors.ToList().ForEach(e => errorMSG += (e.ErrorMessage + "\n"))); //欄位驗證的錯誤訊息
                ErrorMessage.ModelStateMSG += errorMSG;
                
                return Json(ErrorMessage);
            }

            Session["CUST_ID"] = customerData.CUST_ID;

            customerData.APPL_NUM = searchCustomerService.getApplicationNumber(customerData.CUST_ID);

            //客戶分類 = 6 時，且未解碼則進行資料隱碼
            if (customerData.CUST_TYPE == "6" && Session["verify"] == null) 
            {
                customerData = searchCustomerService.getHiddenCustomerDataCode(customerData);
            }

            return Json(customerData);
        }

        /// <summary>
        /// 重新查詢的設定
        /// </summary>
        /// <returns></returns>
        public JsonResult SetReload()
        {
            Session["CUST_ID"] = null;
            Session["verify"] = null;

            return Json("OK");
        }

        /// <summary>
        /// 客戶查詢畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchCustomer() 
        {
            Session["CUST_ID"] = null;

            return View();
        }
        // GET: SearchCustomer
        public ActionResult Index()
        {
            return View();
        }
    }
}