namespace AdminService.SharedServices
{
    public interface IEntityFrameworkObjectId<Type>
    {
        Type Id { get; set; }
    }
}
