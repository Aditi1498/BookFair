using BookEvent.Models;
using Shared;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace BookEvent.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            ILoginFacade eventsFacade = (ILoginFacade)FacadeFactory.Instance.Create(FacadeType.LoginFacade);
            UserDTO userDTO = new UserDTO();
            ModelConverter.ModelConverter.FillDTOFromModel(user, userDTO);
            OperationResult<UserDTO> loginResult = eventsFacade.Login(userDTO);
            if (loginResult.IsValid())
            {
                FormsAuthentication.SetAuthCookie(loginResult.Data.Name, false);
                
                Session["UserId"] = loginResult.Data.UserId;
                return RedirectToAction("EventsList", "Home");
            }

            else if (loginResult.Message.Equals("User With This email address does not exists"))
            {
                ViewBag.Message = String.Format("User With This email does not exists");
                return View();
            }
            else
            {
                ModelConverter.ModelConverter.FillModelFromDTO(userDTO, user);
                return View(user);
            }
        }


        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(User user)
        {
            ILoginFacade eventsFacade = (ILoginFacade)FacadeFactory.Instance.Create(FacadeType.LoginFacade);
            UserDTO userDTO = new UserDTO();
            ModelConverter.ModelConverter.FillDTOFromModel(user,userDTO);

            OperationResult<UserDTO> signUpResult = eventsFacade.SignUp(userDTO);
            if (signUpResult.IsValid())
            {
                return RedirectToAction("Login");
            }
            else if(signUpResult.Message.Equals("User With This email address already exists"))
            {
                ViewBag.Message = String.Format("User With This email address already exists");
                return View();
            }
            else
            {
                ModelConverter.ModelConverter.FillModelFromDTO(userDTO, user);
                return View(user);
            }
        }
        

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



    }
}