using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;

namespace Garfield.DAL
{
    /// <summary>
    /// 数据访问类:hr_employee
    /// </summary>
    public partial class hr_employee
    {
        public hr_employee()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from hr_employee");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Garfield.Model.hr_employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hr_employee(");
            strSql.Append("uid,pwd,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin)");
            strSql.Append(" values (");
            strSql.Append("@uid,@pwd,@name,@idcard,@birthday,@d_id,@dname,@postid,@post,@email,@sex,@tel,@status,@zhiwuid,@zhiwu,@sort,@EntryDate,@address,@remarks,@education,@level,@professional,@schools,@title,@isDelete,@Delete_time,@portal,@theme,@canlogin)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.VarChar,50),
					new MySqlParameter("@pwd", MySqlDbType.VarChar,50),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@idcard", MySqlDbType.VarChar,50),
					new MySqlParameter("@birthday", MySqlDbType.VarChar,50),
					new MySqlParameter("@d_id", MySqlDbType.Int32,4),
					new MySqlParameter("@dname", MySqlDbType.VarChar,50),
					new MySqlParameter("@postid", MySqlDbType.Int32,4),
					new MySqlParameter("@post", MySqlDbType.VarChar,250),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@sex", MySqlDbType.VarChar,50),
					new MySqlParameter("@tel", MySqlDbType.VarChar,50),
					new MySqlParameter("@status", MySqlDbType.VarChar,50),
					new MySqlParameter("@zhiwuid", MySqlDbType.Int32,4),
					new MySqlParameter("@zhiwu", MySqlDbType.VarChar,50),
					new MySqlParameter("@sort", MySqlDbType.Int32,4),
					new MySqlParameter("@EntryDate", MySqlDbType.VarChar,50),
					new MySqlParameter("@address", MySqlDbType.VarChar,255),
					new MySqlParameter("@remarks", MySqlDbType.VarChar,255),
					new MySqlParameter("@education", MySqlDbType.VarChar,50),
					new MySqlParameter("@level", MySqlDbType.VarChar,50),
					new MySqlParameter("@professional", MySqlDbType.VarChar,50),
					new MySqlParameter("@schools", MySqlDbType.VarChar,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,50),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,4),
					new MySqlParameter("@Delete_time", MySqlDbType.DateTime),
					new MySqlParameter("@portal", MySqlDbType.VarChar,250),
					new MySqlParameter("@theme", MySqlDbType.VarChar,250),
					new MySqlParameter("@canlogin", MySqlDbType.Int32,4)};
            parameters[0].Value = model.uid;
            parameters[1].Value = model.pwd;
            parameters[2].Value = model.name;
            parameters[3].Value = model.idcard;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.d_id;
            parameters[6].Value = model.dname;
            parameters[7].Value = model.postid;
            parameters[8].Value = model.post;
            parameters[9].Value = model.email;
            parameters[10].Value = model.sex;
            parameters[11].Value = model.tel;
            parameters[12].Value = model.status;
            parameters[13].Value = model.zhiwuid;
            parameters[14].Value = model.zhiwu;
            parameters[15].Value = model.sort;
            parameters[16].Value = model.EntryDate;
            parameters[17].Value = model.address;
            parameters[18].Value = model.remarks;
            parameters[19].Value = model.education;
            parameters[20].Value = model.level;
            parameters[21].Value = model.professional;
            parameters[22].Value = model.schools;
            parameters[23].Value = model.title;
            parameters[24].Value = model.isDelete;
            parameters[25].Value = model.Delete_time;
            parameters[26].Value = model.portal;
            parameters[27].Value = model.theme;
            parameters[28].Value = model.canlogin;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Garfield.Model.hr_employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hr_employee set ");
            strSql.Append("uid=@uid,");
            strSql.Append("name=@name,");
            strSql.Append("idcard=@idcard,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("d_id=@d_id,");
            strSql.Append("dname=@dname,");
            strSql.Append("postid=@postid,");
            strSql.Append("post=@post,");
            strSql.Append("email=@email,");
            strSql.Append("sex=@sex,");
            strSql.Append("tel=@tel,");
            strSql.Append("status=@status,");
            strSql.Append("zhiwuid=@zhiwuid,");
            strSql.Append("zhiwu=@zhiwu,");
            strSql.Append("sort=@sort,");
            strSql.Append("EntryDate=@EntryDate,");
            strSql.Append("address=@address,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("education=@education,");
            strSql.Append("level=@level,");
            strSql.Append("professional=@professional,");
            strSql.Append("schools=@schools,");
            strSql.Append("title=@title,");
            strSql.Append("portal=@portal,");
            strSql.Append("theme=@theme,");
            strSql.Append("canlogin=@canlogin");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.VarChar,50),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@idcard", MySqlDbType.VarChar,50),
					new MySqlParameter("@birthday", MySqlDbType.VarChar,50),
					new MySqlParameter("@d_id", MySqlDbType.Int32,4),
					new MySqlParameter("@dname", MySqlDbType.VarChar,50),
					new MySqlParameter("@postid", MySqlDbType.Int32,4),
					new MySqlParameter("@post", MySqlDbType.VarChar,250),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@sex", MySqlDbType.VarChar,50),
					new MySqlParameter("@tel", MySqlDbType.VarChar,50),
					new MySqlParameter("@status", MySqlDbType.VarChar,50),
					new MySqlParameter("@zhiwuid", MySqlDbType.Int32,4),
					new MySqlParameter("@zhiwu", MySqlDbType.VarChar,50),
					new MySqlParameter("@sort", MySqlDbType.Int32,4),
					new MySqlParameter("@EntryDate", MySqlDbType.VarChar,50),
					new MySqlParameter("@address", MySqlDbType.VarChar,255),
					new MySqlParameter("@remarks", MySqlDbType.VarChar,255),
					new MySqlParameter("@education", MySqlDbType.VarChar,50),
					new MySqlParameter("@level", MySqlDbType.VarChar,50),
					new MySqlParameter("@professional", MySqlDbType.VarChar,50),
					new MySqlParameter("@schools", MySqlDbType.VarChar,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,50),  
					new MySqlParameter("@portal", MySqlDbType.VarChar,250),
					new MySqlParameter("@theme", MySqlDbType.VarChar,250),
					new MySqlParameter("@canlogin", MySqlDbType.Int32,4),
					new MySqlParameter("@ID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.uid;
            parameters[1].Value = model.name;
            parameters[2].Value = model.idcard;
            parameters[3].Value = model.birthday;
            parameters[4].Value = model.d_id;
            parameters[5].Value = model.dname;
            parameters[6].Value = model.postid;
            parameters[7].Value = model.post;
            parameters[8].Value = model.email;
            parameters[9].Value = model.sex;
            parameters[10].Value = model.tel;
            parameters[11].Value = model.status;
            parameters[12].Value = model.zhiwuid;
            parameters[13].Value = model.zhiwu;
            parameters[14].Value = model.sort;
            parameters[15].Value = model.EntryDate;
            parameters[16].Value = model.address;
            parameters[17].Value = model.remarks;
            parameters[18].Value = model.education;
            parameters[19].Value = model.level;
            parameters[20].Value = model.professional;
            parameters[21].Value = model.schools;
            parameters[22].Value = model.title;
            parameters[23].Value = model.portal;
            parameters[24].Value = model.theme;
            parameters[25].Value = model.canlogin;
            parameters[26].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 预删除
        /// </summary>
        public bool AdvanceDelete(int id, int isDelete, string time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hr_employee set ");
            strSql.Append("isDelete=" + isDelete);
            strSql.Append(",Delete_time='" + time + "'");
            strSql.Append(" where id=" + id);
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from hr_employee ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,4)
};
            parameters[0].Value = ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from hr_employee ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Garfield.Model.hr_employee GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  top 1 ID,uid,pwd,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin from hr_employee ");
            strSql.Append("select ID,uid,pwd,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin from hr_employee ");
            strSql.Append(" where ID=@ID");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,4)
};
            parameters[0].Value = ID;

            Garfield.Model.hr_employee model = new Garfield.Model.hr_employee();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["uid"] != null && ds.Tables[0].Rows[0]["uid"].ToString() != "")
                {
                    model.uid = ds.Tables[0].Rows[0]["uid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pwd"] != null && ds.Tables[0].Rows[0]["pwd"].ToString() != "")
                {
                    model.pwd = ds.Tables[0].Rows[0]["pwd"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["idcard"] != null && ds.Tables[0].Rows[0]["idcard"].ToString() != "")
                {
                    model.idcard = ds.Tables[0].Rows[0]["idcard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["birthday"] != null && ds.Tables[0].Rows[0]["birthday"].ToString() != "")
                {
                    model.birthday = ds.Tables[0].Rows[0]["birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["d_id"] != null && ds.Tables[0].Rows[0]["d_id"].ToString() != "")
                {
                    model.d_id = int.Parse(ds.Tables[0].Rows[0]["d_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dname"] != null && ds.Tables[0].Rows[0]["dname"].ToString() != "")
                {
                    model.dname = ds.Tables[0].Rows[0]["dname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["postid"] != null && ds.Tables[0].Rows[0]["postid"].ToString() != "")
                {
                    model.postid = int.Parse(ds.Tables[0].Rows[0]["postid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["post"] != null && ds.Tables[0].Rows[0]["post"].ToString() != "")
                {
                    model.post = ds.Tables[0].Rows[0]["post"].ToString();
                }
                if (ds.Tables[0].Rows[0]["email"] != null && ds.Tables[0].Rows[0]["email"].ToString() != "")
                {
                    model.email = ds.Tables[0].Rows[0]["email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null && ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tel"] != null && ds.Tables[0].Rows[0]["tel"].ToString() != "")
                {
                    model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = ds.Tables[0].Rows[0]["status"].ToString();
                }
                if (ds.Tables[0].Rows[0]["zhiwuid"] != null && ds.Tables[0].Rows[0]["zhiwuid"].ToString() != "")
                {
                    model.zhiwuid = int.Parse(ds.Tables[0].Rows[0]["zhiwuid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zhiwu"] != null && ds.Tables[0].Rows[0]["zhiwu"].ToString() != "")
                {
                    model.zhiwu = ds.Tables[0].Rows[0]["zhiwu"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sort"] != null && ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EntryDate"] != null && ds.Tables[0].Rows[0]["EntryDate"].ToString() != "")
                {
                    model.EntryDate = ds.Tables[0].Rows[0]["EntryDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remarks"] != null && ds.Tables[0].Rows[0]["remarks"].ToString() != "")
                {
                    model.remarks = ds.Tables[0].Rows[0]["remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["education"] != null && ds.Tables[0].Rows[0]["education"].ToString() != "")
                {
                    model.education = ds.Tables[0].Rows[0]["education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["level"] != null && ds.Tables[0].Rows[0]["level"].ToString() != "")
                {
                    model.level = ds.Tables[0].Rows[0]["level"].ToString();
                }
                if (ds.Tables[0].Rows[0]["professional"] != null && ds.Tables[0].Rows[0]["professional"].ToString() != "")
                {
                    model.professional = ds.Tables[0].Rows[0]["professional"].ToString();
                }
                if (ds.Tables[0].Rows[0]["schools"] != null && ds.Tables[0].Rows[0]["schools"].ToString() != "")
                {
                    model.schools = ds.Tables[0].Rows[0]["schools"].ToString();
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isDelete"] != null && ds.Tables[0].Rows[0]["isDelete"].ToString() != "")
                {
                    model.isDelete = int.Parse(ds.Tables[0].Rows[0]["isDelete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Delete_time"] != null && ds.Tables[0].Rows[0]["Delete_time"].ToString() != "")
                {
                    model.Delete_time = DateTime.Parse(ds.Tables[0].Rows[0]["Delete_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["portal"] != null && ds.Tables[0].Rows[0]["portal"].ToString() != "")
                {
                    model.portal = ds.Tables[0].Rows[0]["portal"].ToString();
                }
                if (ds.Tables[0].Rows[0]["theme"] != null && ds.Tables[0].Rows[0]["theme"].ToString() != "")
                {
                    model.theme = ds.Tables[0].Rows[0]["theme"].ToString();
                }
                if (ds.Tables[0].Rows[0]["canlogin"] != null && ds.Tables[0].Rows[0]["canlogin"].ToString() != "")
                {
                    model.canlogin = int.Parse(ds.Tables[0].Rows[0]["canlogin"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,uid,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin ");
            strSql.Append(" FROM hr_employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            //if (Top > 0)
            //{
            //    strSql.Append(" top " + Top.ToString());
            //}
            strSql.Append(" ID,uid,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin ");
            strSql.Append(" FROM hr_employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder, out string Total)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            strSql.Append("select ");
            //strSql.Append(" top " + PageSize + " ID,uid,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin FROM hr_employee ");
            strSql.Append(" ID,uid,name,idcard,birthday,d_id,dname,postid,post,email,sex,tel,status,zhiwuid,zhiwu,sort,EntryDate,address,remarks,education,level,professional,schools,title,isDelete,Delete_time,portal,theme,canlogin FROM hr_employee where 1=1 ");
            //strSql.Append(" WHERE id not in ( SELECT top " + (PageIndex - 1) * PageSize + " id FROM hr_employee ");
            //strSql.Append(" where " + strWhere + " order by " + filedOrder +")");
            strSql1.Append(" select count(id) FROM hr_employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
                strSql1.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            strSql.Append(" limit " + (PageIndex - 1) * PageSize + "," + PageSize);
            Total = DbHelperMySQL.Query(strSql1.ToString()).Tables[0].Rows[0][0].ToString();
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取密码
        /// </summary>
        public DataSet GetPWD(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pwd ");
            strSql.Append(" FROM hr_employee ");
            strSql.Append(" WHERE ID =" + ID);

            return DbHelperMySQL.Query(strSql.ToString());
        }
        public bool changepwd(Garfield.Model.hr_employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hr_employee set ");
            strSql.Append("pwd=@pwd");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {					
					new MySqlParameter("@pwd", MySqlDbType.VarChar,50),					
					new MySqlParameter("@ID", MySqlDbType.Int32,4)};

            parameters[0].Value = model.pwd;
            parameters[1].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新岗位
        /// </summary>
        public bool UpdatePost(Garfield.Model.hr_employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hr_employee set ");

            strSql.Append("d_id=@d_id,");
            strSql.Append("dname=@dname,");
            strSql.Append("postid=@postid,");
            strSql.Append("post=@post,");
            strSql.Append("zhiwuid=@zhiwuid,");
            strSql.Append("zhiwu=@zhiwu");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("@d_id", MySqlDbType.Int32,4),
					new MySqlParameter("@dname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@postid", MySqlDbType.Int32,4),
					new MySqlParameter("@post", MySqlDbType.VarChar,250),
					new MySqlParameter("@zhiwuid", MySqlDbType.Int32,4),
					new MySqlParameter("@zhiwu", MySqlDbType.VarChar,50),
					new MySqlParameter("@ID", MySqlDbType.Int32,4)};

            parameters[0].Value = model.d_id;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.postid;
            parameters[3].Value = model.post;
            parameters[4].Value = model.zhiwuid;
            parameters[5].Value = model.zhiwu;
            parameters[6].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取角色
        /// </summary>
        public DataSet GetRole(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Sys_role where RoleID in ");
            strSql.Append("(select RoleID from Sys_role_emp where empID=" + ID + ")  ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 个人信息修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool PersonalUpdate(Garfield.Model.hr_employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hr_employee set ");
            strSql.Append("name=@name,");
            strSql.Append("idcard=@idcard,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("email=@email,");
            strSql.Append("sex=@sex,");
            strSql.Append("tel=@tel,");
            strSql.Append("address=@address,");
            strSql.Append("education=@education,");
            strSql.Append("level=@level,");
            strSql.Append("professional=@professional,");
            strSql.Append("schools=@schools,");
            strSql.Append("title=@title");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@idcard", MySqlDbType.VarChar,50),
					new MySqlParameter("@birthday", MySqlDbType.VarChar,50),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@sex", MySqlDbType.VarChar,50),
					new MySqlParameter("@tel", MySqlDbType.VarChar,50),
					new MySqlParameter("@address", MySqlDbType.VarChar,255),
					new MySqlParameter("@education", MySqlDbType.VarChar,50),
					new MySqlParameter("@level", MySqlDbType.VarChar,50),
					new MySqlParameter("@professional", MySqlDbType.VarChar,50),
					new MySqlParameter("@schools", MySqlDbType.VarChar,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,50),
					new MySqlParameter("@ID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.idcard;
            parameters[2].Value = model.birthday;
            parameters[3].Value = model.email;
            parameters[4].Value = model.sex;
            parameters[5].Value = model.tel;
            parameters[6].Value = model.address;
            parameters[7].Value = model.education;
            parameters[8].Value = model.level;
            parameters[9].Value = model.professional;
            parameters[10].Value = model.schools;
            parameters[11].Value = model.title;
            parameters[12].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新客户，订单，合同，收款，开票 人员
        /// </summary>
        public bool UpdateCOCRI(Garfield.Model.hr_employee model)
        {
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("UPDATE CRM_Customer SET ");
            strSql1.Append("Department_id=@dep_id,");
            strSql1.Append("Department=@dep_name,");
            strSql1.Append("Employee=@emp_name");
            strSql1.Append(" where Employee_id=@emp_id");

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("UPDATE CRM_order SET ");
            strSql2.Append("C_dep_id=@dep_id,");
            strSql2.Append("C_dep_name=@dep_name,");
            strSql2.Append("C_emp_name=@emp_name");
            strSql2.Append(" where C_emp_id=@emp_id");

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("UPDATE CRM_order SET ");
            strSql3.Append("F_dep_id=@dep_id,");
            strSql3.Append("F_dep_name=@dep_name,");
            strSql3.Append("F_emp_name=@emp_name");
            strSql3.Append(" where F_emp_id=@emp_id");

            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("UPDATE CRM_contract SET ");
            strSql4.Append("C_depid=@dep_id,");
            strSql4.Append("C_depname=@dep_name,");
            strSql4.Append("C_empname=@emp_name");
            strSql4.Append(" where C_empid=@emp_id");

            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("UPDATE CRM_contract SET ");
            strSql5.Append("Our_Contractor_depid=@dep_id,");
            strSql5.Append("Our_Contractor_depname=@dep_name,");
            strSql5.Append("Our_Contractor_name=@emp_name");
            strSql5.Append(" where Our_Contractor_id=@emp_id");

            StringBuilder strSql6 = new StringBuilder();
            strSql6.Append("UPDATE CRM_receive SET ");
            strSql6.Append("C_depid=@dep_id,");
            strSql6.Append("C_depname=@dep_name,");
            strSql6.Append("C_empname=@emp_name");
            strSql6.Append(" where C_empid=@emp_id");

            StringBuilder strSql7 = new StringBuilder();
            strSql7.Append("UPDATE CRM_receive SET ");
            strSql7.Append("C_depid=@dep_id,");
            strSql7.Append("C_depname=@dep_name,");
            strSql7.Append("C_empname=@emp_name");
            strSql7.Append(" where C_empid=@emp_id");

            MySqlParameter[] parameters = {					
					new MySqlParameter("@dep_id", MySqlDbType.Int32,4),
					new MySqlParameter("@dep_name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@emp_id", MySqlDbType.Int32,4),
					new MySqlParameter("@emp_name", MySqlDbType.VarChar,250)
					};

            parameters[0].Value = model.d_id;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.ID;
            parameters[3].Value = model.name;

            int rows1 = DbHelperMySQL.ExecuteSql(strSql1.ToString(), parameters);
            int rows2 = DbHelperMySQL.ExecuteSql(strSql2.ToString(), parameters);
            int rows3 = DbHelperMySQL.ExecuteSql(strSql3.ToString(), parameters);
            int rows4 = DbHelperMySQL.ExecuteSql(strSql4.ToString(), parameters);
            int rows5 = DbHelperMySQL.ExecuteSql(strSql5.ToString(), parameters);
            int rows6 = DbHelperMySQL.ExecuteSql(strSql6.ToString(), parameters);
            int rows7 = DbHelperMySQL.ExecuteSql(strSql7.ToString(), parameters);
            if (rows1 > 0 && rows2 > 0 && rows3 > 0 && rows4 > 0 && rows5 > 0 && rows6 > 0 && rows7 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  Method
    }
}

