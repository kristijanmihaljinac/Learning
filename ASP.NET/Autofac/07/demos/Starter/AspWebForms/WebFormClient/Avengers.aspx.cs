using Lib;
using Lib.Abstractions;
using System;
using System.Linq;

namespace WebFormClient
{
    public partial class Avengers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            AvengerRepository avengerRepository = new AvengerRepository(logger);
            SuperheroService superheroService = new SuperheroService(avengerRepository, logger);

            grdAvengers.DataSource = superheroService.GetAvengers();
            grdAvengers.DataBind();
        }
    }
}