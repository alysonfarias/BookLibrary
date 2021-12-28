using WebApplication1.Data.VO;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);

    }
}
