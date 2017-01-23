using Bruce.Core1_1.Entity;
using Bruce.Core1_1.TestConsole;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        //search_subject_service work = new search_subject_service();
        //work.Run();

        //subject_abstract_service abst_service = new subject_abstract_service("26636816");
        //subject_abstract abst_model = abst_service.GetModel();
        //subject_service subj_service = new subject_service();
        //subj_service.GetModel(abst_model);

        //var sub_model = subj_service.GetModel(abst_model);
        // Console.WriteLine(sub_model.actors_id);


        //celebrity_service celeservice = new celebrity_service();
        //celeservice.getModel("1023390", "赵寅成");

        ServiceTask task = new ServiceTask();
        task.Run();

        Console.ReadLine();
    }
}