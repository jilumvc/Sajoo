using System;
using System.Collections.Generic;
using System.Text;
using wojilu.Web.Mvc;
using wojilu.cms.Domain;
using wojilu.Web;
using wojilu.Web.Mvc.Attr;
using wojilu.cms.Service;

namespace wojilu.cms.Controller
{
    public class FeedBackController : ControllerBase
    {
        public FeedBackService feedbackService { get; set; }

        public FeedBackController()
        {
            feedbackService = new FeedBackService();
        }

        public void Index()
        {
            set("ActionLink", to(new FeedBackController().SaveFeedBack));

        }

        public void SaveFeedBack()
        {
            String subject = ctx.Post("Subject");

            String name = ctx.Post("Name");

            String duties = ctx.Post("Duties");

            String email = ctx.Post("Email");

            if (string.IsNullOrEmpty(email))
            {
                echoRedirect(lang("NotFound404"));
                return;
            }

            int phone = ctx.PostInt("Phone");

            String company = ctx.Post("Company");

            String address = ctx.Post("Address");

            String message = ctx.Post("Message");

            FeedBack fbEntity = new FeedBack();
            fbEntity.Subject = subject;
            fbEntity.Name = name;
            fbEntity.Duties = duties;
            fbEntity.Email = email;
            fbEntity.Phone = phone;
            fbEntity.Company = company;
            fbEntity.Address = address;
            fbEntity.Message = message;
            fbEntity.Created = DateTime.Now;

            feedbackService.Insert(fbEntity);

            echoRedirect(lang("exPhotoUploadErrorTip"), Index);
        }

    }
}
