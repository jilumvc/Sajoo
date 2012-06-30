using System;
using System.Collections.Generic;
using System.Text;
using wojilu.ORM;

namespace wojilu.cms.Domain
{
    public class Product : ObjectBase<Product>
    {
        public int ParentID { get; set; }

         [Column(Name = "Name")]
        public string name { get; set; }

        public string Title { get; set; }

        public string Ico { get; set; }

        public string IcoOpen { get; set; }

        public string IcoClose { get; set; }

        public string ImageSrc { get; set; }

        public string IsParent { get; set; }

         [Column(Name = "IsOpen")]
        public string open { get; set; }

        public string IsCollapse { get; set; }

        public string IsExpand { get; set; }
    }
}
