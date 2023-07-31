using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IKost
    {
        ICollection<Kost> GetAllKost();
        ICollection<Kost> GetKostByCity(string city);
        ICollection<Kost> GetKostByIdTypeKost(int typeKostId);
        Kost GetKostById(int id);
        Kost GetKostByKostName(string kostName);
        void CreateKost(DetailKost detailKost);
    }
}