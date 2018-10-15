using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPExciseLTS.Models;
using UPExciseLTS.Repository;
using System.Web.Security;
using System.Data;
using System.Security.Cryptography;
using System.Security.Principal;


namespace UPExciseLTS.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        //IDashboard objDash;
        IUserLogin ObjUserLogin;
        //IProfile objprofile;
        //IApplicant objDAL;
        //SMS objSend = new SMS();
        public LoginController()
        {
            //objDash = new Dashboard();
            //objprofile = new Profile();
            //objDAL = new Applicant();
            ObjUserLogin = new UserLogin();
        }

        #region CSRF

        public static bool ChkValidRequest()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables.ToString()))
            {
                return false;
            }

            string DomainURI = null;
            DomainURI = System.Web.HttpContext.Current.Request.ServerVariables.ToString();
            if ((DomainURI.IndexOf("10.135.")) != -1 | (DomainURI.IndexOf("//localhost")) != -1 | (DomainURI.IndexOf("upexciseelottery.gov.in")) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
        #region LoginWork

        [HttpGet]
        public ActionResult Login()
        {
            Crypto crp = new Crypto();

            if (Request.QueryString["redirectto"] != null)

                Session["redirectto"] = crp.Decrypt(Request.QueryString["redirectto"].ToString());

            string salt = CreateSalt(5);

            Session["salt"] = salt.ToString();

            return PartialView("~/Views/Login/_Login.cshtml");
        }
        [HttpPost]
        public ActionResult Login(BOLogin objdata)
        {
            objdata.RoleId = 6;
            // Session["CAPTCHA"].ToString();
            ObjUserLogin = new UserLogin();
            if (Session["CAPTCHA"] != null)
            {

                if (Session["CAPTCHA"].ToString().ToLower().Equals(objdata.clientCaptcha.ToLower()))
                {
                    var Userdtl = ObjUserLogin.VerifyUser(objdata.UserName, objdata.RoleId).FirstOrDefault();


                    if (Userdtl != null)
                    //if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count == 1)
                    {
                        string psw = Userdtl.Password;
                        ViewData["attempts"] = Userdtl.LoginAttempts;
                        string hashed_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(psw.ToString().ToLower() + Session["salt"].ToString(), "md5");
                        // macth the both passwords
                        if (hashed_pwd.ToString().ToLower().Equals(objdata.Password.ToLower()))
                        {
                            if (Convert.ToInt32(Userdtl.Userlock) == 0)
                            {
                                if (Convert.ToInt32(ViewData["attempts"]) <= 10)
                                {
                                    Session["tbl_Session"] = Userdtl;

                                    // Getting New Guid
                                    string guid = Convert.ToString(Guid.NewGuid());
                                    //Storing new Guid in Session
                                    Session["AuthenticationToken"] = guid;
                                    //Adding Cookie in Browser
                                    Response.Cookies.Add(new HttpCookie("AuthenticationToken", guid));


                                    //  SecurityImp objsecurityimp = new SecurityImp();

                                    //Session["__Token"] = objsecurityimp.GetMD5(objsecurityimp.GetRandomNo());

                                    //var t = Session["__Token"];
                                    //Response.Cookies.Add(new HttpCookie("__Token", Session["__Token"].ToString()));
                                    ////////////////////////////////////////////////////////////////////////////////////////////////
                                    //string mac_name = System.Environment.MachineName.ToString();
                                    // string mc_ip = Request.UserHostAddress.ToString();
                                    // string mac_client = Request.UserHostName.ToString();


                                    // string guid = Guid.NewGuid().ToString();
                                    //string tokensession = mac_name + "~" + mc_ip + "~" + ds.Tables[0].Rows[0]["UserName"].ToString() + "~" + DateTime.Now + "~" + guid;
                                    //
                                    // Session["AuthToken"] = guid;
                                    //HttpCookie authc = new HttpCookie("AuthToken", guid);
                                    // authc.Expires = DateTime.Now.AddDays(1);
                                    //Response.Cookies.Add(authc);

                                    //Session["SessionToken"] = tokensession;
                                    //HttpCookie sessc = new HttpCookie("SessionToken", tokensession);
                                    //sessc.Expires = DateTime.Now.AddDays(1);
                                    //Response.Cookies.Add(sessc);

                                    ////////////////////////////////////////////////////////////////////////////////////////////////


                                    //  int res = objbl.UserLastloginchange(objdata.UserName, PageName, IPAddress, tokensession);

                                    //int res = DataAccessLayer.UserLastloginchange(objdata.UserName, PageName, IPAddress, tokensession);


                                    //if (ds.Tables[0].Rows[0]["Last_Pwd_Change"].ToString()=="")
                                    //{

                                    if (String.IsNullOrEmpty(Userdtl.LastlPasswordChangeDate))
                                    {
                                        TempData["FisrtLogin"] = new BOLogin();
                                        //return RedirectToAction("ResetPassword", "Login");
                                        var redirectUrl = "/Login/ResetPassword";
                                        return Json(new { success = true, url = redirectUrl }, JsonRequestBehavior.AllowGet);
                                    }
                                    else
                                    {
                                        var redirectUrl = "/Home/Dashboard";
                                        //UserDashBoard objDashData = new UserDashBoard();
                                        //objDashData = objDash.GetPublishShops();
                                        if (UserSession.LoggedInUserRole == 6)
                                            return Json(new{success = true, url= redirectUrl},JsonRequestBehavior.AllowGet);
                                        //else if (UserSession.LoggedInUserRole == 3)
                                        //    return RedirectToAction("DistrictDashBoard", "DashBoard");
                                        //else if (UserSession.LoggedInUserRole == 1)
                                        //    return RedirectToAction("AdminDashBoard", "DashBoard");
                                        //else if (UserSession.LoggedInUserRole == 2)
                                        //    return RedirectToAction("AdminDashBoard", "DashBoard");
                                        // return View("~/Views/Home/ApplicationDashBoard.cshtml", objDashData);
                                    }
                                }

                                else
                                {
                                 
                                    //Response.Write("<script>RefreshCaptcha();</script>");
                                    //Response.Write("<script>alert('Your account is temporarily locked.Please try after some time');</script>");
                                    //var redirectUrl = "/Login/ResetPassword";
                                    return Json(new { success = true, msg = "Your account is temporarily locked.Please try after some time" }, JsonRequestBehavior.AllowGet);

                                }
                            }
                            else
                            {
                                //txtUserName.Text = "";
                                //txtPassword.Text = "";
                                //Response.Write("<script>RefreshCaptcha();</script>");
                                //Response.Write("<script>alert('Your account is locked for Some Time');</script>");
                                return Json(new { success = true, msg = "Your account is locked for Some Time" }, JsonRequestBehavior.AllowGet);
                                //lnkbtnforChangeCap_Click();

                            }
                        }
                        else
                        {
                            //ViewData["attempts"] = Convert.ToInt32(ViewData["attempts"]) + 1;
                            //Response.Write("<script>RefreshCaptcha();</script>");
                            //Response.Write("<script>alert('Invalid Username or Password');</script>");
                            var redirectUrl = "/Login/ResetPassword";
                            return Json(new { success = true, url = redirectUrl }, JsonRequestBehavior.AllowGet);
                            //lnkbtnforChangeCap_Click();
                        }
                    }
                    else
                    {
                        //Response.Write("<script>RefreshCaptcha();</script>");
                        //Response.Write("<script>alert('Invalid Username or Password');</script>");
                        return Json(new { success = true, msg = "Invalid Username or Password" }, JsonRequestBehavior.AllowGet);
                        // lnkbtnforChangeCap_Click();
                    }
                }
                else
                {
                   // ViewBag.Captcha = "Invalid Captcha";
                    return Json(new { success = true, msg = "Invalid Captcha" }, JsonRequestBehavior.AllowGet);
                }
            }

            else
            {
                //ViewBag.Captcha = "Kindly fill the Captcha";
                return Json(new { success = true, msg = "Kindly fill the Captcha" }, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        //     public string GetBaseUrl()
        //     {
        //         string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
        //Request.ApplicationPath.TrimEnd('/') + "/";
        //         return 
        //     }


        //public static string GetSiteUrl()
        //{
        //    string url = string.Empty;
        //    HttpRequest request = HttpContext.Current.Request;

        //    if (request.IsSecureConnection)
        //        url = "https://";
        //    else
        //        url = "http://";

        //    url += request["HTTP_HOST"] + "/";

        //    return url;
        //}


        #endregion

        #region InitChnage
        [HttpGet]
        public ActionResult ResetPassword()
        {
            BOLogin std = new BOLogin();
            if (UserSession.LoggedInUserRole == 6)
                std.UserName = UserSession.LoggedInUserId.ToString();
            else
                std.UserName = UserSession.LoggedInUserName.ToString();
            //std.TypeOfUser = UserSession.LoggedUserType;
            std.RoleId = UserSession.LoggedInUserRole;
            string salt = CreateSalt(5);
            Session["salt"] = salt.ToString();
            return View(std);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(BOLogin ob)
        {
            ObjUserLogin = new UserLogin();

            var Userdtl = ObjUserLogin.VerifyUser(ob.UserName, ob.RoleId).FirstOrDefault();
            if (Userdtl != null)
            //if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count == 1)
            {
                string psw = Userdtl.Password;
                ViewData["attempts"] = Userdtl.LoginAttempts;
                string hashed_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(psw.ToString().ToLower() + Session["salt"].ToString(), "md5");
                // macth the both passwords
                if (hashed_pwd.ToString().ToLower().Equals(ob.OldPassword.ToLower()))
                {

                    //string PasswordPattern = @"^(?=.*[0-9])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*0-9]{10,}$";



                    //if (!Regex.IsMatch(ob.ConFirmPassword, PasswordPattern))
                    //{
                    //    ViewBag.msg = "Please Be sure that you have fulfilled all the password policy.";
                    //    //return Task.FromResult(IdentityResult.Failed(String.Format("The Password must have at least one numeric and one special character")));

                    //}

                    //else
                    //{

                    int i = ObjUserLogin.ResetPassword(ob);
                    if (i == 1)
                    {
                        ViewBag.msg = "Password Change successfully .... login with changed password !!";
                        //return Json(new { success = true, msg = "Password Change successfully....login with changed password !!" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return View(ob);
        }
        #endregion

        private string pageName;
        private string ipaddress;
        public string PageName
        {
            get
            {
                return System.IO.Path.GetFileName(
                       System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            } //eof get
            set { pageName = value; } //eof set
        } //eof property MyPageName

        public string IPAddress { get; set; }
        private string CreateSalt(int size) //Generate the salt via Randon Number Genertor cryptography
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }


        #region Profile

        //public ActionResult ViewProfile()
        //{
        //    Login objcls = new Models.Login();

        //    if (UserSession.LoggedInUserDistictId.ToString() != "")
        //    {
        //        objcls.DistrictID = UserSession.LoggedInUserDistictId.ToString();

        //    }

        //    if (UserSession.LoggedInUserRole.ToString() != "")
        //    {
        //        objcls.RoleId = UserSession.LoggedInUserRole.ToString();

        //    }


        //    DataTable objdt = objprofile.GetDetails(objcls);

        //    if (objdt != null && objdt.Rows.Count > 0)
        //    {

        //        objcls.DistrictName = objdt.Rows[0]["DisttName"].ToString();
        //        objcls.Name = objdt.Rows[0]["name"].ToString();
        //        objcls.Designation = objdt.Rows[0]["Designation"].ToString();
        //        objcls.MobileNo = objdt.Rows[0]["MobileNo"].ToString();

        //    }


        //    return View(objcls);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]

        //[AuthenticateUser]
        //public ActionResult ViewProfile(Models.Login objcls)
        //{
        //    ChkValidRequest();

        //    if (UserSession.LoggedInUserDistictId.ToString() != "")
        //    {
        //        objcls.DistrictID = UserSession.LoggedInUserDistictId.ToString();

        //    }

        //    if (UserSession.LoggedInUserRole.ToString() != "")
        //    {
        //        objcls.RoleId = UserSession.LoggedInUserRole.ToString();

        //    }

        //    string result = objprofile.UpdateDetails(objcls);

        //    if (result != null)
        //    {
        //        ViewBag.result = result;
        //    }


        //    return View(objcls);
        //}


        #endregion

        #region Logout

        //[HttpGet]
        //public ActionResult logout()
        //{
        //    if (Request.Cookies["ASP.NET_SessionId"] != null)
        //    {
        //        Request.Cookies["ASP.NET_SessionId"].Value = string.Empty;
        //        Request.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
        //    }

        //    if (Request.Cookies["AuthToken"] != null)
        //    {
        //        Request.Cookies["AuthToken"].Value = string.Empty;
        //        Request.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
        //    }
        //    if (Request.Cookies["AuthenticationToken"] != null)
        //    {
        //        Response.Cookies["AuthenticationToken"].Value = string.Empty;
        //        Response.Cookies["AuthenticationToken"].Expires = DateTime.Now.AddMonths(-10);
        //    }

        //    Session.Abandon();
        //    Session.Clear();
        //    Session.RemoveAll();

        //    System.Web.HttpContext.Current.Session.Abandon();

        //    System.Web.HttpContext.Current.Session.Clear();
        //    System.Web.HttpContext.Current.Session.Abandon();
        //    System.Web.HttpContext.Current.Session.RemoveAll();

        //    //Response.Redirect("~/home/home");
        //    return RedirectToAction("home", "home");


        //}


        public ActionResult LogOut()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();
                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();
                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                Session.Abandon(); // it will clear the session at the end of request
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                throw;
            }
            finally
            {
                Session.Abandon();
            }
        }





        #endregion


        #region ChangePassword

        [HttpGet]
        public ActionResult ChangePassword()
        {
            BOLogin std = new BOLogin();
            if (UserSession.LoggedInUserRole == 6)
                std.UserName = UserSession.LoggedInUserId.ToString();
            else
                std.UserName = UserSession.LoggedInUserName.ToString();
            //std.TypeOfUser = UserSession.LoggedUserType;
            std.RoleId = UserSession.LoggedInUserRole;
            string salt = CreateSalt(5);
            Session["salt"] = salt.ToString();
            return View(std);
        }
        [HttpPost]
        public ActionResult ChangePassword(BOLogin ob)
        {
            ObjUserLogin = new UserLogin();

            var Userdtl = ObjUserLogin.VerifyUser(ob.UserName, ob.RoleId).FirstOrDefault();
            if (Userdtl != null)
            //if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count == 1)
            {
                string psw = Userdtl.Password;
                ViewData["attempts"] = Userdtl.LoginAttempts;
                string hashed_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(psw.ToString().ToLower() + Session["salt"].ToString(), "md5");
                // macth the both passwords
                if (hashed_pwd.ToString().ToLower().Equals(ob.OldPassword.ToLower()))
                {
                    //int i = ObjUserLogin.InitChangePassword(ob);
                    //if (i == 1)
                    //{
                    //    ViewBag.msg = "Password Change successfully .... login with changed password !!";
                    //}

                }
            }
            return View(ob);
        }
        #endregion



        #region ForgotRegistrationNumber


        public ActionResult ForgotRegistration()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult ForgotRegistration(string Send, string otp, ForgotRegistration obj)
        //{
        //    ViewBag.ShowHidden = false;
        //    ViewBag.ShowOtp = null;
        //    ViewBag.WrongPhone = null;

        //    if (!String.IsNullOrEmpty(Send))
        //    {
        //        if (String.IsNullOrEmpty(obj.MobileNo.ToString()))
        //        {
        //            ViewBag.WrongPhone = "Please enter Mobile No.!";
        //        }
        //        else
        //        {
        //            DataTable dt = new DataTable();
        //            dt = objDAL.CheckMobExist(obj.MobileNo);
        //            if (dt.Rows.Count > 0)
        //            {
        //                if (Session["CAPTCHA"] != null)
        //                {
        //                    if (obj.Captcha != null)
        //                    {
        //                        if (Session["CAPTCHA"].ToString().ToLower().Equals(obj.Captcha.ToLower()))
        //                        {
        //                            if (TempData["hdncount"] == null)
        //                            {
        //                                TempData["hdncount"] = "0";
        //                            }
        //                            SMS objsms = new SMS();
        //                            Random random = new Random();
        //                            if (TempData["otp"] == null)
        //                            {
        //                                TempData["otp"] = Convert.ToString(random.Next(10000, 99999));
        //                                TempData.Keep("otp");

        //                                TempData["OtpMTime"] = DateTime.Now.ToString();
        //                            }
        //                            else
        //                            {

        //                            }

        //                            if (obj.MobileNo.Length == 10)
        //                            {
        //                                objsms.SendSMS(obj.MobileNo, " One Time Password(OTP) for Upexcise Allotement portal is " + TempData["otp"].ToString());
        //                                ViewBag.ShowOtp = 1;
        //                            }
        //                        }

        //                        else
        //                        {
        //                            ViewBag.WrongPhone = "Please enter valid Captcha !";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ViewBag.WrongPhone = "Please enter Captcha !";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ViewBag.WrongPhone = "This Mobile Number is not exist. / मोबाइल नंबर उपलब्ध नहीं है | ";
        //            }
        //        }
        //    }
        //    if (otp == "PROCEED")
        //    {
        //        if (obj.otpValue.Trim() == TempData["otp"].ToString().Trim()) //|| obj.otpValue.Trim() == "1234")
        //        {
        //            ViewBag.ShowHidden = true;
        //        }
        //        else
        //        {
        //            ViewBag.WrongPhone = "Please enter valid OTP!";
        //        }
        //    }

        //    if (obj.Chk == "1")
        //    {
        //        IEnumerable<ForgotRegistration> objReg = ObjUserLogin.ForgotRegistration_Password(obj);
        //        if (objReg != null && ((System.Collections.Generic.List<UpExcise.Models.ForgotRegistration>)objReg).Count > 0)
        //        {
        //            TempData["RegistrationCode"] = "Your Registration Number has been sent to your Mobile Number"; //+ objReg.FirstOrDefault().RegistrationCode;
        //            objSend.SendSMS(obj.MobileNo, "Your Registration Number is " + objReg.FirstOrDefault().RegistrationCode);
        //        }
        //        else
        //            TempData["RegistrationCode"] = "Your Request Can not be Processed";
        //    }
        //    // 2 = Forgot Password
        //    else if (obj.Chk == "2")
        //    {
        //        IEnumerable<ForgotRegistration> objReg = ObjUserLogin.Change_Password(obj);
        //        if (objReg != null && ((System.Collections.Generic.List<UpExcise.Models.ForgotRegistration>)objReg).Count > 0)
        //        {
        //            TempData["RegistrationCode"] = "Your New Password has been sent to your Mobile Number ";// +objReg.FirstOrDefault().Password;
        //            objSend.SendSMS(obj.MobileNo, "Your New Password is  " + objReg.FirstOrDefault().Password);
        //        }
        //        else
        //            TempData["RegistrationCode"] = "Your Request Can not be Processed";
        //    }
        //    return View();
        //}


        #endregion




        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

    }
}
