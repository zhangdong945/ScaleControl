using System;
using System.IO;
using System.Reflection;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class DatabaseInitializer
    {
        private readonly IDatabaseConnectionFactory _factory;

        public DatabaseInitializer(IDatabaseConnectionFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// 从嵌入资源的空白数据库模板创建数据库
        /// </summary>
        public void CreateFromTemplate(string dbPath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string templateName = null;
            foreach (var name in assembly.GetManifestResourceNames())
            {
                if (name.EndsWith("empty_db.mdb"))
                {
                    templateName = name;
                    break;
                }
            }
            if (templateName == null)
            {
                throw new InvalidOperationException("找不到数据库模板文件 empty_db.mdb。");
            }
            using (var stream = assembly.GetManifestResourceStream(templateName))
            {
                using (var fileStream = new FileStream(dbPath, FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = _factory.CreateConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
