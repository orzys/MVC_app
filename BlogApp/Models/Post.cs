using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        //[Required]
        public string ImageUrl { get; set; }
        //[Required]
        //[StringLength(50, ErrorMessage = "Title is too long")]
        public string Title { get; set; }
        //[Required]
        //[StringLength(100, ErrorMessage = "Short content is too long" )]
        public string ShortContent { get; set; }
        //[Required]
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public bool HidePost { get; set; }
    }
}