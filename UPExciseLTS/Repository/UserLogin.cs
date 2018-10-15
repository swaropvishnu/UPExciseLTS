using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UPExciseLTS.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace UPExciseLTS.Repository
{
    public class UserLogin: IUserLogin
    {
      
        public List<BOLogin> VerifyUser(string Username, int RoleId)
        {
            try {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString()))
                {
                    var par = new DynamicParameters();
                    par.Add("@SpType", 1);
                    par.Add("@UserName",Username);
                    if (RoleId == 6)
                        return con.Query<BOLogin>("Usp_Applicantlogin", par, null, true, 0, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    else
                        return con.Query<BOLogin>("Usp_Userlogin", par, null, true, 0, commandType: System.Data.CommandType.StoredProcedure).ToList();


                    return null;

                }



            }
            catch (Exception ex)
            {
                throw;
            }
            finally {



            }
        }


        public int ResetPassword(BOLogin ob)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                var para = new DynamicParameters();
                para.Add("@UserName", ob.UserName);
                para.Add("@Password", ob.NewPassword);
                para.Add("@Sptype", 2);

                para.Add("@pOutPut", dbType: DbType.Int32, direction: ParameterDirection.Output);






                if (ob.RoleId == 6)//Public
                    con.Execute("Usp_Applicantlogin", para, null, 0, CommandType.StoredProcedure);
                //  return con.Query<BOLogin>("Usp_Applicantlogin", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
                else
                    con.Execute("Usp_Userlogin", para, null, 0, CommandType.StoredProcedure);
                //return con.Query<BOLogin>("Usp_Userlogin", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();


                int MemID = para.Get<int>("@pOutPut");
                return MemID;
            }
        }


        #region ForgotPassword
        public IEnumerable<ForgotRegistration> ForgotRegistration_Password(ForgotRegistration obj)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                try
                {
                    var para = new DynamicParameters();
                    para.Add("@SpType", 1);
                    para.Add("@dateOfBirth", obj.DateOfBirth);
                    para.Add("@mobile", obj.MobileNo);
                    para.Add("@aadhar", obj.AadharNo);
                    return con.Query<ForgotRegistration>("Proc_ForgotPassword_RegistrationNo", para, null, true, 0, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public IEnumerable<ForgotRegistration> Change_Password(ForgotRegistration obj)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                try
                {
                    var para = new DynamicParameters();
                    para.Add("@SpType", 2);
                    para.Add("@dateOfBirth", obj.DateOfBirth);
                    para.Add("@mobile", obj.MobileNo);
                    para.Add("@aadhar", obj.AadharNo);
                    return con.Query<ForgotRegistration>("Proc_ForgotPassword_RegistrationNo", para, null, true, 0, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
        }
        #endregion

    }
}