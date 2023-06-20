using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public interface IRoleRoleGroupRelationshipRepository
    {
        bool Create(RoleRoleGroupRelationship roleRoleGroup);
        IEnumerable<RoleRoleGroupRelationship> QueryAll();
        RoleRoleGroupRelationship Query(object roleRoleGroup);
        bool Delete(object id);
        bool Update(object id, RoleRoleGroupRelationship roleRoleGroup);
    }

    public class RoleRoleGroupRelationshipRepository : IMaintain<RoleRoleGroupRelationship>,
        IRoleRoleGroupRelationshipRepository
    {
        private readonly IDbConnection _iDbConnection;

        public RoleRoleGroupRelationshipRepository(IDbConnection iDbConnection)
        {
            _iDbConnection = iDbConnection;
        }


        public bool Create(RoleRoleGroupRelationship roleRoleGroup)
        {
            string sql = @"  insert into roles_role_groups_relationships 
      (role_id, role_group_id, create_time, create_user, update_time, update_user)
 VALUES (  
  @RoleId
, @RoleGroupId 
, @CreateTime
, @CreateUser
, @UpdateTime   
, @UpdateUser )  ";
            return _iDbConnection.Execute(sql, roleRoleGroup) > 0;
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

        public RoleRoleGroupRelationship Query(object roleRoleGroup)
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
 role_group_id = @RoleGroupId  LIMIT 1  ";
            var parameters = new DynamicParameters();
            parameters.Add("RoleId", roleRoleGroup.GetType().GetField("RoleId").GetValue(roleRoleGroup),
                System.Data.DbType.Int32);
            parameters.Add("RoleGroupId", roleRoleGroup.GetType().GetField("RoleGroupId").GetValue(roleRoleGroup),
                System.Data.DbType.Int32);

            return _iDbConnection.QueryFirstOrDefault<RoleRoleGroupRelationship>(sql);
        }

        public bool Delete(object roleRoleGroup)
        {
            string sql = @"  DELETE roles_role_groups_relationships 
 WHERE 
 role_id = @RoleId 
AND role_group_id = @RoleGroupId  ";
            var parameters = new DynamicParameters();
            parameters.Add("RoleId", roleRoleGroup.GetType().GetField("RoleId").GetValue(roleRoleGroup),
                System.Data.DbType.Int32);
            parameters.Add("RoleGroupId", roleRoleGroup.GetType().GetField("RoleGroupId").GetValue(roleRoleGroup),
                System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, RoleRoleGroupRelationship permission)
        {
            return true;
        }
    }
}