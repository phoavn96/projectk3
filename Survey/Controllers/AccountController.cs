using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MimeKit;
using Survey.Models;

namespace Survey.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context;
        public AccountController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult HelloAjax(string q)
        {
            return View("ListUser", this.context.Users.Where(item => item.UserName.Contains(q)).ToList());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeStatusAdmin(string id)
        {
            var currentUser = UserManager.FindById(id);
            if(currentUser.Status == 0)
            {
                currentUser.Status = 1;
                UserManager.Update(currentUser);

                //Viet Gui mail vao day
                //Mail
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Admin", "locnxth1907005@fpt.edu.vn"));
                message.To.Add(new MailboxAddress("User", currentUser.Email));
                message.Subject = "Notice of account activation";
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody =
                   string.Format(
                       "<div>" +
                       "<h1>Hello " + "{0}" + "</ h1> " +
                       "<h1>Your account has been successfully activated</ h1> " +
                        "</div>"
                    , currentUser.Name);
                message.Body = bodyBuilder.ToMessageBody();
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("locnxth1907005@fpt.edu.vn", "nzqupgcvcucejtpr");
                client.Send(message);
                client.Disconnect(true);
                //Close mail




                return RedirectToAction("ListUser");
            }
            if(currentUser.Status == 1)
            {
                currentUser.Status = 0;
                UserManager.Update(currentUser);
                return RedirectToAction("ListUser");
            }
            return RedirectToAction("ListUser");

        }

        public ActionResult RegisterUserAdmin()
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => u.Name.Contains("Admin")|| u.Name.Contains("FacultyOrStaff") ||  u.Name.Contains("Students"))
                                    .ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        [ActionName("RegisterUserAdmin")]
        public async Task<ActionResult> RegisterUserAdminPostAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Class = model.Class,
                    RollNo = model.RollNo,
                    Section = model.Section,
                    Specification = model.Specification,
                    DateJoin = model.DateJoin,
                    Status = 1
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    return RedirectToAction("ListUser");
                }
                ViewBag.Name = new SelectList(context.Roles.Where(u => u.Name.Contains("Admin") || u.Name.Contains("FacultyOrStaff") || u.Name.Contains("Students"))
                                  .ToList(), "Name", "Name");

                AddErrors(result);
                ViewBag.UserName = model.UserName;
                
            }
            return View(model);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult EditUserAdmin(string id)
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => u.Name.Contains("Admin") || u.Name.Contains("FacultyOrStaff") || u.Name.Contains("Students"))
                                    .ToList(), "Name", "Name");
            
            return View(UserManager.FindById(id));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUserAdmin(ApplicationUser model)
        {
            var currentUser = UserManager.FindById(model.Id);
            var statusOld = currentUser.Status;
            var resultPass = UserManager.PasswordHasher.VerifyHashedPassword(currentUser.PasswordHash, HttpContext.Request.Form["oldPassword"]);
            switch (resultPass)
            {
                case PasswordVerificationResult.Failed:
                    ViewBag.oldPassVld = "Old password is incorrect";
                    ViewBag.Name = new SelectList(context.Roles.Where(u => u.Name.Contains("Admin") || u.Name.Contains("FacultyOrStaff") || u.Name.Contains("Students"))
                                   .ToList(), "Name", "Name");
                    return View(currentUser);
                case PasswordVerificationResult.Success:
                    if (HttpContext.Request.Form["newPassword"] != HttpContext.Request.Form["confirmPassword"])
                    {
                        ViewBag.confirmPassVld = "Confirm Password not match";
                        ViewBag.Name = new SelectList(context.Roles.Where(u => u.Name.Contains("Admin") || u.Name.Contains("FacultyOrStaff") || u.Name.Contains("Students"))
                                   .ToList(), "Name", "Name");
                        return View(currentUser);
                    }
                    var currentUserId = currentUser.Roles.SingleOrDefault().RoleId;
                    var currentUserNameRole = context.Roles.SingleOrDefault(r => r.Id == currentUserId).Name;



                    currentUser.Name = model.Name;
                    currentUser.Email = model.Email;
                    currentUser.PhoneNumber = model.PhoneNumber;
                    currentUser.RollNo = model.RollNo;
                    currentUser.Class = model.Class;
                    currentUser.Section = model.Section;
                    currentUser.Specification = model.Specification;
                    currentUser.DateJoin = model.DateJoin;

                    UserManager.Update(currentUser);
                    UserManager.ChangePassword(model.Id, HttpContext.Request.Form["oldPassword"], HttpContext.Request.Form["newPassword"]);


                    if (currentUserNameRole != HttpContext.Request.Form["UserRoles"])
                    {
                        UserManager.RemoveFromRole(currentUser.Id, currentUserNameRole);

                        UserManager.AddToRole(currentUser.Id, HttpContext.Request.Form["UserRoles"]);

                    }
                    var statusNew = model.Status;
           
                    
                    return RedirectToAction("ListUser");
                default:
                    ViewBag.Name = new SelectList(context.Roles.Where(u => u.Name.Contains("Admin") || u.Name.Contains("FacultyOrStaff") || u.Name.Contains("Students"))
                                   .ToList(), "Name", "Name");
                    return View(currentUser);
            }



            
            
        }

                [ActionName("DeleteUserAdmin")]
        public async Task<ActionResult> DeleteUserAdminAsync(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                var logins = user.Logins;
                var rolesForUser = await UserManager.GetRolesAsync(id);

                using (var transaction = context.Database.BeginTransaction())
                {
                    foreach (var login in logins.ToList())
                    {
                        await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    await UserManager.DeleteAsync(user);
                    transaction.Commit();
                }

                return RedirectToAction("ListUser");
            }
            else
            {
                return RedirectToAction("ListUser");
            }
        }
        public ActionResult DetailsUserAdmin(string id) {
            return View(UserManager.FindById(id));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ListUser() {
            

            return View(UserManager.Users);

        }

        [Authorize]
        public ActionResult Profile()
        {
            
            var user = UserManager.FindById(User.Identity.GetUserId());
            var id = user.Roles.FirstOrDefault().RoleId;
            ViewBag.RoleName = context.Roles.Where(u => u.Id == id).FirstOrDefault().Name;
            return View(user);
        }

        [Authorize]
        public ActionResult Edit()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var id = user.Roles.FirstOrDefault().RoleId;
            ViewBag.RoleName = context.Roles.Where(u => u.Id == id).FirstOrDefault().Name;
            return View(user);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public  ActionResult EditUser()
        {
            

            var idCurrent = HttpContext.Request.Form["idCurrent"];

            var currentUser = UserManager.FindById(idCurrent);
            var resultPass =  UserManager.PasswordHasher.VerifyHashedPassword(currentUser.PasswordHash, HttpContext.Request.Form["oldPassword"]);
            switch (resultPass)
            {
                case PasswordVerificationResult.Failed:
                    ViewBag.oldPassVld = "Old password is incorrect";
                    return View(currentUser);
                case PasswordVerificationResult.Success:
                    if(HttpContext.Request.Form["newPassword"]!= HttpContext.Request.Form["confirmPassword"])
                    {
                        ViewBag.confirmPassVld = "Confirm Password not match";
                        return View(currentUser);
                    }
                    currentUser.Name = HttpContext.Request.Form["fullName"];
                    currentUser.Email = HttpContext.Request.Form["email"];
                    currentUser.PhoneNumber = HttpContext.Request.Form["Phone"];
                    UserManager.Update(currentUser);
                    UserManager.ChangePassword(HttpContext.Request.Form["idCurrent"], HttpContext.Request.Form["oldPassword"], HttpContext.Request.Form["newPassword"]);
                    return Redirect("~/Home/Index");
                default:
                    return View(currentUser);
            }
                
        }


        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (context.Users.Where(s => s.UserName == model.UserName).FirstOrDefault().Status == 1)
            {
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                switch (result)
                {
                    case SignInStatus.Success:

                        if (UserManager.IsInRole(user.Id, "Admin"))
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else { return RedirectToLocal(returnUrl); }

                    //User is not in the Admin Role
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                }
            }
            return View("~/Views/Account/WaitAccount.cshtml");
            // This doesn't count login failures towards account lockout

        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                                    .ToList(), "Name", "Name");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Class = model.Class,
                    RollNo = model.RollNo,
                    Section = model.Section,
                    Specification = model.Specification,
                    DateJoin = model.DateJoin,
                    Status = 0
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    return View("~/Views/Account/WaitAccount.cshtml");
                }
                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                                  .ToList(), "Name", "Name");
                
                AddErrors(result);
                ViewBag.UserName = model.UserName;
                return View();
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}