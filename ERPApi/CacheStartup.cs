using ERPApi.Entities.ASM;
using ERPApi.Entities.WFM;

namespace ERPApi
{
    public class CacheStartup
    {
        public CacheStartup()
        {
            Status.Instance.CacheAll();
            Dictionary.Instance.CacheAll();
        }
    }
}
