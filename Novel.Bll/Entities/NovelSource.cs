using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll.Entities
{
    /// <summary>
    /// 小说来源网站配置
    /// </summary>
    public class NovelSource
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 小说章节目录XPath
        /// </summary>
        public string ChapterDirectoryXPath { get; set; }
        /// <summary>
        /// 小说内容 XPath
        /// </summary>
        public string ChapterBodyXpath { get; set; }
        /// <summary>
        /// 下一章 XPath
        /// </summary>
        public string NextChapterXpath { get; set; }
        /// <summary>
        /// 上一章 XPath
        /// </summary>
        public string PrevChapterXpath { get; set; }
        
    }
}
