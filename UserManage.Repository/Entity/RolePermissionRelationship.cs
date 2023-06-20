namespace UserManage.Repository.Entity;

public class RolePermissionRelationship
{
    public int RoleId { get; set; }
    public int PermissionsId { get; set; }
    public int IsCreate { get; set; }
    public int IsUpdate { get; set; }
    public int IsRead { get; set; }
    public int IsDelete { get; set; }
    public int IsVerify { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string? UpdateUser { get; set; }
}

