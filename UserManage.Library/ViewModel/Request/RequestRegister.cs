namespace UserManage.Library.ViewModel.Request;

public class RequestRegister
{
    public string Name { get; set; }
    public string Account { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
}