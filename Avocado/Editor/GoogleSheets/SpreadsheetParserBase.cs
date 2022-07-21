using System.Collections.Generic;
using System.Globalization;

namespace Avocado.Editor.GoogleSheets {
    public abstract class SpreadsheetParserBase : ISpreadsheetParser {
        public abstract string Parse(int sheetId, IList<IList<object>> sheetData);
        
        protected object GetParseValue(object value) {
            if (int.TryParse(value.ToString(), out var resInt)) {
                return resInt;
            }

            var resValue = value.ToString().Replace(',', '.');
            if (float.TryParse(resValue, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat,
                out float floatRes)) {
                return floatRes;
            }
            
            return resValue;
        }
    }
}
