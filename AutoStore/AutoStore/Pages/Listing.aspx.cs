﻿using AutoStore.Models;
using AutoStore.Models.Repository;
using AutoStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        private int pageSize = 3;
        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterAutos().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Auto> GetAutos()
        {
            return FilterAutos()
                .OrderBy(g => g.AutoId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Auto> FilterAutos()
        {
            IEnumerable<Auto> autos = repository.Autos;
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? autos : autos.Where(p => p.Category == currentCategory);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedAutoId;
                if (int.TryParse(Request.Form["add"], out selectedAutoId))
                {
                    Auto selectedAuto = repository.Autos
                        .Where(g => g.AutoId == selectedAutoId).FirstOrDefault();

                    if (selectedAuto != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedAuto, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);

                        Response.Redirect(RouteTable.Routes 
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }

        }
    }
}
