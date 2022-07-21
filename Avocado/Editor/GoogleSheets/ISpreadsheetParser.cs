using System.Collections.Generic;

namespace Avocado.Editor.GoogleSheets {
    public interface ISpreadsheetParser {
        string Parse(int sheetId, IList<IList<object>> sheetData);
    }
}
