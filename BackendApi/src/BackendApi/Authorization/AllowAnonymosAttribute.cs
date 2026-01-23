namespace BackendApi.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymosAttribute: Attribute
    {
    }
}
