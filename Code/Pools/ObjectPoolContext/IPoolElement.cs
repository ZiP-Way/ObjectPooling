namespace Pools.ObjectPoolContext
{
  public interface IPoolElement
  {
    void PrepareForUse();
    void FinalizeUse();
  }
}