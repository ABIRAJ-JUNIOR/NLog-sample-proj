using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace NLog_sample_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();


        [HttpGet("debug")]
        public IActionResult LogDebug()
        {
            _logger.Debug("This is a DEBUG log.");
            return Ok("DEBUG log recorded.");
        }

        [HttpGet("info")]
        public IActionResult LogInfo()
        {
            _logger.Info("This is an INFO log.");
            return Ok("INFO log recorded.");
        }

        [HttpGet("warn")]
        public IActionResult LogWarning()
        {
            _logger.Warn("This is a WARNING log.");
            return Ok("WARNING log recorded.");
        }

        [HttpGet("error")]
        public IActionResult LogError()
        {
            try
            {
                throw new Exception("Sample exception for logging.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An ERROR occurred.");
            }
            return BadRequest("ERROR log recorded.");
        }
    }
}
