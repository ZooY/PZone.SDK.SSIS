using System;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;


namespace SSIS.SqlServer.Dts.Pipeline.Wrapper
{
    /// <summary>
    /// Расширение функционала класса <see cref="IDTSOutputCollection100"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IDTSOutputCollection100Extension
    {
        /// <summary>
        /// Получение выходного потока по умолчанию.
        /// </summary>
        /// <param name="collection">Коллекция выходных потоков.</param>
        /// <returns>Метод возвращает выходной поток с именем <c>Output</c>.</returns>
        public static IDTSOutput100 GetDefaultOutput(this IDTSOutputCollection100 collection)
        {
            return collection.GetOutputByName("Output");
        }


        /// <summary>
        /// Получение выходного потока с указанным именем.
        /// </summary>
        /// <param name="collection">Коллекция выходных потоков.</param>
        /// <param name="name">Имя выходного потока.</param>
        /// <returns>Метод возвращает выходной поток с именем, указанным в параметре <paramref name="name"/>.</returns>
        /// <exception cref="Exception">Исключение возникает, если в коллекции не найдено выходного потока с указанным именем.</exception>
        public static IDTSOutput100 GetOutputByName(this IDTSOutputCollection100 collection, string name)
        {
            foreach (IDTSOutput100 output in collection)
                if (output.Name == name)
                    return output;
            throw new Exception($@"Could not find output stream with the name of ""{name}"".");
        }
    }
}