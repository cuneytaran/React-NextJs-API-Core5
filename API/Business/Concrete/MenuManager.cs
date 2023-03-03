using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public IDataResult<List<Menu>> GetAll()
        {

            return new SuccessDataResult<List<Menu>>(_menuDal.GetAll(), Messages.MenuListed);
        }
    }
}
