using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IKostType
    {
        ICollection<KostType> GetAllkostTypes();
        KostType GetKostTypeById(int id);
    }
}
