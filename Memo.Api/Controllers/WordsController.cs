using System.Security.Claims;
using Memo.Domain.Models;
using Memo.Infra.Repositories;
using Memo.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class WordsController : ControllerBase
{
}