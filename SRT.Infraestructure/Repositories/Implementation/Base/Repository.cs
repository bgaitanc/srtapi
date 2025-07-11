using SRT.Domain.Entities.Base;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Infraestructure.Repositories.Implementation.Base;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
}