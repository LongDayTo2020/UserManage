namespace UserManage.Repository.Entity;

public class UserRoleGroupRelationship
{
    public int UserId { get; set; }
    public int RoleGroupId { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string? UpdateUser { get; set; }
}

