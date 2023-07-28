using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IOwner
    {
        void RegisterOwner(DetailOwner detailOwner);
        void UpdateOwner(DetailOwner detailOwner);
    }
}