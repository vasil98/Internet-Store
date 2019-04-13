using AutoStore.Models;
using AutoStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected IEnumerable<Auto> GetAutos()
        {
            return repository.Autos;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}