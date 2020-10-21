using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Post { get; set; }


        public Blog() { }

        public static Blog Create(string title, string firstName,
                                      string lastName,
                                      string post)
        {
            return new Blog
            {
                Title = title,
                FirstName = firstName,
                LastName = lastName,
                Post = post
            };
        }
    }
}
