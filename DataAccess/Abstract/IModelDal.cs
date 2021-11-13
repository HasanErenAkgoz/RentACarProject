using Core.DataAccess.EntityFramework;
using Entity.Concrate;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
    }
}