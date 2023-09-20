namespace Pool.Container
{
  public interface IGlobalElementsContainer
  {
    void AddElementToContainer(IPoolElement element, IPoolElementReturner pool);
  }
}