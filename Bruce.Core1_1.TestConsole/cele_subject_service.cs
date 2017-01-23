using Bruce.Core1_1.Common;
using Bruce.Core1_1.Entity;
using Bruce.Core1_1.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.TestConsole
{
    public class cele_subject_service
    {
        private readonly string req_url = "https://movie.douban.com/celebrity/{0}/movies?start={1}&sortby=time&format=text&";
        private string id = "";
        private int idx;
        private int page_limit = 20;
        private bool isEnd = false;
        private readonly CeleSubjectRepository _repository = new CeleSubjectRepository();

        public cele_subject_service()
        {
        }
        public cele_subject_service(string id)
        {
            this.id = id;
        }

        public void Run()
        {
            if (string.IsNullOrEmpty(id))
                return;
            this.idx = 0;
            this.isEnd = false;
            while (!isEnd)
            {
                DealPage();
            }
        }

        private HtmlDocument get_html()
        {
            if (string.IsNullOrEmpty(id))
                return null;

            string url = string.Format(req_url, id, idx * page_limit);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(Common.HttpHelper.HttpGet(url));
            return htmlDocument;
        }

        private void DealPage()
        {
            //string uri = string.Format(req_url, id, idx * page_limit);
            //var encoding = Encoding.GetEncoding("utf-8");
            //HtmlWeb web = new HtmlWeb();
            //var htmlDocument = web.LoadFromWebAsync(uri, encoding).Result;
            var htmlDocument = get_html();
            if (htmlDocument != null)
            {
                var wrapper = htmlDocument.GetElementbyId("wrapper");
                if (wrapper == null)
                {
                    this.isEnd = true;
                    return;
                }
                var coll = wrapper.SelectNodes("//tbody/tr/td[@headers=\"m_name\"]/a");
                if (coll != null && coll.Count > 0)
                {
                    foreach (var item in coll)
                    {
                        try
                        {
                            var model = new cele_subject();
                            model.celebrity_id = id;
                            string url = item.Attributes["href"].Value.TrimEnd('/');
                            //https://movie.douban.com/subject/2298836/
                            int ssidx = url.LastIndexOf("subject");
                            string sid = url.Substring(ssidx + 8);
                            model.subject_id = sid;
                            model.subject_title = item.InnerText;
                            if (Insert(model))
                            {
                                Log.Info("Success Insert cele_subject: " + model.subject_title);
                            }
                            else
                            {
                                Log.Info("Fail Insert cele_subject: " + model.subject_title);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.ToString());
                        }
                    }
                }
                this.idx++;
            }
            this.isEnd = true;
        }

        private bool Insert(cele_subject model)
        {
            if (_repository.IsExist(model.celebrity_id, model.subject_id) <= 0)
                return _repository.Insert(model) > 0;
            else
                return false;
        }

        public void Run(string id)
        {
            this.id = id;
            Run();
        }
    }
}
