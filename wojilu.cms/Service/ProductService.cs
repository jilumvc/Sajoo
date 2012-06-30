using System;
using System.Collections.Generic;
using System.Text;
using wojilu.cms.Domain;
using wojilu.cms.Interface;

namespace wojilu.cms.Service {

    public class ProductService : IProductService {

        public Product GetById(int id)
        {
            return db.findById<Product>(id);
        }

        public List<Product> GetAll()
        {
            return db.findAll<Product>();
        }

        public Result Insert(Product c)
        {
            return db.insert( c );
        }

        public Result Update(Product c)
        {
            return db.update( c );
        }

    }

}
