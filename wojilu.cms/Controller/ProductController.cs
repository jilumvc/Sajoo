using System;
using System.Collections.Generic;
using System.Text;
using wojilu.Web.Mvc;
using wojilu.cms.Domain;
using wojilu.Web;
using wojilu.cms.Service;
using wojilu.Serialization;

namespace wojilu.cms.Controller {

    public class ProductController : ControllerBase {

        public ProductService productService { get; set; }

        public ProductController()
        {
            productService = new ProductService();
        }

        public void Index() { 
            
        }

        public void Show( int id ) {
            String langStr = wojilu.lang.getLangString();
            List<Product> list = Product.findAll();
            string jsonString = JsonString.ConvertList(list);

            set("LangVersion", langStr);
            set("ImgName", id);

            set("zNodes", jsonString);
        }
    }
}
