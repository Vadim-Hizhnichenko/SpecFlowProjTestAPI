using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Entity
{
    public class PictureFile
    {
        public int ContentLength { get; set; }
        public object ContentType { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
    }
}
