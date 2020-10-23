using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Post { get; set; }
        public string UrlPath { get; set; }


        public Blog() { }

        public static Blog Create(string title, Guid userid, string firstName,
                                      string lastName,
                                      string post, string urlpath)
        {
            return new Blog
            {
                Title = title,
                UserId = userid,
                FirstName = firstName,
                LastName = lastName,
                Post = post,
                UrlPath = urlpath
            };
        }
    }
}
