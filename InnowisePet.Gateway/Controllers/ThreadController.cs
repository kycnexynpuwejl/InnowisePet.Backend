using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThreadController : Controller
{
    // GET
    [HttpGet]
    [AllowAnonymous]
    public string GetThreadsCountAsync()
    {
        int a;
        int b;
        ThreadPool.GetMaxThreads(out a, out b);

        return "a = " + a + "; b = " + b;
    }
}