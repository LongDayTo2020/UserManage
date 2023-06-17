
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public class RoleRoleGroupRelationshipRepository : IMaintain<Permission>
    {
        private readonly IDbConnection _iDbConnection;

        public RoleRoleGroupRelationshipRepository ( IDbConnection iDbConnection ){
_iDbConnection = iDbConnection;
     }


        public bool Create(Permission permission)
        {
            string sql = @"  INSERT INTO roles_permissions_relationships  ( 
  create 
, update 
, read 
, delete 
, verify 
, create_time 
, update_time 
, update_user 
, create_user  )
 VALUES (  @Create 
, @Update 
, @Read 
, @Delete 
, @Verify 
, @CreateTime 
, @UpdateTime 
, @UpdateUser 
, @CreateUser )  ";
            return _iDbConnection.Execute(sql,permission) > 0;
        }

        public IEnumerable<Permission> QueryAll()
        {
            string sql = @"  SELECT 
 role_id
,permissions_id
,create
,update
,read
,delete
,verify
,create_time
,update_time
,update_user
,create_user 
 FROM roles_permissions_relationships  ";
            return _iDbConnection.Query<Permission>(sql);
        }

        public Permission Query(object permission)
        {
            string sql = @" SELECT  
 role_id
,permissions_id
,create
,update
,read
,delete
,verify
,create_time
,update_time
,update_user
,create_user 
 FROM roles_permissions_relationships 
 WHERE  role_id = @RoleId  AND 
, permissions_id = @PermissionsId  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<Permission>(sql);
        }

        public bool Delete(object id)
        {
            string sql = @"  DELETE roles_permissions_relationships 
 WHERE 
 role_id = @RoleId 
, permissions_id = @PermissionsId  ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, Permission permission)
        {
            string sql = @" UPDATE roles_permissions_relationships 
 SET  create = @Create 
, update = @Update 
, read = @Read 
, delete = @Delete 
, verify = @Verify 
, create_time = @CreateTime 
, update_time = @UpdateTime 
, update_user = @UpdateUser 
, create_user = @CreateUser 
 WHERE  role_id = @RoleId  
, permissions_id = @PermissionsId  ";
            var parameters = new DynamicParameters(permission);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}
