using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogicLayer.Repository
{
    public class UserRepository :IUserRepository
    {
        public UserRepository() {
        }
        public bool IsUserValid(User objUser)
        {
            bool IsValid = false;
            try
            {
                SqlParameter[] parameter = new SqlParameter[2];
                parameter[0] = new SqlParameter { ParameterName="@MOBILE", Value = objUser.MobileNumber };
                parameter[1] = new SqlParameter { ParameterName = "@PASSWORD", Value = objUser.Password };
                var dtUser = SqlHelper.GetTableFromSP("USP_VALIDATE_USER", parameter);
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    if (Convert.ToString(dtUser.Rows[0][0]) == "0")
                    {
                        IsValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //WRITE ERROR LOG
                LogManager.WriteLog(ex);
            }
            return IsValid;
        }

        public int RegisterUser(Registration objRegister)
        {
            int returnValue = 0;
            try
            {
                SqlParameter[] parameter = new SqlParameter[4];
                parameter[0] = new SqlParameter { ParameterName = "@MOBILE", Value = objRegister.MobileNumber };
                parameter[1] = new SqlParameter { ParameterName = "@PASSWORD", Value = objRegister.Password };
                parameter[2] = new SqlParameter { ParameterName = "@EMAIL", Value = objRegister.EmaillAddress};
                parameter[3] = new SqlParameter { ParameterName = "@NAME", Value = objRegister.FullName };
                DataTable dt = SqlHelper.GetTableFromSP("USP_REGISTER_USER", parameter);
                returnValue = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                //WRITE ERROR LOG
                LogManager.WriteLog(ex);
            }
            return returnValue;
        }

        public int UpdateAddressDetails(AddressDetails objAddress)
        {
            int returnValue = 0;
            try
            {
                SqlParameter[] parameter = new SqlParameter[8];
                parameter[0] = new SqlParameter { ParameterName = "@USR_ID", Value = objAddress.UserId };
                parameter[1] = new SqlParameter { ParameterName = "@BUILDING_NAME", Value = objAddress.Building_Name };
                parameter[2] = new SqlParameter { ParameterName = "@LOCALITY", Value = objAddress.Locality };
                parameter[3] = new SqlParameter { ParameterName = "@PINCODE", Value = objAddress.PinCode };
                parameter[4] = new SqlParameter { ParameterName = "@CITY", Value = objAddress.City };
                parameter[5] = new SqlParameter { ParameterName = "@STATE", Value = objAddress.State };
                parameter[6] = new SqlParameter { ParameterName = "@LANDMARK", Value = objAddress.Landmark };
                parameter[7] = new SqlParameter { ParameterName = "@ADDRESS_TYPE", Value = objAddress.AddressType };
                returnValue = SqlHelper.ExecuteNonQuery("USP_UPDATE_ADDRESS", parameter);
            }
            catch (Exception ex)
            {
                //WRITE ERROR LOG
                LogManager.WriteLog(ex);
            }
            return returnValue;
        }

        public int UpdateCompanyDetails(CompanyDetails objCompany)
        {
            int returnValue = 0;
            try
            {
                SqlParameter[] parameter = new SqlParameter[5];
                parameter[0] = new SqlParameter { ParameterName = "@USR_ID", Value = objCompany.UserId };
                parameter[1] = new SqlParameter { ParameterName = "@COMPANY_NAME", Value = objCompany.CompanyName };
                parameter[2] = new SqlParameter { ParameterName = "@GST_NO", Value = objCompany.GST_No };
                parameter[3] = new SqlParameter { ParameterName = "@CATEGORY", Value = objCompany.Category };
                parameter[4] = new SqlParameter { ParameterName = "@BUSINESS_TYPE", Value = objCompany.Businees_Type};
                returnValue = SqlHelper.ExecuteNonQuery("USP_INSERT_COMPANY_DETAILS", parameter);
            }
            catch (Exception ex)
            {
                //WRITE ERROR LOG
                LogManager.WriteLog(ex);
            }
            return returnValue;
        }
    }
}
