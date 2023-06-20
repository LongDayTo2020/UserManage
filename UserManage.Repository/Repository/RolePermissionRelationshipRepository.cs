using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public interface IRolePermissionRelationshipRepository
    {
        bool Create(RolePermissionRelationship rolePermissionRelationship);
        IEnumerable<RolePermissionRelationship> QueryAll();
        RolePermissionRelationship Query(object rolePermissionRelationship);
        bool Delete(object id);
        bool Update(object id, RolePermissionRelationship rolePermissionRelationship);
    }

    public class RolePermissionRelationshipRepository : IMaintain<RolePermissionRelationship>,
        IRolePermissionRelationshipRepository
    {
        private readonly IDbConnection _iDbConnection;

        public RolePermissionRelationshipRepository(IDbConnection iDbConnection)
        {
            _iDbConnection = iDbConnection;
        }


        public bool Create(RolePermissionRelationship rolePermissionRelationship)
        {
            string sql = @"  INSERT INTO roles_permissions_relationships  ( 
  role_id
, permissions_id                                          
, is_create 
, is_update 
, is_read 
, is_delete 
, is_verify 
, create_time 
, update_time 
, update_user 
, create_user  )
 VALUES (
  @RoleId
, @PermissionsId
, @IsCreate 
, @IsUpdate 
, @IsRead 
, @IsDelete 
, @IsVerify 
, @CreateTime 
, @UpdateTime 
, @UpdateUser 
, @CreateUser )  ";
            return _iDbConnection.Execute(sql, rolePermissionRelationship) > 0;
        }

        public IEnumerable<RolePermissionRelationship> QueryAll()
        {
            string sql = @"  SELECT 
  role_id
, permissions_id
, is_create 
, is_update 
, is_read 
, is_delete 
, is_verify 
,create_time
,update_time
,update_user
,create_user 
 FROM roles_permissions_relationships  ";
            return _iDbConnection.Query<RolePermissionRelationship>(sql);
        }

        public RolePermissionRelationship Query(object rolePermissionRelationship)
        {
            string sql = @" SELECT  
 role_id
,permissions_id
, is_create 
, is_update 
, is_read 
, is_delete 
, is_verify 
,create_time
,update_time
,update_user
,create_user 
 FROM roles_permissions_relationships 
 WHERE  role_id = @RoleId  AND 
 permissions_id = @PermissionsId  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<RolePermissionRelationship>(sql);
        }

        public bool Delete(object rolePermission)
        {
            string sql = @"  DELETE roles_permissions_relationships 
  WHERE 
  role_id = @RoleId 
AND permissions_id = @PermissionsId  ";
            var parameters = new DynamicParameters();
            parameters.Add("RoleId", rolePermission.GetType().GetField("RoleId").GetValue(rolePermission),
                System.Data.DbType.Int32);
            parameters.Add("RoleGroupId", rolePermission.GetType().GetField("PermissionsId").GetValue(rolePermission),
                System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, RolePermissionRelationship rolePermissionRelationship)
        {
            string sql = @" UPDATE roles_permissions_relationships 
 SET  is_create = @IsCreate 
, is_update = @IsUpdate 
, is_read = @IsRead 
, is_delete = @IsDelete 
, is_verify = @IsVerify
, update_time = @UpdateTime 
, update_user = @UpdateUser 
 WHERE  role_id = @RoleId  
AND permissions_id = @PermissionsId  ";
            var parameters = new DynamicParameters(rolePermissionRelationship);
            parameters.Add("IsCreate", rolePermissionRelationship.CreateTime, System.Data.DbType.DateTime);
            parameters.Add("IsUpdate", rolePermissionRelationship.IsUpdate, System.Data.DbType.Int32);
            parameters.Add("IsRead", rolePermissionRelationship.IsRead, System.Data.DbType.Int32);
            parameters.Add("IsDelete", rolePermissionRelationship.IsDelete, System.Data.DbType.Int32);
            parameters.Add("IsVerify", rolePermissionRelationship.IsVerify, System.Data.DbType.Int32);
            parameters.Add("UpdateTime", rolePermissionRelationship.UpdateTime, System.Data.DbType.DateTime);
            parameters.Add("UpdateUser", rolePermissionRelationship.UpdateUser, System.Data.DbType.String);
            parameters.Add("RoleId", rolePermissionRelationship.RoleId, System.Data.DbType.Int32);
            parameters.Add("PermissionsId", rolePermissionRelationship.PermissionsId, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}