using WebApplication1.Data.VO;

namespace WebApplication1.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
