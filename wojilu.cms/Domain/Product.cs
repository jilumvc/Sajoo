using System;
using System.Collections.Generic;
using System.Text;

namespace wojilu.cms.Domain
{
    public class Product : ObjectBase<UploadFile>
    {
        public string Name { get; set; }

        public string ImageName { get; set; }

        public string Link { get; set; }
    }
}
