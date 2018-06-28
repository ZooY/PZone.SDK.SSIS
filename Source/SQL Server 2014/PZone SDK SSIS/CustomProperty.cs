namespace SSIS
{
    /// <summary>
    /// Пользовательский параметр.
    /// </summary>
    public class CustomProperty
    {
        /// <summary>
        /// Имя параметра.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Описание параметра.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Значение парамера по-умолчанию.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Флаг обязательности параметра.
        /// </summary>
        public bool Required { get; set; }


        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя параметра.</param>
        /// <param name="description">Описание параметра.</param>
        /// <param name="required">Флаг обязательности параметра.</param>
        public CustomProperty(string name, string description, bool required) : this(name, description, null, required)
        {
        }


        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя параметра.</param>
        /// <param name="description">Описание параметра.</param>
        /// <param name="value">Значение парамера по-умолчанию.</param>
        /// <param name="required">Флаг обязательности параметра.</param>
        public CustomProperty(string name, string description, string value = null, bool required = false)
        {
            Name = name;
            Description = description;
            Value = value;
            Required = required;
        }
    }
}