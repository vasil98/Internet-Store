using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoStore.Models;
using AutoStore.Models.Repository;
using AutoStore.Pages.Helpers;

namespace AutoStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int autoId;
                if (int.TryParse(Request.Form["remove"], out autoId))
                {
                    Auto autoToRemove = repository.Autos
                        .Where(g => g.AutoId == autoId).FirstOrDefault();

                    if (autoToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(autoToRemove);
                    }
                }
            }
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }

    }
}
