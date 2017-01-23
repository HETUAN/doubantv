using Bruce.Core1_1.Common;
using Bruce.Core1_1.Entity;
using Bruce.Core1_1.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.TestConsole
{
    public class subject_service
    {
        private readonly string req_url = "https://movie.douban.com/subject/{0}/";

        private readonly SubjectRepository _repositoty = new SubjectRepository();

        private HtmlDocument get_html(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            string url = string.Format(req_url, id);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(Common.HttpHelper.HttpGet(url));
            return htmlDocument;
        }

        public subject GetModel(subject_abstract model)
        {
            if (model == null)
                return null;
            var subj = new subject();
            subj.id = model.id;
            subj.types = string.Join(",", model.types);
            subj.release_year = model.release_year;
            subj.playable = model.playable;
            subj.region = model.region;
            subj.duration = model.duration;
            subj.actors = string.Join(",", model.actors);
            subj.directors = string.Join(",", model.directors);
            subj.subtype = model.subtype;
            subj.is_tv = model.is_tv;
            subj.rate = model.rate;
            subj.collection_status = model.collection_status;
            subj.url = model.url;
            subj.title = model.title;
            subj.blacklisted = model.blacklisted;
            subj.star = model.star;
            subj.episodes_count = model.episodes_count;
            subj.actors_ids = new List<string>();
            subj.directors_ids = new List<string>();
            subj.bianjus_ids = new List<string>();
            //string uri = string.Format(req_url, subj.id);
            //var encoding = Encoding.GetEncoding("utf-8");
            //HtmlWeb web = new HtmlWeb();
            //var htmlDocument = web.LoadFromWebAsync(uri, encoding).Result;
            var htmlDocument = get_html(subj.id);
            if (htmlDocument != null)
            {
                var coll = htmlDocument.DocumentNode.SelectNodes("//span[@class=\"attrs\"]");
                Dictionary<string, string> stars = new Dictionary<string, string>();
                //var item = coll[0].SelectNodes("//a");
                if (coll == null)
                    return null;
                try
                {
                    var item = coll[0].ChildNodes;
                    if (item != null)
                    {
                        //int len = item.ChildNodes.Count;
                        foreach (var node in item)
                        {
                            //var node = item.ChildNodes[i];
                            if (node.Name != "a")
                                continue;
                            var url = node.Attributes["href"].Value.TrimEnd('/');
                            int tidx = url.LastIndexOf('/') + 1;
                            url = url.Substring(tidx);
                            var text = node.InnerText;
                            stars.Add(url, text);
                            subj.directors_ids.Add(url);
                        }
                    }
                    item = coll[1].ChildNodes;
                    if (item != null)
                    {
                        int len = item.Count;
                        for (int i = 0; i < len; i++)
                        {
                            var node = item[i];
                            if (node.Name != "a")
                                continue;
                            var url = node.Attributes["href"].Value.TrimEnd('/');
                            int tidx = url.LastIndexOf('/') + 1;
                            url = url.Substring(tidx);
                            var text = node.InnerText;
                            stars.Add(url, text);
                            subj.bianjus = text;
                            subj.bianjus_ids.Add(url);
                        }
                    }

                    item = coll[2].ChildNodes;
                    if (item != null)
                    {
                        int len = item.Count;
                        for (int i = 0; i < len; i++)
                        {
                            var node = item[i];
                            if (node.Name != "a")
                                continue;
                            var url = node.Attributes["href"].Value.TrimEnd('/');
                            int tidx = url.LastIndexOf('/') + 1;
                            url = url.Substring(tidx);
                            var text = node.InnerText;
                            stars.Add(url, text);
                            subj.actors_ids.Add(url);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }

                subj.actors_id = string.Join(",", subj.actors_ids);
                subj.directors_id = string.Join(",", subj.directors_ids);
                subj.bianjus_id = string.Join(",", subj.bianjus_ids);

                if (Insert(subj))
                {
                    Log.Info(string.Format("Success Insert subject: id = {0}, Name = {1}", subj.id, subj.title));
                }
                else
                {
                    Log.Info(string.Format("Fail Insert subject: id = {0}, Name = {1}", subj.id, subj.title));
                }
                //return subj;

                celebrity_service celeService = new celebrity_service();
                cele_subject_service celeSubService = new cele_subject_service();
                //获取人
                foreach (KeyValuePair<string, string> star in stars)
                {
                    celeService.getModel(star.Key, star.Value);
                    celeSubService.Run(star.Key);
                }
                return subj;
            }
            else
            {
                return null;
            }
        }

        private bool Insert(subject model)
        {
            if (_repositoty.IsExist(model.id) <= 0)
                return _repositoty.Insert(model) > 0;
            else
                return false;
        }

        public List<string> GetIdList()
        {
            return _repositoty.GetIdList();
        }
    }
}
