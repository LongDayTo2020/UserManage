
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public interface IRoleRepository
    {
        bool Create(Role role);
        IEnumerable<Role> QueryAll();
        Role Query(object role);
        bool Delete(object id);
        bool Update(object id, Role role);
    }

    public class RoleRepository : IMaintain<Role>, IRoleRepository
    {
        private readonly IDbConnection _iDbConnection;

        public RoleRepository ( IDbConnection iDbConnection ){
_iDbConnection = iDbConnection;
     }


        public bool Create(Role role)
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
            return _iDbConnection.Execute(sql,role) > 0;
        }

        public IEnumerable<Role> QueryAll()
        {
            string sql = @"  SELECT 
 id
,create_time
,update_time
,name
,create_user
,update_user 
 FROM roles  ";
            return _iDbConnection.Query<Role>(sql);
        }

        public Role Query(object role)
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
            return _iDbConnection.QueryFirstOrDefault<Role>(sql);
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

        public bool Update(object id, Role role)
        {
            string sql = @" UPDATE roles 
 SET  create_time = @CreateTime 
, update_time = @UpdateTime 
, name = @Name 
, create_user = @CreateUser 
, update_user = @UpdateUser 
 WHERE  id = @Id  ";
            var parameters = new DynamicParameters(role);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}
