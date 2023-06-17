namespace UserManage.Repository.Entity;

public class RoleRoleGroupRelationship
{
    public int RoleId { get; set; }
    public int RoleGroupId { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string? UpdateUser { get; set; }
}

