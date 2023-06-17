namespace UserManage.Repository.Entity;

public class RolePermissionRelationship
{
    public int RoleId { get; set; }
    public int PermissionsId { get; set; }
    public int Create { get; set; }
    public int Update { get; set; }
    public int Read { get; set; }
    public int Delete { get; set; }
    public int Verify { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string? UpdateUser { get; set; }
}

