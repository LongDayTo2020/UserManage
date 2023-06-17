namespace UserManage.Repository.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Account { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string? UpdateUser { get; set; }
}

