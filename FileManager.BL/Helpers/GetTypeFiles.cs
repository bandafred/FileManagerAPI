using System;
using System.Collections.Generic;
using System.Text;
using FileManager.BL.Models;

namespace FileManager.BL.Helpers
{
    public class GetTypeFiles
    {
        public TypeFiles TypeFiles => GetType();

        private readonly string extension;

        public GetTypeFiles(string extension)
        {
            this.extension = extension;
        }

        private new TypeFiles GetType()
        {
            switch (extension)
            {
                case ".jpg":
                    return TypeFiles.Images;
                case ".jpeg":
                    return TypeFiles.Images;
                case ".png":
                    return TypeFiles.Images;
                case ".gif":
                    return TypeFiles.Images;
                case ".txt":
                    return TypeFiles.Text;
                case ".rtf":
                    return TypeFiles.Text;
                case ".log":
                    return TypeFiles.Text;
                default:
                    return TypeFiles.Other;
            }
        }

    }
}
