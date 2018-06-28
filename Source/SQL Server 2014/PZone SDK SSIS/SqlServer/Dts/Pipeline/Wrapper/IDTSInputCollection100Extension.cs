using System;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;


namespace SSIS.SqlServer.Dts.Pipeline.Wrapper
{
    /// <summary>
    /// Расширение функционала класса <see cref="IDTSInputCollection100"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IDTSInputCollection100Extension
    {
        /// <summary>
        /// Получение входного потока по умолчанию.
        /// </summary>
        /// <param name="collection">Коллекция входных потоков.</param>
        /// <returns>Метод возвращает входной поток с именем <c>Input</c>.</returns>
        public static IDTSInput100 GetDefaultInput(this IDTSInputCollection100 collection)
        {
            return collection.GetInputByName("Input");
        }


        /// <summary>
        /// Получение входного потока с указанным именем.
        /// </summary>
        /// <param name="collection">Коллекция входных потоков.</param>
        /// <param name="name">Имя входного потока.</param>
        /// <returns>Метод возвращает входной поток с именем, указанным в параметре <paramref name="name"/>.</returns>
        /// <exception cref="Exception">Исключение возникает, если в коллекции не найдено входного потока с указанным именем.</exception>
        public static IDTSInput100 GetInputByName(this IDTSInputCollection100 collection, string name)
        {
            foreach (IDTSInput100 input in collection)
                if (input.Name == name)
                    return input;
            throw new Exception($@"Could not find input stream with the name of ""{name}"".");
        }
    }
}