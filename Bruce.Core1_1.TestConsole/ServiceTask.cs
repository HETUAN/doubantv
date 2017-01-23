using Bruce.Core1_1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.TestConsole
{
    public class ServiceTask
    {
        public void Run()
        {
            // 首先运行基础数据，将韩剧的列表数据获取一遍
            //search_subject_service searchSubjectService = new search_subject_service();
            //searchSubjectService.Run();

            //根据上面获取到的列表数据获取详细数据
            SubjectsRepository ssRepository = new SubjectsRepository();
            List<string> ids = ssRepository.GetIdList();
            subject_abstract_service saService = new subject_abstract_service();
            subject_service sService = new subject_service();
            var existIds = sService.GetIdList();
            existIds.RemoveAt(existIds.Count - 1);
            foreach (var id in ids)
            {
                if (existIds.Contains(id))
                    continue;
                sService.GetModel(saService.GetModel(id));
            }
        }
    }
}
