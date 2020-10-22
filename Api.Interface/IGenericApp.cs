using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.Interface
{
    public interface IGenericApp
    {
        List<AppModel> ViewApps();

        AppModel ViewApp(string id);

        AppModel UpdateApp(AppModel app);

        AppModel CreateApp(AppModel app);

        bool DeleteApp(string id);
    }
}
