namespace Pool
{
  public interface IPoolElementReturner
  {
    void ReturnToPool(IPoolElement element);
  }
}