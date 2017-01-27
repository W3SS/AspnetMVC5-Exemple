using ModuloCongresso.Infra.Data.Interfaces;

namespace ModuloCongresso.Application.Services.Common
{
    public class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
