using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll.Entities
{
    /// <summary>
    /// 小说实体
    /// </summary>
    public class NovelEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 小说标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 来源网站 ID
        /// </summary>
        public int SourceID { get; set; }
        /// <summary>
        /// 章节目录网址
        /// </summary>
        public string ChapterDirectoryUrl { get; set; }

    }
}
