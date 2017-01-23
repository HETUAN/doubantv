using Bruce.Core1_1.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.TestConsole
{
    public class subject_abstract_service
    {
        private readonly string req_url = "https://movie.douban.com/j/subject_abstract?subject_id={0}";

        private string id;

        public subject_abstract_service()
        {
        }
        public subject_abstract_service(string id)
        {
            this.id = id;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        private string get_json()
        {
            if (string.IsNullOrEmpty(id))
                return "";
            string url = string.Format(req_url, id);
            return Common.HttpHelper.HttpGet(url);
        }

        public subject_abstract GetModel()
        {
            string json = get_json();
            if (!string.IsNullOrEmpty(json))
            {
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<robject>(json);
                if (obj != null)
                    return obj.subject;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }


        public subject_abstract GetModel(string id)
        {
            this.id = id;
            string json = get_json();
            if (!string.IsNullOrEmpty(json))
            {
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<robject>(json);
                if (obj != null)
                    return obj.subject;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public class robject
        {
            public int r { get; set; }

            public subject_abstract subject { get; set; }
        }
    }
}
