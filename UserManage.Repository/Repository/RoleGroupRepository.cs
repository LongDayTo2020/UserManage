
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public interface IRoleGroupRepository
    {
        bool Create(RoleGroup roleGroup);
        IEnumerable<RoleGroup> QueryAll();
        RoleGroup Query(object roleGroup);
        bool Delete(object id);
        bool Update(object id, RoleGroup roleGroup);
    }

    public class RoleGroupRepository : IMaintain<RoleGroup>, IRoleGroupRepository
    {
        private readonly IDbConnection _iDbConnection;

        public RoleGroupRepository ( IDbConnection iDbConnection ){
_iDbConnection = iDbConnection;
     }


        public bool Create(RoleGroup roleGroup)
        {
            string sql = @"  INSERT INTO role_groups  ( 
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
            return _iDbConnection.Execute(sql,roleGroup) > 0;
        }

        public IEnumerable<RoleGroup> QueryAll()
        {
            string sql = @"  SELECT 
 id
,create_time
,update_time
,name
,create_user
,update_user 
 FROM role_groups  ";
            return _iDbConnection.Query<RoleGroup>(sql);
        }

        public RoleGroup Query(object roleGroup)
        {
            string sql = @" SELECT  
 id
,create_time
,update_time
,name
,create_user
,update_user 
 FROM role_groups 
 WHERE  id = @Id  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<RoleGroup>(sql);
        }

        public bool Delete(object id)
        {
            string sql = @"  DELETE role_groups 
 WHERE 
 id = @Id  ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, RoleGroup roleGroup)
        {
            string sql = @" UPDATE role_groups 
 SET  create_time = @CreateTime 
, update_time = @UpdateTime 
, name = @Name 
, create_user = @CreateUser 
, update_user = @UpdateUser 
 WHERE  id = @Id  ";
            var parameters = new DynamicParameters(roleGroup);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}
