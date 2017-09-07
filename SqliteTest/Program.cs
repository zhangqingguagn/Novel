using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db =  new testdb())
            {
                Student stu = new Student()
                {
                    name = "小张",
                    sex = "男"
                };
                db.Students.Add(stu);
                db.SaveChanges();

                var students = db.Students.ToList();
            }
        }
    }
}
