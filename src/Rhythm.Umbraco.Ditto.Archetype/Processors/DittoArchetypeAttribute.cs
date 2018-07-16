namespace Rhythm.Umbraco.Ditto.Archetype
{

    // Namespaces.
    using global::Archetype.Extensions;
    using global::Archetype.Models;
    using global::Umbraco.Core.Models;
    using Our.Umbraco.Ditto;
    using Rhythm.Core;
    using System.Collections;

    /// <summary>
    /// Allows for mapping of Archetype properties.
    /// </summary>
    /// <remarks>
    /// Snagged from: https://github.com/leekelleher/umbraco-ditto-labs/blob/develop/src/Our.Umbraco.Ditto.Archetype/ComponentModel/Processors/DittoArchetypeAttribute.cs
    /// </remarks>
    public class DittoArchetypeAttribute : UmbracoPropertyAttribute
    {

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DittoArchetypeAttribute()
            : base()
        { }

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property.
        /// </param>
        /// <param name="altPropertyName">
        /// The alternate property name.
        /// </param>
        /// <param name="recursive">
        /// Map recursively?
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        public DittoArchetypeAttribute(
            string propertyName,
            string altPropertyName = null,
            bool recursive = false,
            object defaultValue = null)
            : base(propertyName, altPropertyName, recursive, defaultValue)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Process the value.
        /// </summary>
        /// <returns>
        /// The processed value.
        /// </returns>
        public override object ProcessValue()
        {
            var value = this.Value;

            if (value is IPublishedContent)
            {
                value = base.ProcessValue();
            }

            if (value is ArchetypeModel)
            {
                var result = ((ArchetypeModel)value).ToPublishedContentSet();
                return CollectionExtensionMethods.AsList(result);
            }

            if (value is ArchetypeFieldsetModel)
            {
                return ((ArchetypeFieldsetModel)value).ToPublishedContent();
            }

            if (value is IEnumerable)
            {
                return CollectionExtensionMethods.AsList(value as dynamic);
            }
            else
            {
                return value;
            }

        }

        #endregion

    }

}