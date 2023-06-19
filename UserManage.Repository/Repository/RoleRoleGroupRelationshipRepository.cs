using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public interface IRoleRoleGroupRelationshipRepository
    {
        bool Create(RoleRoleGroupRelationship permission);
        IEnumerable<RoleRoleGroupRelationship> QueryAll();
        RoleRoleGroupRelationship Query(object permission);
        bool Delete(object id);
        bool Update(object id, RoleRoleGroupRelationship permission);
    }

    public class RoleRoleGroupRelationshipRepository : IMaintain<RoleRoleGroupRelationship>,
        IRoleRoleGroupRelationshipRepository
    {
        private readonly IDbConnection _iDbConnection;

        public RoleRoleGroupRelationshipRepository(IDbConnection iDbConnection)
        {
            _iDbConnection = iDbConnection;
        }


        public bool Create(RoleRoleGroupRelationship permission)
        {
            string sql = @"  insert into roles_role_groups_relationships 
      (role_id, role_group_id, create_time, create_user, update_time, update_user)
 VALUES (  
  @RoleId
, @PermissionsId 
, @CreateTime 
, @UpdateTime 
, @UpdateUser 
, @CreateUser )  ";
            return _iDbConnection.Execute(sql, permission) > 0;
        }

        public IEnumerable<RoleRoleGroupRelationship> QueryAll()
        {
            string sql = @"  SELECT 
 role_id
,role_group_id
,create_time
,update_time
,update_user
,create_user 
 FROM roles_role_groups_relationships  ";
            return _iDbConnection.Query<RoleRoleGroupRelationship>(sql);
        }

        public RoleRoleGroupRelationship Query(object permission)
        {
            string sql = @" SELECT  
 role_id
,role_group_id
,create_time
,update_time
,update_user
,create_user 
 FROM roles_role_groups_relationships 
 WHERE  role_id = @RoleId  AND 
, permissions_id = @RoleRoleGroupRelationshipsId  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<RoleRoleGroupRelationship>(sql);
        }

        public bool Delete(object id)
        {
            string sql = @"  DELETE roles_role_groups_relationships 
 WHERE 
 role_id = @RoleId 
, role_group_id = @RoleGroupId  ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, RoleRoleGroupRelationship permission)
        {
            return true;
        }
    }
}