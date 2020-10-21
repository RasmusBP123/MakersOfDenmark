using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Blog
    {
        //public Blog(string name, string bodyText, ApplicationUser author, List<Mediafile> mediafiles = null)
        //{
        //    Name = name;
        //    BodyText = bodyText;
        //    Author = author;
        //    Mediafiles = mediafiles;
        //    Created = DateTime.Now;
        //}

        public Blog() { }

        public Guid Id { get;}
        public string Name { get; }
        public string BodyText { get; }
        public DateTime Created { get; }
        public ApplicationUser Author { get; }
        public List<Mediafile> Mediafiles { get; }
    }
}
