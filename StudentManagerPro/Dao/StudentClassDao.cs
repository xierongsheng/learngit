using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace StudentManagerPro
{
    public class StudentClassDao
    {
        /// <summary>
        /// 获取所有的班级对象
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetAllClasses()
        {
            string sql = "select className,ClassId from StudentClass";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (objReader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassName = objReader["ClassName"].ToString(),
                    ClassId = Convert.ToInt32(objReader["ClassId"])
                });
            }
            objReader.Close();
            return list;
        }    
    }
}