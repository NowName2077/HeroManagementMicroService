namespace HeroManagementMicroService.Application.Modelse.Base;

public interface IModel<out TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get;}
}