using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll.Entities
{
    public class ChapterEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SourceUrl { get; set; }
        public string Body { get; set; }
    }
}
