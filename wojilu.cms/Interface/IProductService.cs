using System;
using System.Collections.Generic;
using wojilu.cms.Domain;

namespace wojilu.cms.Interface {

    public interface IProductService {

        List<Product> GetAll();
        Product GetById(int id);

        Result Insert(Product c);
        Result Update(Product c);

    }

}
