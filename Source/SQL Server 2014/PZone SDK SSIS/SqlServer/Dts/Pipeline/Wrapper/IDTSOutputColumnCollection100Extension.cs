using System;
using System.Linq;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;


namespace SSIS.SqlServer.Dts.Pipeline.Wrapper
{
    public static class IDTSOutputColumnCollection100Extension
    {
        public static void New(this IDTSOutputColumnCollection100 collection, string name, ColumnType columnType, int length = 0, int scale = 0, int precision = 0, int codePage = 0, string description = null)
        {
            if (collection.Cast<IDTSOutputColumn100>().Any(col => col.Name == name))
                return;
            var issueId = collection.New();
            issueId.Name = name;
            if (!string.IsNullOrWhiteSpace(description))
                issueId.Description = description;
            DataType type;
            switch (columnType)
            {
                case ColumnType.String:
                    if (length <= 0 || length > 8000)
                        throw new Exception($"Для колонки {name} строкового типа указано некорректное значение длины.");
                    if (length <= 4000)
                        type = DataType.DT_WSTR;
                    else
                    {
                        type = DataType.DT_STR;
                        if (codePage == 0)
                            throw new Exception($"Для колонки {name} строкового типа с длиной более 4000 необходимо указать кодовую страницу.");
                    }
                    break;
                case ColumnType.Date:
                    type = DataType.DT_DATE;
                    break;
                default:
                    throw new Exception($"Неизвестный тип колонки {name}.");
            }
            issueId.SetDataTypeProperties(type, length, scale, precision, codePage);
        }
    }
}