using System;
using System.Collections.Generic;
using System.Text;
using wojilu.ORM;

namespace wojilu.cms.Domain
{
    public class Product : ObjectBase<Product>
    {
        [Column(Name = "ParentID")]
        public int pId { get; set; }

        [Column(Name = "Name")]
        public string name { get; set; }

        [Column(Name = "Title")]
        public string title { get; set; }

        [Column(Name = "Font")]
        public string font { get; set; }

        [Column(Name = "Ico")]
        public string ico { get; set; }

        [Column(Name = "IcoOpen")]
        public string icoOpen { get; set; }

        [Column(Name = "IcoClose")]
        public string icoClose { get; set; }

        [Column(Name = "ImageSrc")]
        public string src { get; set; }

        [Column(Name = "IsParent")]
        public string isParent { get; set; }

        [Column(Name = "IsOpen")]
        public string open { get; set; }

        [Column(Name = "IsCollapse")]
        public string collapse { get; set; }

        [Column(Name = "IsExpand")]
        public string expand { get; set; }
    }
}
