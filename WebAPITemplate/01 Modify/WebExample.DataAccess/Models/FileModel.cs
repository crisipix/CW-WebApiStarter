﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Models
{
    public class FileModel
    {
        public int FileId { get; set; }
        public byte[] Contents { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

    }
}
