namespace UserManage.Library.ViewModel.Request;

public class RequestAuthorization
{
    public int RoleId { get; set; }
    public int PermissionsId { get; set; }
    public int Create { get; set; }
    public int Update { get; set; }
    public int Read { get; set; }
    public int Delete { get; set; }
    public int Verify { get; set; }
}