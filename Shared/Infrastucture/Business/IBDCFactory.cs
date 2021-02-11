namespace Shared
{
    public interface IBDCFactory
    {
        IBusinessDomainComponent Create(BDCType type, params object[] args);
    }
}
