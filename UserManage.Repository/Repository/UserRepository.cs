
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace UserManage.Repository.Repository
{
    public class UserRepository : IMaintain<User>
    {
        private readonly IDbConnection _iDbConnection;

        public UserRepository ( IDbConnection iDbConnection ){
_iDbConnection = iDbConnection;
     }


        public bool Create(User user)
        {
            string sql = @"  INSERT INTO users  ( 
  create_time 
, birthday 
, update_time 
, phone 
, password 
, create_user 
, update_user 
, name 
, account 
, mail  )
 VALUES (  @CreateTime 
, @Birthday 
, @UpdateTime 
, @Phone 
, @Password 
, @CreateUser 
, @UpdateUser 
, @Name 
, @Account 
, @Mail )  ";
            return _iDbConnection.Execute(sql,user) > 0;
        }

        public IEnumerable<User> QueryAll()
        {
            string sql = @"  SELECT 
 create_time
,birthday
,update_time
,id
,phone
,password
,create_user
,update_user
,name
,account
,mail 
 FROM users  ";
            return _iDbConnection.Query<User>(sql);
        }

        public User Query(object user)
        {
            string sql = @" SELECT  
 create_time
,birthday
,update_time
,id
,phone
,password
,create_user
,update_user
,name
,account
,mail 
 FROM users 
 WHERE  id = @Id  LIMIT 1  ";
            return _iDbConnection.QueryFirstOrDefault<User>(sql);
        }

        public bool Delete(object id)
        {
            string sql = @"  DELETE users 
 WHERE 
 id = @Id  ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }

        public bool Update(object id, User user)
        {
            string sql = @" UPDATE users 
 SET  create_time = @CreateTime 
, birthday = @Birthday 
, update_time = @UpdateTime 
, phone = @Phone 
, password = @Password 
, create_user = @CreateUser 
, update_user = @UpdateUser 
, name = @Name 
, account = @Account 
, mail = @Mail 
 WHERE  id = @Id  ";
            var parameters = new DynamicParameters(user);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            return _iDbConnection.Execute(sql, parameters) > 0;
        }
    }
}
