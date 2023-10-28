using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Domain.Endpoints
{
    public class RoleEndpoint
    {
        public const string Area = "";
        public const string Base = Area + "/role";
        public const string GetAll = Base + "/all";
        public const string GetSingle = Base + "/{Id}";
        public const string Create = Base + "/create";
        public const string Update = Base + "/update/{Id}";
        public const string Delete = Base + "/delete/{Id}";
    }
}
