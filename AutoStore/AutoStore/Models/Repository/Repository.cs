using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Auto> Autos
        {
            get
            {
                return context.Autos;
            }
        }
    }
}
