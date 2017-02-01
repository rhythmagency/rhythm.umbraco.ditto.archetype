namespace Rhythm.Umbraco.Ditto.Archetype
{

    // Namespaces.
    using Our.Umbraco.Ditto;
    using System.Collections.Generic;

    /// <summary>
    /// This multi-processor combines the Archetype and DocTypeFactory processors to allow for
    /// both of those processors to be run with this single unified processor rather than
    /// having to specify the other two.
    /// </summary>
    /// <remarks>
    /// This can be used when you have an Umbraco property that is an Archetype that allows for
    /// multiple items and multiple fieldset types (e.g., a widget collection).
    /// </remarks>
    public class DittoMixedArchetypeAttribute : DittoMultiProcessorAttribute
    {

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DittoMixedArchetypeAttribute() : base(GetProcessors())
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the processors that should be run whenever this multi-processor is used.
        /// </summary>
        /// <returns>
        /// The collection of processors to run.
        /// </returns>
        private static IEnumerable<DittoProcessorAttribute> GetProcessors()
        {
            return new DittoProcessorAttribute[]
            {
                // First, the Archetype processor converts the ArchetypeModel
                // to an IPublishedContent collection.
                new DittoArchetypeAttribute(),
                // Next, the DocType processor converts each item in the previously
                // created collection to a type that is indicated by the alias of the
                // item (since they were created from Archetypes, this alias corresponds
                // to the fieldset alias for each item).
                new DittoDocTypeFactoryAttribute()
            };
        }

        #endregion

    }

}