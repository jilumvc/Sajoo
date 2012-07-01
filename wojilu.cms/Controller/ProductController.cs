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

        public void New()
        {

        }

        public void Show( int id ) {
            String langStr = wojilu.lang.getLangString();
            List<Product> list = Product.findAll();
            string jsonString = JsonString.ConvertList(list);

            jsonString = jsonString.Replace("\"{", "{").Replace("}\"", "}").Replace("#path#", sys.Path.Img + langStr);
            set("LangVersion", langStr);
            set("ImgName", id);

            set("zNodes", jsonString);
        }
    }
}
