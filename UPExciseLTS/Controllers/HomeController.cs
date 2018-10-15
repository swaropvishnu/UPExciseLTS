using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPExciseLTS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }


        //CMYSS_Applicant CM = new CMYSS_Applicant();
        //// GET: Login
        //public ActionResult Login()
        //{

        //    string salt = CreateSalt(5);

        //    Session["salt"] = salt.ToString();
        //    return View();
        //}

        //public ActionResult LogOut()
        //{
        //    try
        //    {
        //        // First we clean the authentication ticket like always
        //        //required NameSpace: using System.Web.Security;
        //        FormsAuthentication.SignOut();
        //        // Second we clear the principal to ensure the user does not retain any authentication
        //        //required NameSpace: using System.Security.Principal;
        //        HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        //        Session.Clear();
        //        System.Web.HttpContext.Current.Session.RemoveAll();
        //        // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
        //        // this clears the Request.IsAuthenticated flag since this triggers a new request
        //        Session.Abandon(); // it will clear the session at the end of request
        //        return RedirectToAction("Login", "Login");
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        Session.Abandon();
        //    }
        //}
        ////
        //// POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Login(LoginModal Model)
        //{

        //    if (Model.CaptchaText == HttpContext.Session["captchastring"].ToString())
        //    {
        //        // Ensure we have a valid viewModel to work with
        //        //if (!ModelState.IsValid)
        //        //    return View(Model);
        //        string salt = CreateSalt(5);
        //        string usrname = Model.UserName;
        //        string password = Model.Password;
        //        DataSet ds = new DataSet();
        //        ds = UserDtl.VerifyUser(usrname);
        //        if (ds != null)
        //        {
        //            string psw = ds.Tables[0].Rows[0]["Password"].ToString();
        //            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count == 1)
        //            {

        //                string hashed_pwd = CalculateHash(psw.ToString().ToLower() + Session["salt"].ToString());
        //                if (hashed_pwd.ToString().ToLower().Equals(Model.Password.ToLower()))
        //                {
        //                    if (ds.Tables[0].Rows[0]["UserLevel"].ToString().Trim() == "6" || ds.Tables[0].Rows[0]["UserLevel"].ToString().Trim() == "3" || ds.Tables[0].Rows[0]["UserLevel"].ToString().Trim() == "5")
        //                    {
        //                        Session["tbl_Session"] = ds.Tables[0];
        //                        FormsAuthentication.SetAuthCookie(usrname, Model.RememberMe);
        //                        return RedirectToAction("Index", "Dashboard");
        //                    }
        //                    else
        //                    {
        //                        ViewBag.ErrMessage = "Invalid Username or Password.";
        //                        return RedirectToAction("Login", "Login");
        //                    }

        //                }
        //                else
        //                {
        //                    //Login Fail
        //                    TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
        //                    return View(Model);
        //                    //return RedirectToAction("Login", "Login");
        //                }
        //            }
        //            else
        //            {
        //                ViewBag.ErrMessage = "Invalid Username or Password.";
        //                return RedirectToAction("Login", "Login");
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.ErrMessage = "Invalid Username or Password.";
        //            return RedirectToAction("Login", "Login");
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.ErrMessage = "Error: captcha is not valid.";
        //        return RedirectToAction("Login", "Login");
        //    }
        //}
        //public CaptchaImageResult ShowCaptchaImage()
        //{
        //    return new CaptchaImageResult();
        //}
        ///// <summary>
        ///// 
        ///// 
        ///// </summary>
        ///// <param name="provider"></param>
        ///// <param name="returnUrl"></param>
        ///// <param name="rememberMe"></param>
        ///// <returns></returns>
        ///// 
        //#region --> Generate HASH Using SHA512

        //#endregion
        //private string CreateSalt(int size) //Generate the salt via Randon Number Genertor cryptography
        //{
        //    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        //    byte[] buff = new byte[size];
        //    rng.GetBytes(buff);
        //    return Convert.ToBase64String(buff);
        //}
        //private string CalculateHash(string input)
        //{
        //    using (var algorithm = SHA256.Create()) //or MD5 SHA512 etc.
        //    {
        //        var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        //        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        //    }
        //}

        ////POST: Logout
        //[HttpPost]
        //[Authorize]
        //public ActionResult Logout()
        //{
        //    try
        //    {
        //        // First we clean the authentication ticket like always
        //        //required NameSpace: using System.Web.Security;
        //        FormsAuthentication.SignOut();
        //        // Second we clear the principal to ensure the user does not retain any authentication
        //        //required NameSpace: using System.Security.Principal;
        //        HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        //        Session.Clear();
        //        System.Web.HttpContext.Current.Session.RemoveAll();
        //        // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
        //        // this clears the Request.IsAuthenticated flag since this triggers a new request
        //        //return RedirectToLocal();
        //        return View();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}




        //public JsonResult Applicant_Login(LoginModal Model)
        //{
        //    string[] result = new string[2];
        //    try
        //    {
        //        if (HttpContext.Session["captchastring"] == null)
        //        {
        //            result[0] = "Fail";
        //            result[1] = "Sorry ,Please Refresh the Page";
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //        if (Model.CaptchaText == HttpContext.Session["captchastring"].ToString())
        //        {
        //            string salt = CreateSalt(5);
        //            string usrname = Model.UserName;
        //            string password = Model.Password;
        //            DataSet ds = new DataSet();
        //            ds = UserDtl.VerifyApplicant(usrname, Model.yojana_code);
        //            if (ds != null)
        //            {

        //                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count == 1)
        //                {
        //                    string psw = ds.Tables[0].Rows[0]["Password"].ToString();
        //                    string hashed_pwd = CalculateHash(psw.ToString().ToLower() + Session["salt"].ToString());
        //                    if (hashed_pwd.ToString().ToLower().Equals(Model.Password.ToLower()))
        //                    {
        //                        if (ds.Tables[0].Rows[0]["UserLevel"].ToString().Trim() == "30")
        //                        {
        //                            Session["tbl_Session"] = ds.Tables[0];
        //                            FormsAuthentication.SetAuthCookie(usrname, Model.RememberMe);
        //                            result[0] = "Sucess";
        //                            result[1] = "/User/" + ds.Tables[0].Rows[0]["page_name"].ToString();
        //                            return Json(result, JsonRequestBehavior.AllowGet);
        //                        }
        //                        else
        //                        {
        //                            result[0] = "Fail";
        //                            result[1] = "Invalid Username or Password.";
        //                            ViewBag.ErrMessage = "Invalid Username or Password.";
        //                            return Json(result, JsonRequestBehavior.AllowGet);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        result[0] = "Fail";
        //                        result[1] = "Access Denied! Wrong Credential";
        //                        TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
        //                        return Json(result, JsonRequestBehavior.AllowGet);
        //                        //return RedirectToAction("Login", "Login");
        //                    }
        //                }
        //                else
        //                {
        //                    result[0] = "Fail";
        //                    result[1] = "Invalid Username or Password.";
        //                    ViewBag.ErrMessage = "Invalid Username or Password.";
        //                    return Json(result, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                result[0] = "Fail";
        //                result[1] = "Invalid Username or Password.";
        //                ViewBag.ErrMessage = "Invalid Username or Password.";
        //                return Json(result, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            result[0] = "Fail";
        //            result[1] = "Error: captcha is not valid.";
        //            ViewBag.ErrMessage = "Error: captcha is not valid.";
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result[0] = "Fail";
        //        result[1] = "Sorry ,Please Refresh the Page";
        //        ViewBag.ErrMessage = ex.Message;
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public JsonResult Getsponsoring_office(int @district_code_census)
        //{
        //    DataTable dt = new DAL.CommonDA().Getsponsoring_office(@district_code_census);
        //    List<sponsoring_office> SL = new List<sponsoring_office>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        sponsoring_office s1 = new sponsoring_office();
        //        s1.sponsoring_office_code = int.Parse(dt.Rows[i]["sponsoring_office_code"].ToString().Trim());
        //        s1.address = dt.Rows[i]["address"].ToString().Trim();
        //        SL.Add(s1);
        //    }
        //    return Json(SL, JsonRequestBehavior.AllowGet);
        //}

        //class sponsoring_office
        //{
        //    public int sponsoring_office_code { get; set; }
        //    public string address { get; set; }
        //}
        


    }
}
