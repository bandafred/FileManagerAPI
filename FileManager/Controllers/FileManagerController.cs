using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using FileManager.BL.Business;
using FileManager.BL.Models;

namespace FileManager.Controllers
{
    /// <summary>
    /// Контроллер для работы с файловым менеджером.
    /// </summary>
    [RoutePrefix("api/FileManager")]
    public class FileManagerController : ApiController
    {
        private readonly string pathToFiles;

        /// <inheritdoc />
        public FileManagerController()
        {
            var location = AppDomain.CurrentDomain.BaseDirectory;
            //var location = HttpContext.Current.Request.Url.Host;
            var s = WebConfigurationManager.AppSettings["FilesPath"];
            this.pathToFiles = location + "\\" + s;
        }

        /// <summary>
        /// Получить файлы.
        /// </summary>
        /// <returns>List FileInfoModel.</returns>
        [Route("GetFilesInfo")]
        [HttpGet]
        public List<FileInfoModel> Get()
        {
            return new GetFileIesInfo(pathToFiles).GetInfo;
        }

        /// <summary>
        /// Получить папку в которой лежат файлы.
        /// </summary>
        /// <returns>Путь к файлам.</returns>
        [Route("GetFilesPath")]
        [HttpGet]
        public string GetFilesPath()
        {
            return WebConfigurationManager.AppSettings["FilesPath"];
        }

        /// <summary>
        /// Загрузить файл.
        /// </summary>
        /// <returns></returns>
        [Route("UploadFile")]
        [HttpPost]
        public string UploadFile()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            if (file == null) return "При загрузке файла произошла ошибка!";

            // сохраняем файл
            file.SaveAs((pathToFiles + "\\" + file.FileName));

            return $"Файл {file?.FileName} успешно загружен!";
        }

        /// <summary>
        /// Удалить файл.
        /// </summary>
        /// <returns></returns>
        [Route("DeleteFile")]
        [HttpDelete]
        public string DeleteFile(string file)
        {
            if (string.IsNullOrEmpty(file)) return "Не указано имя файла!";
            if (!File.Exists(file)) return "Файл не найден!";
            File.Delete(file);

            return "Файл успешно удален!";
        }
    }
}
