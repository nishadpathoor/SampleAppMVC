using Api.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.OneSingle
{
    public class OneSingleApp_dummy : IGenericApp
    {
        List<AppModel> dummy;
        public OneSingleApp_dummy()
        {
            dummy = new List<AppModel>();
            dummy.Add(new AppModel() { Id = "1", Name = "name1",  CreatedOn =DateTime.Now, UpdatedOn = DateTime.Now });
            dummy.Add(new AppModel() { Id = "2", Name = "name2",  CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        }

        public AppModel CreateApp(AppModel app)
        {
            return dummy.First();
        }

        public bool DeleteApp(string id)
        {
            return true;
        }

        public AppModel UpdateApp(AppModel app)
        {
            return app;
        }

        public AppModel ViewApp(string id)
        {
            return dummy.FirstOrDefault(n => n.Id == id);
        }

        public List<AppModel> ViewApps()
        {
            return dummy;
        }
    }
}
