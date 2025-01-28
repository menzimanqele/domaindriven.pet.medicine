using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;
using Wpm.Management.Api.Infrastructure;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagementApplicationService managementApplicationService, ManagementDbContext dbContext) : ControllerBase
{
   [HttpPost]
   public async Task<ActionResult> Post(CreatePetCommand command)
   {
      await managementApplicationService.Handle(command);
      return Ok();
   }
   
   [HttpPut]
   public async Task<ActionResult> Put(SetWeightCommand command)
   {
      await managementApplicationService.Handle(command);
      return Ok();
   }
}
