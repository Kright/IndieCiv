using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using IndieCivCore.Resources;

namespace IndieCivCore {
    class TerrainDataTypeConverter : TypeConverter {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            return new StandardValuesCollection(ResourceInterface.TerrainData);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
            if (value is string) {
                foreach (TerrainData t in ResourceInterface.TerrainData) {
                    if (t.ToString() == (string)value) {
                        return t;
                    }
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
