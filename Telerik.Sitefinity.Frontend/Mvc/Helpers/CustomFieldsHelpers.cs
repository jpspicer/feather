﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Telerik.Sitefinity.Frontend.Mvc.Helpers.ViewModels;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;

namespace Telerik.Sitefinity.Frontend.Mvc.Helpers
{
    /// <summary>
    /// This class contains helpers for working with custom fields.
    /// </summary>
    public static class CustomFieldsHelpers
    {
        /// <summary>
        /// Gets the custom taxonomy fields.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        public static string GetTaxonomyFields(Type contentType)
        {
            var properties = OrganizerBase.GetPropertiesForType(contentType);
            var taxonomyViewModelProperties = properties.Select(p => new CustomTaxonomyViewModel()
            {
                Id = p.TaxonomyId,
                Name = p.Name,
                TaxonomyType = p.TaxonomyType,
                Title = CustomFieldsHelpers.GetClassificationPluralTitle(p.TaxonomyId)
            });

            var serialzier = new JavaScriptSerializer();
            var serialziedProperties = serialzier.Serialize(taxonomyViewModelProperties);

            return serialziedProperties;
        }

        /// <summary>
        /// Gets the classification plural title.
        /// </summary>
        /// <param name="taxaId">The taxa identifier.</param>
        /// <returns></returns>
        private static string GetClassificationPluralTitle(Guid taxaId)
        {
            var taxonomyManager = TaxonomyManager.GetManager();
            var taxa = taxonomyManager.GetTaxonomy(taxaId);

            return taxa.Title;
        }
    }
}
