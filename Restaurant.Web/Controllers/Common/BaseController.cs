using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Services.Loggers;

namespace Restaurant.Web.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private protected readonly IUnitOfWork _unitOfWork;
        private protected readonly ILoggingService _loggingService;
        private protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, ILoggingService loggingService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _loggingService = loggingService;
            _mapper = mapper;
        }
    }
}
