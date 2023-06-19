namespace UserManage.Library.ViewModel.Request;

public class RequestAuthorization
{
    public int RoleId { get; set; }
    public int PermissionsId { get; set; }
    public int IsCreate { get; set; }
    public int IsUpdate { get; set; }
    public int IsRead { get; set; }
    public int IsDelete { get; set; }
    public int IsVerify { get; set; }
}