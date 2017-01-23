using System;

namespace Bruce.Core1_1.Entity
{
    /// <summary>
    /// https://movie.douban.com/j/search_subjects?type=tv&tag=%E9%9F%A9%E5%89%A7&sort=recommend&page_limit=20&page_start=0
    /// </summary>
    public class search_subject
    {
        public string rate { get; set; }
        public int cover_x { get; set; }
        public bool is_beetle_subject { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public bool playable { get; set; }
        public string cover { get; set; }
        public string id { get; set; }
        public int cover_y { get; set; }
        public bool is_new { get; set; }
    }

}
