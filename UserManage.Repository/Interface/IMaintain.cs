namespace UserManage.Repository.Interface;

public interface IMaintain<T>
{
    bool Create(T param);
    IEnumerable<T> QueryAll();
    T Query(object param);
    bool Delete(object id);
    bool Update(object id, T param);
}