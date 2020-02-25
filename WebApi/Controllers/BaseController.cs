using System;
using Jwt;
using Microsoft.AspNetCore.Mvc;
using DotnetCore.Business.Interfaces;
using DotnetCore.Web.Models;

namespace DotnetCore.Web.Controllers
{

    //  [NoCache()]
    public class BaseController : Controller
    {
        public static string SUCCESS = "success";
        public static string ERROR = "error";
        public string userid = "10";
        public WebToken _sessionUserData = null;


        protected virtual WebToken SessionUserData
        {
            get
            {
                return this._sessionUserData;
            }
            set
            {
                this._sessionUserData = value;
            }
        }



        private static BusinessSupervisor _businessSupervisor;
        public static BusinessSupervisor businessSupervisor
        {
            get
            {
                if (_businessSupervisor == null)
                    return null;
                return _businessSupervisor;
            }
            set
            {
                _businessSupervisor = value;
            }
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}