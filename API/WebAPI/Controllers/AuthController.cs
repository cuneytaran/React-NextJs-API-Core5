using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.RoleId = 1;
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}



//type safety:tip güvenliği
//best practice:doğru kodlama teknikleri
//clean code:temiz kod
//naming convention:doğru yazma kodları (ilk hafler büyü gibi...)
//instance-class örneği
//instance creations=örnek oluşturma
//encapsulation-ayrı ayrı yazacağın yapıyı(int,string, vs..) bir class kapsülün içine sokarar kullanma, class içine farklı bir dönüş için bilgi ekleme ve bunları sarmalama
//crud=creat,read,update,delete
//PascalCase ve camelCase - isimlendirme kuralları Product product=new Product();
//ref out
//Generic yapılar
//constructor=newleme yapma
//tempArray=geçiçi dizi oluşturma
//soyutlama
//SOLID=
//inheritance=miras alma
//implementasyon=uygulama işlemi
//polimorfizm=çok biçimlilik, inheritance ile polimorfizm yapıyoruz
//interface:şablon
//depencyinjection olarak methot injection ve constructor injection
//generic repository= dizayn pattern
//Expression delegeleri
//generic constraint=generic kısıtlamalar, yani class veya referans tipler gelsin.
//IDisposable pattern implementation of c#
//Code Refactoring = codun iyileştirilmesi
//constructor injection=abstractları interface referansalarını ayağa kaldırma
//IOC container
//Data Transformation Object (DTO)
//overloading = aşırı yükleme Result.cs de iki tane constructor kurma veya iki tane metot varmış gibi
//AOP
//magic strings=uyarı mesajlarını tek çatı altında toplama Constants içinde
//dependency chain=bağımlılık zinciri interface lerden dolayı
//Loosely coupled=gevşek bağlılık, constructor da oluştururuz.Iproductservice deki bir değişiklik yapılabilir.
//naming convention=isimlendirme standartı IProductService _productService;
//IoC Container -- Inversion of Control= değişimin kontrolü, bir liste gibi düşün, ben oraya bir tane new productmanager vs.. referanslar koyayım içine kim ihtiyaç duyuyorsa ona verelim. yani startup da tanıtma işlemi yaparsın.yani ayağa kaldırma işlemi.yani senin yerine new leme işlemi yapar
//AOP=bütün metotları loglamak istiyorsan, [HttpPost] gibi oluşturma. Bir metodun önünde veya sonunda, hata verdiğinde çalışan kod parçacıklarıdır.
//Autofac -->IoC Container altyapısı sunuyor. Autofac çok iyi bir AOP imkanı sunuyor.
//Cross Cutting Concems= log, cache,transaction,authorization bu işlemleri yani dikine kesen işlemler.
//interseptors=[httppost] üstüne yazılan log,cache vs..işlemleri Core.Utilities.Interceptors diğer adı atribute
//defensive coding=savunma odaklı Core.Aspects.Autofac.Validation -ValidationAspect
//Core.Utilities.Business iş kuralları oluşturma.
//Adapter Pattern=adaptasyon deseni, var olan birşeyi kendi sistemime uyarlama
//Reflection=kodu çalışma anında oluşturma, müdehale etme Core.CrossCuttingConcerns.Caching.Microsoft MemoryCacheManager
