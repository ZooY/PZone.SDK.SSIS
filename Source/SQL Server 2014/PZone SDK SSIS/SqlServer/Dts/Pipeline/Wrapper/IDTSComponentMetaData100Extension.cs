using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;


namespace SSIS.SqlServer.Dts.Pipeline.Wrapper
{
    /// <summary>
    /// Расширение функционала класса <see cref="IDTSComponentMetaData100"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IDTSComponentMetaData100Extension
    {
        /// <summary>
        /// Валидация пользовательских парамтеров.
        /// </summary>
        public static DTSValidationStatus ValidateCustomProperties(this IDTSComponentMetaData100 metadata, IEnumerable<CustomProperty> properties)
        {
            foreach (var customProperty in properties.Where(p => p.Required))
            {
                if (metadata.CustomPropertyCollection[customProperty.Name].Value != null)
                    continue;
                bool pbCancel;
                metadata.FireError(0, metadata.Name, $"Custom property \"{customProperty.Name}\" not set.", "", 0, out pbCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }
            return DTSValidationStatus.VS_ISVALID;
        }
    }
}