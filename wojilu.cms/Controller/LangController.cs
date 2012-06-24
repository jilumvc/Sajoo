using System;
using System.Collections.Generic;
using System.Text;

using wojilu.Web.Mvc;
using wojilu.Web.Mvc.Attr;

namespace wojilu.cms.Controller
{
    public class LangController : ControllerBase
    {      
        public void Switch()
        {
            String langStr = ctx.Get("lang");
            ctx.web.CookieSetLang(langStr);

            redirectUrl(ctx.web.PathReferrer.ToString());
        }

    }
}
