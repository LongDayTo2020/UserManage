
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public class UserRoleGroupRelationshipRepository : IMaintain<UserRoleGroupRelationship>
    {
        private readonly IDbConnection _iDbConnection;

        public UserRoleGroupRelationshipRepository ( IDbConnection iDbConnection ){
_iDbConnection = iDbConnection;
     }


        public bool Create(UserRoleGroupRelationship userRoleGroupRelationship)
        {
            string sql = @"  INSERT INTO users_role_groups_relationships  ( 
  user_id
, role_group_id
, create_time 
, update_time 
, create_user 
, update_user  )
 VALUES (  
  @UserId
, @RoleGroupId
, @CreateTime 
, @UpdateTime 
, @CreateUser 
, @UpdateUser )  ";
            return _iDbConnection.Execute(sql,userRoleGroupRelationship) > 0;
        }

        public IEnumerable<UserRoleGroupRelationship> QueryAll()
        {
            string sql = @"  SELECT 
 user_id
,role_group_id
,create_time
,update_time
,create_user
,update_user 
 FROM users_role_groups_relationships  ";
            return _iDbConnection.Query<UserRoleGroupRelationship>(sql);
        }

        public UserRoleGroupRelationship Query(object userRoleGroupRelationship)
        {
            string sql = @" SELECT  
 user_id
,role_group_id
,create_time
,update_time
,create_user
,update_user 
 FROM users_role_groups_relationships 
 WHERE  user_id = @UserId  AND 
 role_group_id = @RoleGroupId  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<UserRoleGroupRelationship>(sql);
        }

        public bool Delete(object id)
        {
            string sql = @"  DELETE users_role_groups_relationships 
 WHERE 
 user_id = @UserId 
, role_group_id = @RoleGroupId  ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, UserRoleGroupRelationship userRoleGroupRelationship)
        {
            string sql = @" UPDATE users_role_groups_relationships 
 SET  create_time = @CreateTime 
, update_time = @UpdateTime 
, create_user = @CreateUser 
, update_user = @UpdateUser 
 WHERE  user_id = @UserId AND  
 role_group_id = @RoleGroupId  ";
            var parameters = new DynamicParameters(userRoleGroupRelationship);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}
