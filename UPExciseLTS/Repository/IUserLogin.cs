using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UPExciseLTS.Models;

namespace UPExciseLTS.Repository
{
    interface IUserLogin
    {
        List<BOLogin> VerifyUser(string Username, int RoleId);

        int ResetPassword(BOLogin Ob);



        #region ForgotPassword
        IEnumerable<ForgotRegistration> ForgotRegistration_Password(ForgotRegistration obj);

        IEnumerable<ForgotRegistration> Change_Password(ForgotRegistration obj);
        #endregion
    }
}