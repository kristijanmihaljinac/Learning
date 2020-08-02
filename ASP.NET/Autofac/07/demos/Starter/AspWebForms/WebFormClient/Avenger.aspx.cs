using Lib;
using Lib.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebFormClient
{
    public partial class Avenger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            AvengerRepository avengerRepository = new AvengerRepository(logger);
            SuperheroService superheroService = new SuperheroService(avengerRepository, logger);

            string value = Request.QueryString["name"];
            if (!string.IsNullOrWhiteSpace(value))
            {
                detAvenger.DataSource = new List<Hero>() { superheroService.GetAvenger(value) };
                detAvenger.DataBind();
            }
        }
    }
}