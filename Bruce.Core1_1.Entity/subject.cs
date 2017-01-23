using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.Entity
{
    public class subject
    {
        public string id { get; set; }
        public string types { get; set; }
        public string release_year { get; set; }
        public bool playable { get; set; }
        public string region { get; set; }
        public string duration { get; set; }
        public string actors { get; set; }
        public string directors { get; set; }
        public string subtype { get; set; }
        public bool is_tv { get; set; }
        public string rate { get; set; }
        public string collection_status { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string blacklisted { get; set; }
        public string star { get; set; }
        public string episodes_count { get; set; }

        public List<string> actors_ids { get; set; }
        public List<string> directors_ids { get; set; }
        public List<string> bianjus_ids { get; set; }
        public string actors_id { get; set; }
        public string directors_id { get; set; }
        public string bianjus { get; set; }
        public string bianjus_id { get; set; }

    }
}
