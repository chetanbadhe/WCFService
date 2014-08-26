using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFServiceTestProject.Class
{
    /// <summary>
    ///     This entity represents the outer feed.
    /// </summary>
    [DataContract()]
    public class Book : IExtensibleDataObject
    {
        [DataMember(Name = "ID", IsRequired = true)]
        public int ID { get; set; }
        [DataMember(Name = "Name", IsRequired = true)]
        public string Name { get; set; }
        [DataMember(Name = "Description", IsRequired = true)]
        public string Description { get; set; }
        [DataMember(Name = "DatePublished", IsRequired = true)]
        public DateTime DatePublished { get; set; }

        /// <summary>
        ///     Extension data
        /// </summary>
        /// <remarks>
        ///     WCF stores any items we could not map here.
        /// </remarks>
        public ExtensionDataObject ExtensionData { get; set; }

    }
}