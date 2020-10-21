using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Mediafile
    {
        public Mediafile(Guid id, string url, byte[] data,string extension, Blog post)
        {
            Id = id;
            Url = url;
            Data = data;
            Extension = extension;
            Post = post;
        }

        private Mediafile()
        { }

        public Guid Id { get; }
        public string Url { get; }
        public byte[] Data { get; }
        public string Extension { get; }
        public Blog Post { get; }
        public Guid PostId { get; set; }
    }
}
