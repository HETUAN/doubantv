using Bruce.Core1_1.Common;
using Bruce.Core1_1.Entity;
using Bruce.Core1_1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bruce.Core1_1.TestConsole
{
    public class search_subject_service
    {
        public readonly string req_url = "https://movie.douban.com/j/search_subjects?type=tv&tag=%E9%9F%A9%E5%89%A7&sort=recommend&page_limit={0}&page_start={1}";
        public int cur_page = 0;
        public int page_limit = 20;
        public bool is_end = false;
        private SubjectsRepository _repository;

        public search_subject_service()
        {
            _repository = new SubjectsRepository();
        }

        public void Run()
        {
            Console.WriteLine("Start");
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            while (!is_end)
            {
                var list = get_next_page_data();
                foreach (var item in list)
                {
                    if (insert(item))
                    {
                        Log.Info("Success Insert :" + item.title);
                    }
                    else
                    {
                        Log.Error("!!! Fail Insert:" + item.title);
                    }
                }
                Console.WriteLine("this is the " + cur_page + " page!");
            }
            Console.WriteLine("End");
        }

        public string get_next_page_josn()
        {
            string url = string.Format(req_url, page_limit, cur_page * page_limit);
            if (!string.IsNullOrEmpty(url))
            {
                this.cur_page++;
            }
            return Common.HttpHelper.HttpGet(url);
        }

        public search_subject[] get_next_page_data()
        {
            if (is_end)
                return null;
            string json = get_next_page_josn();
            try
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<con_subjects>(json);
                if (list.subjects.Length < page_limit)
                {
                    this.is_end = true;
                }
                return list.subjects;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return null;
            }
        }

        public bool insert(search_subject entity)
        {
            if (_repository.IsExist(entity.id) <= 0)
                return _repository.Insert(entity) > 0;
            else
                return true;
        }

        public class con_subjects
        {
            public search_subject[] subjects { get; set; }
        }
    }
}
