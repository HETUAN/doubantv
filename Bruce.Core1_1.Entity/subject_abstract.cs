//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

namespace Bruce.Core1_1.Entity
{
    /// <summary>
    /// https://movie.douban.com/j/subject_abstract?subject_id=26435723
    /// </summary>
    public class subject_abstract
    {
        public string id { get; set; }
        public string[] types { get; set; }
        public string release_year { get; set; }
        public bool playable { get; set; }
        public string region { get; set; }
        public string duration { get; set; }
        public string[] actors { get; set; }
        public string[] directors { get; set; }
        public string subtype { get; set; }
        public bool is_tv { get; set; }
        public string rate { get; set; }
        public string collection_status { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string blacklisted { get; set; }
        public string star { get; set; }
        public string episodes_count { get; set; }
    }
}