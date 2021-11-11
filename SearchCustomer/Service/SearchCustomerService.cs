using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchCustomer.Models;
using SearchCustomer.ViewModels;
using System.Configuration;
using System.Data.Odbc;
using Dapper;
using System.Text;
using System.Globalization;

namespace SearchCustomer.Service
{
    public class SearchCustomerService
    {
        private string connStr = ConfigurationManager.ConnectionStrings["tibero"].ConnectionString;

        /// <summary>
        /// 取得申請書號碼
        /// </summary>
        /// <param name="CUST_ID"></param>
        /// <returns></returns>
        public string getApplicationNumber(string CUST_ID) 
        {
            var sql = @"SELECT D.APPL_NUM 
                        FROM APPL_CUSTDATA D
                        WHERE D.CUST_ID = :cust_id";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add(name: ":cust_id", value: CUST_ID);
                var data = connection.QueryFirstOrDefault<APPL_CUSTDATA>(sql, parameters);

                if (data == null) 
                {
                    return null;
                }

                return data.APPL_NUM;
            }

        }

        /// <summary>
        /// 取得解碼後的資料
        /// </summary>
        /// <param name="CUST_ID"></param>
        /// <returns></returns>
        public List<DecodeVM> getDecodeData(string CUST_ID) 
        {
            var sql = @"SELECT A.CUST_ID,
                               A.CUST_NM,
                               A.CUST_CITY,
                               A.CUST_DISTRICT,
                               A.CUST_VILIAGE,
                               A.CUST_ADDRESS,
                               A1.REP_NM,
                               A1.ACCT_NO,
                               A1.ACCT_CUST_ID,
                               A1.ACCT_NM,
                               A1.ACCT_CYCLE,
                               A1.ACCT_CITY,
                               A1.ACCT_DISTRICT,
                               A1.ACCT_VILIAGE,
                               A1.ACCT_ADDRESS,
                               A1.CONTACT_NM,
                               A1.CONTACT_AREA_CD,
                               A1.CONTACT_TEL,
                               A1.CONTACT_TEL_EXT,
                               A1.EMAIL,
                               A1.AGENT_NM,
                               A1.AGENT_TEL,
                               A1.AGENT_CITY,
                               A1.AGENT_DISTRICT,
                               A1.AGENT_VILIAGE,
                               A1.AGENT_ADDRESS
                               FROM CUSTDATA A 
                               LEFT JOIN ACCTDATA A1 ON A.CUST_ID  = A1.CUST_ID
                               WHERE A.CUST_ID = :cust_id";

            var sql2 = @"SELECT I.ITM_NM
                         FROM RD_ITM_CDE_MAP I
                         WHERE I.CATE_NM = :cate_nm
                         AND I.ITM_CD = :itm_cd";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add(name: ":cust_id", value: CUST_ID);
                var data = connection.Query<DecodeVM>(sql, parameters).ToList();

                connection.Close();
                
                connection.Open();
                var parameters2 = new DynamicParameters();
                parameters2.Add(name: ":cate_nm", value: "Sysmsg_Cd");
                parameters2.Add(name: ":itm_cd", value: "ERR00051");
                var data2 = connection.QueryFirstOrDefault<RD_ITM_CDE_MAP>(sql2, parameters2);

                foreach (var item in data) 
                {
                    item.ERROR_MSG = data2.ITM_NM;
                }
                

                return data;
            }
        }

        /// <summary>
        /// 取得設備資料
        /// </summary>
        /// <param name="ACCT_NO"></param>
        /// <returns></returns>
        public List<DeviceVM> getDevice(string ACCT_NO) 
        {
            var sql = @"SELECT B.CARI_CD,
                               B.SVC_CD,
                               B.EQUIP_NBR,
                               B.EQUIP_PPID,
                               B.ACCT_NUM,
                               B.START_DT,
                               B.END_DT,
                               I.ITM_NM,
                               K.SVC_NM,
                               R.PPDESC
                               FROM EQUIP B 
                               LEFT JOIN RD_ITM_CDE_MAP I 
                               ON I.CATE_NM ='Cari_Cd' AND B.CARI_CD = I.ITM_CD 
                               LEFT JOIN RD_SVC_CD K 
                               ON B.CARI_CD = K.CARI_CD AND B.SVC_CD  = K.SVC_CD 
                               LEFT JOIN VW_IBMS_ACCT_RNTL R 
                               ON B.CARI_CD  = R.CARI_CD AND B.EQUIP_PPID  = R.PPID
                               WHERE B.ACCT_NO = :acct_no";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: ":acct_no", value: ACCT_NO);

                var data = connection.Query<DeviceVM>(sql, parameters).ToList();

                int index = 1;
                foreach (var item in data) 
                {
                    item.INDEX = index++;

                    if (item.START_DT != null) 
                    {
                        item.START_DT_Format = item.START_DT.ToString("yyyymmdd");
                    }
                    if (item.END_DT != null) 
                    {
                        item.END_DT_Format = item.END_DT.Value.ToString("yyyymmdd");
                    }
                }

                return data;
            }
        }

        /// <summary>
        /// 取得帳戶明細資料
        /// </summary>
        /// <param name="ACCT_NO"></param>
        /// <returns></returns>
        public AcctDetailVM getAcctDetail(string ACCT_NO) 
        {
            var sql = @"SELECT A.SELL_IND,
                        A.CUST_TYPE,
                        A1.LICENSE_NUM,
                        A1.REP_NM,
                        A1.CUST_LVL,
                        A1.ACCT_CUST_ID,
                        A1.ACCT_NM,
                        A1.ACCT_ADDR_IND,
                        A1.ACCT_CITY,
                        A1.ACCT_DISTRICT,
                        A1.ACCT_VILIAGE,
                        A1.ACCT_ADDRESS,
                        A1.CONTACT_NM,
                        A1.CONTACT_AREA_CD,
                        A1.CONTACT_TEL,
                        A1.CONTACT_TEL_EXT,
                        A1.EMAIL,
                        A1.FAX,
                        A1.ORD_INST_CD,
                        A1.ACCT_CYCLE,
                        A1.TAXFREE_CARDNUM,
                        A1.TAXFREE_END_DT,
                        A1.AGENT_NM,
                        A1.AGENT_TEL,
                        A1.AGENT_CITY,
                        A1.AGENT_DISTRICT,
                        A1.AGENT_VILIAGE,
                        A1.AGENT_ADDRESS
                        FROM CUSTDATA A
                        LEFT JOIN ACCTDATA A1 ON A.CUST_ID = A1.CUST_ID
                        WHERE A1.ACCT_NO = :acct_no";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: ":acct_no", value: ACCT_NO);

                var data = connection.QueryFirstOrDefault<AcctDetailVM>(sql, parameters);

                if (data.TAXFREE_END_DT != null) 
                {
                    data.TAXFREE_END_DT_Format = data.TAXFREE_END_DT.Value.ToString("yyyymmdd");
                }

                return data;
            }
        }

        /// <summary>
        /// 取得多筆帳戶資料
        /// </summary>
        /// <param name="CUST_ID"></param>
        /// <returns></returns>
        public List<AcctVM> getAcct(string CUST_ID) 
        {
            var sql = @"SELECT A1.ACCT_NO,
                        A1.ACCT_CUST_ID,
                        A1.ACCT_NM,
                        A1.ACCT_CITY,
                        A1.ACCT_DISTRICT,
                        A1.ACCT_VILIAGE,
                        A1.ACCT_ADDRESS,
                        A1.ACCT_CYCLE
                        FROM ACCTDATA A1
                        WHERE A1.CUST_ID = :cust_id";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: ":cust_id", value: CUST_ID);

                var data = connection.Query<AcctVM>(sql, parameters).ToList();

                return data;
            }
        }

        /// <summary>
        /// 取得查詢後的錯誤訊息
        /// </summary>
        /// <returns></returns>
        public string getErrorMessage() 
        {
            var sql = @"SELECT I.ITM_NM
                        FROM RD_ITM_CDE_MAP I
                        WHERE I.CATE_NM = :cate_nm AND I.ITM_CD = :itm_cd";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(name: ":cate_nm", value: "Sysmsg_Cd");
                parameters.Add(name: ":itm_cd", value: "WAR00002");

                var data = connection.QueryFirstOrDefault<RD_ITM_CDE_MAP>(sql, parameters);

                return data.ITM_NM;
            }
        }

        /// <summary>
        /// 取得查詢客戶後的資料
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public CustomerDataVM getCustomerData(SearchCustomerVM p) 
        {
            var sql = @"SELECT A.CUST_ID,
                        A.CUST_TYPE,
                        A.CUST_NM,
                        A.CUST_CITY,
                        A.CUST_DISTRICT,
                        A.CUST_VILIAGE,
                        A.CUST_ADDRESS,
                        A.SELL_IND,
                        A1.ACCT_NO,
                        A1.ACCT_ADDR_IND,
                        A1.CONTACT_TEL,
                        B.EQUIP_NBR,
                        B.SIMCARDNO
                        FROM CUSTDATA A
                        LEFT JOIN ACCTDATA A1
                        ON A.CUST_ID = A1.CUST_ID
                        LEFT JOIN EQUIP B
                        ON A1.ACCT_NO = B.ACCT_NO
                        WHERE (:cust_id IS NULL OR A.CUST_ID = :cust_id2) AND
                        (:equip_nbr IS NULL OR B.EQUIP_NBR = :equip_nbr2) AND
                        (:contact_tel IS NULL OR A1.CONTACT_TEL = :contact_tel2) AND
                        (:simcardno IS NULL OR B.SIMCARDNO = :simcardno2)";

            using (var connection = new OdbcConnection(connStr)) 
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(name: ":cust_id", value: p.CUST_ID);
                parameters.Add(name: ":cust_id2", value: p.CUST_ID);
                parameters.Add(name: ":equip_nbr", value: p.EQUIP_NBR);
                parameters.Add(name: ":equip_nbr2", value: p.EQUIP_NBR);
                parameters.Add(name: ":contact_tel", value: p.CONTACT_TEL);
                parameters.Add(name: ":contact_tel2", value: p.CONTACT_TEL);
                parameters.Add(name: ":simcardno", value: p.SIMCARDNO);
                parameters.Add(name: ":simcardno2", value: p.SIMCARDNO);

                var data = connection.QueryFirstOrDefault<CustomerDataVM>(sql, parameters);

                return data;
                
            }

        }

        /// <summary>
        /// 帳戶明細資料隱碼處理
        /// </summary>
        /// <param name="acctDetail"></param>
        /// <returns></returns>
        public AcctDetailVM getHiddenAcctDetailCode(AcctDetailVM acctDetail) 
        {
            if (acctDetail.REP_NM.Length == 2)
            {
                acctDetail.REP_NM = getHiddenProfileInfo(acctDetail.REP_NM, 1, 1, true);
            }
            else if (acctDetail.REP_NM.Length > 2)
            {
                acctDetail.REP_NM = getHiddenProfileInfo(acctDetail.REP_NM, 1, acctDetail.REP_NM.Length - 2, true);
            }

            acctDetail.CONTACT_TEL = getHiddenProfileInfo(acctDetail.CONTACT_TEL, 0, 3, true);

            if (acctDetail.EMAIL.Split('@')[0].Length > 3)
            {
                acctDetail.EMAIL = getHiddenProfileInfo(acctDetail.EMAIL, 0, 3, false);
            }

            if (!string.IsNullOrEmpty(acctDetail.ACCT_ADDRESS))
            {
                acctDetail.ACCT_ADDRESS = getHiddenProfileInfo(acctDetail.ACCT_ADDRESS, 0, acctDetail.ACCT_ADDRESS.Length, false);
            }

            if (acctDetail.CONTACT_NM.Length == 2)
            {
                acctDetail.CONTACT_NM = getHiddenProfileInfo(acctDetail.CONTACT_NM, 0, acctDetail.CONTACT_NM.Length - 1, false);
            }
            else if (acctDetail.CONTACT_NM.Length > 2)
            {
                acctDetail.CONTACT_NM = getHiddenProfileInfo(acctDetail.CONTACT_NM, 1, acctDetail.CONTACT_NM.Length - 2, false);
            }

            if (acctDetail.AGENT_NM.Length == 2)
            {
                acctDetail.AGENT_NM = getHiddenProfileInfo(acctDetail.AGENT_NM, 0, acctDetail.AGENT_NM.Length - 1, false);
            }
            else if (acctDetail.AGENT_NM.Length > 2)
            {
                acctDetail.AGENT_NM = getHiddenProfileInfo(acctDetail.AGENT_NM, 1, acctDetail.AGENT_NM.Length - 2, false);
            }

            if (!string.IsNullOrEmpty(acctDetail.AGENT_TEL))
            {
                acctDetail.AGENT_TEL = getHiddenProfileInfo(acctDetail.AGENT_TEL, 0, 3, true);
            }

            if (!string.IsNullOrEmpty(acctDetail.AGENT_VILIAGE))
            {
                acctDetail.AGENT_VILIAGE = getHiddenProfileInfo(acctDetail.AGENT_VILIAGE, 0, acctDetail.AGENT_VILIAGE.Length, false);
            }

            if (!string.IsNullOrEmpty(acctDetail.AGENT_ADDRESS))
            {
                acctDetail.AGENT_ADDRESS = getHiddenProfileInfo(acctDetail.AGENT_ADDRESS, 0, acctDetail.AGENT_ADDRESS.Length, false);
            }

            if (acctDetail.TAXFREE_END_DT != null)
            {
                DateTime taxenddt = DateTime.Parse(acctDetail.TAXFREE_END_DT.Value.ToString());
                acctDetail.TAXFREE_END_DT_Format = taxenddt.ToString("yyyy-MM-dd");

            }

            if (acctDetail.START_DT != null)
            {
                DateTime startdt = DateTime.Parse(acctDetail.START_DT.ToString());
                acctDetail.START_DT_Format = acctDetail.START_DT.ToString("yyyy-MM-dd");
            }

            return acctDetail;
        }

        /// <summary>
        /// 帳戶資料隱碼處理
        /// </summary>
        /// <param name="acctList"></param>
        /// <returns></returns>
        public List<AcctVM> getHiddenAcctCode(List<AcctVM> acctList)
        {
            if (acctList.Count > 0)
            {
                foreach (var item in acctList)
                {
                    item.ACCT_ADDRESS = getHiddenProfileInfo(item.ACCT_ADDRESS, 0, item.ACCT_ADDRESS.Length, false);
                }
            }

            return acctList;
        }

        /// <summary>
        /// 客戶資料隱碼處理
        /// </summary>
        /// <param name="customerData"></param>
        /// <returns></returns>
        public CustomerDataVM getHiddenCustomerDataCode(CustomerDataVM customerData) 
        {
            if (customerData != null)
            {
                customerData.CUST_ID = getHiddenProfileInfo(customerData.CUST_ID, 0, 3, true);

                if (customerData.CUST_NM.Length == 2)
                {
                    customerData.CUST_NM = getHiddenProfileInfo(customerData.CUST_NM, 1, 1, true);
                }
                else if (customerData.CUST_NM.Length > 2)
                {
                    customerData.CUST_NM = getHiddenProfileInfo(customerData.CUST_NM, 1, customerData.CUST_NM.Length - 2, true);
                }

                if (customerData.CUST_ADDRESS != null)
                {
                    if (customerData.ACCT_ADDR_IND == "Y")
                    {
                        customerData.CUST_ADDRESS = getHiddenProfileInfo(customerData.CUST_ADDRESS, 0, customerData.CUST_ADDRESS.Length, true);
                    }
                }
                else if (customerData.ACCT_ADDRESS != null)
                {
                    if (customerData.ACCT_ADDR_IND != "Y")
                    {
                        customerData.CUST_ADDRESS = getHiddenProfileInfo(customerData.CUST_ADDRESS, 0, customerData.CUST_ADDRESS.Length, true);
                    }
                }

            }

            return customerData;
        }

        /// <summary>
        /// 隱碼方法
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="bReverse"></param>
        /// <returns></returns>
        private string getHiddenProfileInfo(string inputData, int startIndex, int endIndex, bool bReverse)
        {
            string strResultData = inputData;
            //預計要隱碼的字元數
            int iCount = endIndex - startIndex + 1;
            string strRepeatData = string.Empty;
            int iRealLength = 0;

            try
            {
                //隱碼長度檢查
                if (string.IsNullOrEmpty(inputData))
                {
                    return strResultData;
                }

                //隱碼長度檢查
                if (inputData.Trim().Length == 0)
                {
                    return strResultData;
                }

                // Parse the string using the ParseCombiningCharacters method.
                int[] teIndices = StringInfo.ParseCombiningCharacters(inputData);
                iRealLength = teIndices.Length;//取得實際字數(Unicode)

                //隱碼長度檢查
                if (iRealLength < startIndex + 1)
                {
                    return strResultData;
                }
                else
                {
                    //算出可以隱碼的字元數
                    int iTempCount = iRealLength - startIndex;
                    if (iTempCount < iCount)
                    {
                        //實際隱碼結束位置
                        endIndex = endIndex - (iCount - iTempCount);
                    }
                }

                //實際可隱碼的字元數
                iCount = endIndex - startIndex + 1;
                //實際要產生隱碼的字元
                strRepeatData = "*";//new String('*', iCount);//改用一個一個取代

                //如要是否從後面起算則起始位置重新計算
                if (bReverse)
                {
                    startIndex = iRealLength - endIndex - 1;
                    endIndex = startIndex + iCount - 1;
                }

                // Get the Enumerator.
                TextElementEnumerator teEnum = null;
                // Parse the string with the GetTextElementEnumerator method.
                teEnum = StringInfo.GetTextElementEnumerator(inputData);//取得每個字(Unicode)的列舉

                StringBuilder sbResult = new StringBuilder();
                int teCount = -1;
                while (teEnum.MoveNext())
                {
                    teCount++;

                    //如果大於等於起始位置&小於等於結束位置就用隱碼字元取代
                    if (teCount >= startIndex && teCount <= endIndex)
                    {
                        sbResult.Append(strRepeatData);
                    }
                    else
                    {
                        sbResult.Append((string)(teEnum.Current));
                    }
                }
                strResultData = sbResult.ToString();
            }
            catch
            {
                //Any Error Return Original Data
            }

            return strResultData;
        }
    }
}