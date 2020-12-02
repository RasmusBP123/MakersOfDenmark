using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Blog
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Post { get; private set; }
        public string UrlPath { get; private set; }


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
