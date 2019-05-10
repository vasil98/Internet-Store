using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoStore.Models;
using AutoStore.Models.Repository;
using System.Web.ModelBinding;

namespace AutoStore.Pages.Admin
{
    public partial class Autos : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Auto> GetAutos()
        {
            return repository.Autos;
        }

        public void UpdateAuto(int AutoId)
        {
            Auto myAuto = repository.Autos
                .Where(p => p.AutoId == AutoId).FirstOrDefault();
            if (myAuto != null && TryUpdateModel(myAuto, 
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveAuto(myAuto);
            }
        }
        public void DeleteAuto(int AutoId)
        {
            Auto myAuto = repository.Autos
                .Where(p => p.AutoId == AutoId).FirstOrDefault();
            if (myAuto != null)
            {
                repository.DeleteAuto(myAuto);
            }
        }
        public void InsertAuto()
        {
            Auto myAuto = new Auto();
            if (TryUpdateModel(myAuto,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveAuto(myAuto);
            }
        }

    }
}
