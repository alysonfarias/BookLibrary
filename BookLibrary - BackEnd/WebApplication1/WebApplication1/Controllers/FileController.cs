using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Data.VO;

namespace WebApplication1.Controllers
{
  [ApiVersion("1")]
  [ApiController]
  [Authorize("Bearer")]
  [Route("api/[controller]/v{version:ApiVersion}")]
  public class FileController : Controller
  {
    private readonly IFileBusiness _fileBusiness;

    public FileController(IFileBusiness fileBusiness)
    {
      _fileBusiness = fileBusiness;
    }


    [HttpPost("uploadFile")]
    [ProducesResponseType((200), Type = typeof(FileDetailVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [Produces("application/json")]
    public async Task<IActionResult> UploadSingleFile([FromForm] IFormFile file)
    {
      FileDetailVO detail = await _fileBusiness.SaveFileToDisk(file);
      return new OkObjectResult(detail);
    }

    [HttpPost("uploadMultipleFiles")]
    [ProducesResponseType((200), Type = typeof(List<FileDetailVO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [Produces("application/json")]
    public async Task<IActionResult> UploadMultipleFiles([FromForm] List<IFormFile> files)
    {
      List<FileDetailVO> details = await _fileBusiness.SaveFilesToDisk(files);
      return new OkObjectResult(details);
    }
  }
}
