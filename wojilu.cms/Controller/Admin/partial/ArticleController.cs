using System;
using System.Collections.Generic;
using System.Text;
using wojilu.Web;
using wojilu.Web.Mvc;
using wojilu.cms.Domain;

namespace wojilu.cms.Controller.Admin {

    public partial class ArticleController : ControllerBase {
        
        private void bindListShow( List<FeedBack> list ) {
            IBlock block = getBlock( "list" );
            foreach (FeedBack a in list) {

                block.Set( "article.Id", a.Id );

                string title = a.Title.Length > 8 ? a.Title : "<strong>" + a.Title + "</strong>";
                block.Set( "article.Title", title );
                block.Set( "article.Content", a.Content.Length > 20 ? a.Content.Substring( 0, 20 ) : a.Content );
                block.Next();
            }
        }


        private void bindLink( IBlock block, int id ) {
            block.Set( "article.EditLink", to( Edit, id ) );
            block.Set( "article.DeleteLink", to( Delete, id ) );
        }

        private void bindCategoryAndArticlet( List<Category> categories, List<FeedBack> articles ) {
            // 获取[分类]循环块
            IBlock cateroyBlock = getBlock( "categories" );
            foreach (Category category in categories) {
                cateroyBlock.Set( "category.Name", category.Name );

                // 获取[文章]循环块
                IBlock articleBlock = cateroyBlock.GetBlock( "articles" );
                List<FeedBack> articlesByCategory = filterArticle( articles, category );
                foreach (FeedBack article in articlesByCategory) {
                    articleBlock.Set( "article.Id", article.Id );
                    articleBlock.Set( "article.Title", article.Title );
                    articleBlock.Set( "article.Created", article.Created );
                    articleBlock.Next();
                }

                cateroyBlock.Next();
            }
        }

        private List<FeedBack> filterArticle( List<FeedBack> articles, Category category ) {
            List<FeedBack> results = new List<FeedBack>();
            foreach (FeedBack a in articles) {
                if (a.Category.Id == category.Id) results.Add( a );
            }
            return results;
        }

    }
}
