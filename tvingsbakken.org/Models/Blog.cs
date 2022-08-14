using System;

namespace tvingsbakken.org.Models
{
    public class Blog
    {
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string AltTitle { get; set; }
    }
}