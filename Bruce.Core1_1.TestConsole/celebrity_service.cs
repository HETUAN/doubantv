using Bruce.Core1_1.Common;
using Bruce.Core1_1.Entity;
using Bruce.Core1_1.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.TestConsole
{
    public class celebrity_service
    {
        private readonly string req_url = "https://movie.douban.com/celebrity/{0}/";
        private readonly CelebrityRepository _repository = new CelebrityRepository();

        public void Run(Dictionary<string, string> kvs)
        {
            foreach (var item in kvs)
            {
                if (Insert(getModel(item.Key, item.Value)))
                {
                    Log.Info(string.Format("Success Insert Celebrity, Id = {0} ,Name = {1}", item.Key, item.Value));
                }
                else
                {
                    Log.Info(string.Format("Fail Insert Celebrity, Id = {0} ,Name = {1}", item.Key, item.Value));
                }
            }
            Log.Info("End");
        }

        private HtmlDocument get_html(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            string url = string.Format(req_url, id);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(Common.HttpHelper.HttpGet(url));
            return htmlDocument;
        }

        public celebrity getModel(string id, string name)
        {
            //string uri = string.Format(req_url, id);
            //var encoding = Encoding.GetEncoding("utf-8");
            //HtmlWeb web = new HtmlWeb();
            //var htmlDocument = web.LoadFromWebAsync(uri, encoding).Result;
            var htmlDocument = get_html(id);

            if (htmlDocument != null)
            {
                celebrity model = new celebrity();
                model.id = id;
                model.name = name;
                var wrapper = htmlDocument.GetElementbyId("wrapper");
                if (wrapper == null)
                    return null;
                var title = wrapper.SelectSingleNode("//div/h1");
                if (title != null)
                    model.title = title.InnerText;

                var coll = htmlDocument.GetElementbyId("wrapper").SelectNodes("//div[@class=\"info\"]/ul/li");
                if (coll == null)
                    return null;

                foreach (var item in coll)
                {
                    try
                    {
                        switch (item.ChildNodes[1].InnerText.Trim())
                        {
                            case "性别":
                                model.sex = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "星座":
                                model.constellation = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "出生日期":
                                model.birthday = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "出生地":
                                model.homeplace = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "职业":
                                model.occupation = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "更多外文名":
                                model.othernames = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "更多中文名":
                                model.chname = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                            case "imdb编号":
                                model.imdbnum = item.LastChild.InnerText.Replace(':', ' ').Trim();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                        continue;
                    }
                }

                //if (coll[0] != null)
                //    model.sex = coll[0].InnerText.Split(':')[1].Trim();

                //if (coll[1] != null)
                //    model.birthday = coll[1].InnerText.Split(':')[1].Trim();

                //if (coll[2] != null)
                //    model.constellation = coll[2].InnerText.Split(':')[1].Trim();

                //if (coll[3] != null)
                //    model.occupation = coll[3].InnerText.Split(':')[1].Trim();

                //if (coll[4] != null)
                //    model.homeplace = coll[4].InnerText.Split(':')[1].Trim();

                //if (coll[5] != null)
                //    model.chname = coll[5].InnerText.Split(':')[1].Trim();

                //if (coll[6] != null)
                //    model.othernames = coll[6].InnerText.Split(':')[1].Trim();

                //if (coll[7] != null)
                //    model.imdbnum = coll[7].InnerText.Split(':')[1].Trim();
                Insert(model);
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(celebrity model)
        {
            if (_repository.IsExist(model.id) <= 0)
                return _repository.Insert(model) > 0;
            else
                return false;
        }
    }
}
