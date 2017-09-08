namespace Novel.Bll.DB
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class NovelDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“NovelDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Novel.Bll.DB.NovelDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“NovelDbContext”
        //连接字符串。
        public NovelDbContext()
            : base("name=NovelDbContext")
        {
            Database.SetInitializer<NovelDbContext>(null);
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<tSource> tSources { get; set; }
        public virtual DbSet<tNovel> tNovels { get; set; }
        public virtual DbSet<tChapter> tChapters { get; set; }
    }

    [Table("tSource", Schema = "dbo")]
    public class tSource
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
    [Table("tNovel", Schema = "dbo")]
    public class tNovel
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
    [Table("tChapter", Schema = "dbo")]
    public class tChapter
    {
        public int ID { get; set; }
        public int NovelID { get; set; }
        public string Title { get; set; }
        public string SourceUrl { get; set; }
        public string Body { get; set; }
        public int NextChapterID { get; set; }
        public int PrevChapterID { get; set; }
    }

}