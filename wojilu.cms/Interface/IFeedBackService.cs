using System;
using System.Collections.Generic;
using System.Text;
using wojilu.cms.Domain;

namespace wojilu.cms.Interface
{
    public interface IFeedBackService
    {
        List<FeedBack> GetAll();
        FeedBack GetById(int id);

        Result Insert(FeedBack c);
        Result Update(FeedBack c);
        Result Delete(FeedBack c);
    }
}
