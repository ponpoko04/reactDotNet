using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ReactDotNetApi.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace ReactDotNetApi.Controllers
{
    public class CommentsController : ApiController
    {
        List<Comment> comments = new List<Comment>
        {
            new Comment { id = 1, author = "Pete Hunt", text = "This is one comment" },
            new Comment { id = 2, author = "Jordan Walke", text = "This is *author* comment" }
        };

        public IEnumerable<Comment> GetAllComments()
        {
            return this.comments;
        }

        public IHttpActionResult GetComment(int id)
        {
            var comment = this.comments.FirstOrDefault((p) => p.id == id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        public IHttpActionResult Post([FromBody]JToken json)
        {
            if (json == null) return Ok(this.comments);
            var postComment = new Comment()
            {
                id = this.comments.Max((p) => p.id) + 1,
                author = json["author"].ToString(),
                text = json["text"].ToString()
            };
            this.comments.Add(postComment);
            return Ok(this.comments);
        }
    }
}
