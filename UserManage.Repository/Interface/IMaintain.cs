namespace UserManage.Repository.Interface;

public interface IMaintain<T>
{
    public bool Create(T param);
    public IEnumerable<T> QueryAll();
    public T Query(object param);
    public bool Delete(object id);
    public bool Update(object id, T param);
}