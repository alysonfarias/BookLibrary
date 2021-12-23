using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.VO;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}
