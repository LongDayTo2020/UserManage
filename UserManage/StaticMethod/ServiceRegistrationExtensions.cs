using System.Reflection;

namespace UserManage.StaticMethod;

public static class ServiceRegistrationExtensions
{
    public static void RegisterServicesInAssembly(this IServiceCollection services, string assemblyName,
        string namespacePrefix)
    {
        Assembly assembly = Assembly.LoadFile(assemblyName);

        foreach (var type in assembly.GetTypes())
        {
            if (type.IsInterface && type.Name.EndsWith(namespacePrefix))
            {
                // 取得介面對應的實作類別
                Type implementationType = GetImplementationTypeForInterface(type);

                if (implementationType != null)
                {
                    // 建立服務描述並添加到 DI 容器中
                    ServiceDescriptor serviceDescriptor =
                        new ServiceDescriptor(type, implementationType, ServiceLifetime.Scoped);
                    services.Add(serviceDescriptor);
                }
            }
        }
    }

    // 取得介面對應的實作類別
    private static Type GetImplementationTypeForInterface(Type interfaceType)
    {
        // 根據您的邏輯找到介面對應的實作類別
        // 這裡只是一個示例，您需要根據您的專案邏輯自行實作

        // 假設介面的命名規則為 I[ServiceName]，例如 IMyService 對應 MyService
        string implementationTypeName = interfaceType.Name.Substring(1); // 移除 "I" 前綴
        string implementationFullTypeName = $"{interfaceType.Namespace}.{implementationTypeName}";

        Type implementationType = interfaceType.Assembly.GetType(implementationFullTypeName);

        return implementationType;
    }
}