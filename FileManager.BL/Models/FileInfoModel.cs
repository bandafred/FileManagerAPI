using System;

namespace FileManager.BL.Models
{
    /// <summary>
    /// Модель информации о файле.
    /// </summary>
    public class FileInfoModel
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string Names { get; set; }

        /// <summary>
        /// Размер файла.
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Дата последней модификации файла в строковом виде.
        /// </summary>
        public string ModificationDate { get; set; }

        /// <summary>
        /// Путь до файла.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Тип файла.
        /// </summary>
        public TypeFiles TypeFiles { get; set; }

        /// <summary>
        /// Текст текстового файла.
        /// </summary>
        public string Text { get; set; }
    }
}
