using System.Linq;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;


namespace SSIS.SqlServer.Dts.Pipeline.Wrapper
{
    /// <summary>
    /// Расширение класса <see cref="IDTSBufferManager100"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IDTSBufferManager100Extension
    {
        /// <summary>
        /// Поиск колонки в выходном потоке.
        /// </summary>
        public static int FindColumnByName(this IDTSBufferManager100 manager, string name, IDTSOutput100 output)
        {
            return (from IDTSOutputColumn100 column in output.OutputColumnCollection
                where column.Name == name
                select manager.FindColumnByLineageID(output.Buffer, column.LineageID)).FirstOrDefault();
        }


        public static int FindColumnByName(this IDTSBufferManager100 manager, string name, IDTSInput100 input, IDTSOutput100 output)
        {
            return (from IDTSOutputColumn100 column in output.OutputColumnCollection
                where column.Name == name
                select manager.FindColumnByLineageID(input.Buffer, column.LineageID)).FirstOrDefault();
        }


        public static int First(this IDTSBufferManager100 manager, IDTSInput100 input)
        {
            var column = input.InputColumnCollection[0];
            return manager.FindColumnByLineageID(input.Buffer, column.LineageID);
        }
    }
}