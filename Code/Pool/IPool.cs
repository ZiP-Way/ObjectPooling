namespace Pool
{
  public interface IPool<T> : IPoolElementReturner where T : IPoolElement
  {
    bool HasFreeElements { get; }
    int FreeElementsCount { get; }
    void CreatePool(string poolName, int elementsCount);
    T GetFreeElement();
  }
}