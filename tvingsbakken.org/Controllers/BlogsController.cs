using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using tvingsbakken.org.Models;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace tvingsbakken.org.Controllers
{

    [Route("getallblogs")]
    public class BlogsController : UmbracoApiController
    {
        private readonly UmbracoHelper _umbracoHelper;

        public BlogsController(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var result = new List<Blog>();
            var blogRoot = _umbracoHelper.ContentSingleAtXPath("//blog");
            if (blogRoot is null || blogRoot.Children is null)
            {
                return NotFound();
            }

            var blogs = blogRoot.Children;
            foreach (var blog in blogs)
            {
                var blogItem = new Blog();
                blogItem.PublishDate = blog.Value<DateTime>("publishDate");
                blogItem.Title = blog.Value<string>("PageTitle");
                blogItem.AltTitle = blog.Value<string>("BrowserTitle");
                blogItem.Text = blog.Value<string>("Excerpt");
                blogItem.Url = blog.Url();
                result.Add(blogItem);
            }
            if(result.Any())
            {
                result = result.OrderByDescending(o => o.PublishDate).ToList();
            }
            return Ok(result);
        }
    }
}