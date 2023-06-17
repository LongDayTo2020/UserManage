
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public class RoleRepository : IMaintain<Permission>
    {
        private readonly IDbConnection _iDbConnection;

        public RoleRepository ( IDbConnection iDbConnection ){
_iDbConnection = iDbConnection;
     }


        public bool Create(Permission permission)
        {
            string sql = @"  INSERT INTO roles  ( 
  create_time 
, update_time 
, name 
, create_user 
, update_user  )
 VALUES (  @CreateTime 
, @UpdateTime 
, @Name 
, @CreateUser 
, @UpdateUser )  ";
            return _iDbConnection.Execute(sql,permission) > 0;
        }

        public IEnumerable<Permission> QueryAll()
        {
            string sql = @"  SELECT 
 id
,create_time
,update_time
,name
,create_user
,update_user 
 FROM roles  ";
            return _iDbConnection.Query<Permission>(sql);
        }

        public Permission Query(object permission)
        {
            string sql = @" SELECT  
 id
,create_time
,update_time
,name
,create_user
,update_user 
 FROM roles 
 WHERE  id = @Id  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<Permission>(sql);
        }

        public bool Delete(object id)
        {
            string sql = @"  DELETE roles 
 WHERE 
 id = @Id  ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, Permission permission)
        {
            string sql = @" UPDATE roles 
 SET  create_time = @CreateTime 
, update_time = @UpdateTime 
, name = @Name 
, create_user = @CreateUser 
, update_user = @UpdateUser 
 WHERE  id = @Id  ";
            var parameters = new DynamicParameters(permission);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}
