using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileManager.BL.Helpers;
using FileManager.BL.Models;

namespace FileManager.BL.Business
{
    /// <summary>
    /// Получить информацию о файлах в папке по их пути.
    /// </summary>
    public class GetFileIesInfo
    {
        private readonly string path;

        public List<FileInfoModel> GetInfo => InfoFiles();

        /// <summary>
        /// Получить информацию о файлах в папке по их пути.
        /// </summary>
        /// <param name="path">Путь к файлам.</param>
        public GetFileIesInfo(string path)
        {
            this.path = path;
        }

        private List<FileInfoModel> InfoFiles()
        {
            var result = new List<FileInfoModel>();

            var files = Directory.GetFiles(path);
            foreach (var item in files)
            {
                var attributes = new FileInfo(item);
                var add = new FileInfoModel();
                add.ModificationDate = attributes.LastWriteTime.ToLongDateString();
                add.Names = attributes.Name;
                add.Size = Math.Round((double) attributes.Length / 1048576, 2);
                add.Path = $"{attributes.DirectoryName}\\{attributes.Name}";
                add.TypeFiles = new GetTypeFiles(attributes.Extension).TypeFiles;
                if (add.TypeFiles == TypeFiles.Text) add.Text = File.ReadAllText(add.Path);
                if (add.TypeFiles == TypeFiles.Images)
                {
                    var fB = File.ReadAllBytes(add.Path);
                    add.Text = $"data:image/{attributes.Extension.Replace(".","")};charset=utf-8;base64, {Convert.ToBase64String(fB)}";
                }

                result.Add(add);
            }

            return result;
        }
    }
}
