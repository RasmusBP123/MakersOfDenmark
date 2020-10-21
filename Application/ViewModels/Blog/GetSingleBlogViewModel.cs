using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Blog
{
    public class GetSingleBlogViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Post { get; set; }
        public string FilePath { get; set; }
    }
}
