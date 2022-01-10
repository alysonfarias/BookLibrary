using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data.VO;

namespace WebApplication1.Business
{
  public interface IFileBusiness
  {
    public byte[] GetFile(string fileName);
    public  Task<FileDetailVO> SaveFileToDisk(IFormFile file);
    public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file);

  }
}
