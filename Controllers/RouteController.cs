using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class EmployeeControlloer : ControllerBase
{
    [HttpGet]
[Authorize(Roles = "HR")]

public IActionResult GetAll()
{
    return Ok("All employees records retrieved");
}



}

