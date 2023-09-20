namespace Pool.Container
{
  public interface IPoolAccessor
  {
    IPoolElementReturner GetPool(IPoolElement element);
  }
}