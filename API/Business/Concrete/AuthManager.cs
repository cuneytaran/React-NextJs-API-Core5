using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    //[PerformanceAspect(5)]//5 saniye geçerse beni uyar
    //[SecuredOperation("product.add,admin")] //producd.add menüsünü admin kullanabilir
    //[LogAspect(typeof(FileLogger))] //local dosya loglama
    //[LogAspect(typeof(DatabaseLogger))] //veritabanı loglama
    //[ValidationAspect(typeof(ProductValidator))] //validasyon kontrolü
    //[ValidationAspect(typeof(ProductValidator), Priority = 1)]
    //[CacheAspect] //key,value ve süre
    //[CacheAspect(duration: 10)] //10 saatlik bir cache tut
    //[CacheRemoveAspect]//Tüm belleği sil
    //[CacheRemoveAspect("IProductService.Get")]//IProductService deki Get leri sil
    //[CacheRemoveAspect("Get")]//bellekteki içinde Get geçenleri sil
    //[TransactionScopeAspect] // hata olursa. veritabanındaki kaydı geri al
    //ILogger yönetmiyle database loglama. Product manager de Add de örneği var.


    //*******************POSTMAN*************************
    //LOGIN
    //http://localhost:44354/api/auth/login
    //{
    //  "email": "cuneytaran@gmail.com",
    //  "password": "Admin@1234"
    //}

    //PRODUCT ADD
    //http://localhost:44354/api/product/add
    //{
    //"categoryId":1,
    //"productName":"Bardak",
    //"unitsInStock":15,
    //"unitPrice":2
    //}
public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                RoleId = userForRegisterDto.RoleId,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        [CacheAspect]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatası");
            }

            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı sistemde kaytlı");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }
    }
}
