using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Blog
{
    public class CreateBlogViewModel
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Post { get; set; }
        public string UrlPath { get; set; }
    }
}
