using System;
using System.Collections.Generic;
using System.Text;
using wojilu.cms.Domain;
using wojilu.cms.Interface;

namespace wojilu.cms.Service {

    public class FeedBackService : IFeedBackService
    {
        public FeedBack GetById(int id)
        {
            return db.findById<FeedBack>(id);
        }

        public List<FeedBack> GetAll()
        {
            return db.findAll<FeedBack>();
        }

        public Result Insert(FeedBack c)
        {
            return db.insert( c );
        }

        public Result Update(FeedBack c)
        {
            return db.update( c );
        }

        public Result Delete(FeedBack c)
        {
            return db.update(c);
        }

    }

}
