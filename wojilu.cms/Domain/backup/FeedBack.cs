using System;
using System.Collections.Generic;
using System.Text;
using wojilu.ORM;

namespace wojilu.cms.Domain {

    public class FeedBack : ObjectBase<FeedBack> {       

        public string Subject { get; set; }

        [NotNull("请输入标题"), Column(Length = 10)]
        public string Name { get; set; }

        public string Duties { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        [LongText, NotNull( "请输入内容" )]
        public string Message { get; set; }

        public DateTime Created { get; set; }

    }

}
