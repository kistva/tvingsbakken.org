using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Text.Json;
using tvingsbakken.org.Models;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace tvingsbakken.org.Controllers
{

    [Route("api/blogs")]
    public class BlogsController : UmbracoApiController
    {
        private readonly UmbracoHelper _umbracoHelper;

        public BlogsController(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }

        [HttpGet("{pageNumber?}/{pageSize?}")]
        public IActionResult GetAllBlogs(int pageNumber = 1, int pageSize = 3)
        {
            var result = new Blogs();
            var blogRoot = _umbracoHelper.ContentSingleAtXPath("//blog");
            if (blogRoot is null || blogRoot.Children is null)
            {
                return NotFound();
            }

            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 10 ? 10 : pageSize;

            var blogs = blogRoot.Children;
            foreach (var blog in blogs)
            {
                var blogItem = new Blog();
                blogItem.PublishDate = blog.Value<DateTime>("publishDate");
                blogItem.Title = blog.Value<string>("pageTitle");
                blogItem.AltTitle = blog.Value<string>("browserTitle");
                blogItem.Text = blog.Value<string>("excerpt");
                blogItem.Url = blog.Url();
                result.Result.Add(blogItem);
            }

            if(result.Result.Any())
            {
                result.Total = result.Result.Count;
                result.NumberOfPages = Convert.ToInt32(Math.Ceiling(((double)result.Result.Count / (double)pageSize)));
                pageNumber = pageNumber > result.NumberOfPages ? result.NumberOfPages : pageNumber;
                result.Result = result.Result.OrderByDescending(o => o.PublishDate).ToList();
                result.Result = result.Result.Skip<Blog>((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            return Ok(result);
        }
    }
}