﻿using System.Web;
using System.Web.Routing;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Web;

namespace Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Routing
{
    /// <summary>
    /// Represents an extended route handler for Sitefinity's page editor that injects MVC specific logic.
    /// </summary>
    public class MvcPageEditorRouteHandler : PageEditorRouteHandler
    {
        /// <summary>
        /// Builds a handler for the specified request and page data.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="pageData">The page data.</param>
        /// <returns>The handelr.</returns>
        protected override IHttpHandler BuildHandler(RequestContext requestContext, IPageData pageData)
        {
            var handler = base.BuildHandler(requestContext, pageData);
            new PageInitializer().Initialize(handler);

            return handler;
        }
    }
}
