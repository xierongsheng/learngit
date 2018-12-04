using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StudentManagerPro
{
    public class StudentDao
    {
        #region 添加学员对象

        /// <summary>
        /// 判断身份证号是否已经存在
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(*) from Students where StudentIdNo=" + studentIdNo;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 添加学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int AddStudent(Student objStudent)
        {
            //【1】编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(studentName,Gender,Birthday,");
            sqlBuilder.Append("StudentIdNo,PhoneNumber,StudentAddress,ClassId)");
            sqlBuilder.Append(" values('{0}','{1}','{2}','{3}','{4}','{5}',{6});select @@identity");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday,
                    objStudent.StudentIdNo,
                    objStudent.PhoneNumber, objStudent.StudentAddress,
                    objStudent.ClassId);
            try
            {
                //【3】执行SQL语句，返回结果
                return Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 查询学员信息

        /// <summary>
        /// 根据班级查询学员信息
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByClass(string className)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,StudentAddress from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " where ClassName='{0}'";
            sql = string.Format(sql, className);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (objReader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据学生编号查询学生信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentExt GetStudentById(string studentId)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,";
            sql += "StudentIdNo,PhoneNumber,StudentAddress,Students.ClassId from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " where StudentId=" + studentId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            StudentExt objStudent = null;
            if (objReader.Read())
            {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    ClassId = Convert.ToInt32(objReader["ClassId"])
                };
            }
            objReader.Close();
            return objStudent;
        }

        #endregion

        #region 修改学员信息

        /// <summary>
        /// 修改学员时判断身份证号是否和其他学员的重复
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string idNo, string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo="
                + idNo + " and StudentId<>" + studentId;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 修改学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int ModifyStudent(Student objStudent)
        {
            //【1】编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Students set studentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append("StudentIdNo={3},PhoneNumber='{4}',StudentAddress='{5}',ClassId={6}");
            sqlBuilder.Append(" where StudentId={7}");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday,
                    objStudent.StudentIdNo,
                    objStudent.PhoneNumber, objStudent.StudentAddress,
                    objStudent.ClassId, objStudent.StudentId);
            try
            {
                //【3】执行SQL语句，返回结果
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除学员对象

        /// <summary>
        /// 根据学号删除学员
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int DeleteStudentById(string studentId)
        {
            string sql = "delete from Students where StudentId=" + studentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该学号被其他实体引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        #endregion
    }
}