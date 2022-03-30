﻿namespace lab4.Storage.Entity
{
    public class MyFileInfo
    {
        public MyFileInfo(byte[] file, string fileName, string extension)
        {
            File = file;
            Extension = extension;
            FileName = fileName;
        }

        public byte[] File { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
    }
}
