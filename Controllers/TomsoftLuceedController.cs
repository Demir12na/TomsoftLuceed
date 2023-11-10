using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TomsoftLuceed.IServices;
using TomsoftLuceed.Models;

namespace TomsoftLuceed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TomsoftLuceedController : ControllerBase
    {
        private readonly ITomsoftLuceedService _tomsoftLuceedService;

        public TomsoftLuceedController(ITomsoftLuceedService tomsoftLuceedService)
        {
            _tomsoftLuceedService = tomsoftLuceedService;
        }

        [HttpGet] // upit broj 1
        [Route("GetListOfItemsBypartOfName")]
        [SwaggerOperation("Get list of items by part of name")]
        public async Task<IActionResult> GetListOfItemsBypartOfName(string? partOfName)
        {
            try
            {
                List<GetListOfItemsByPartOfNameResItem> response = await _tomsoftLuceedService.GetListOfItemsBypartOfNameAsync(partOfName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet] // upit broj 2
        [Route("GetCalculationOfTurnoverByPaymentTypes")]
        [SwaggerOperation("Calculation of turnover by payment types")]
        public async Task<IActionResult> GetCalculationOfTurnoverByPaymentTypes([Required] string pjUid, [Required] DateTime fromDate, DateTime? toDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pjUid))
                {
                    throw new ArgumentNullException("pjUid can not be null or empty");
                }

                string response = await _tomsoftLuceedService.GetCalculationOfTurnoverByPaymentTypesAsync(pjUid, fromDate, toDate);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet] // upit broj 3
        [Route("GetCalculationOfTurnoverByItems")]
        [SwaggerOperation("Get calculation of turnover by items")]
        public async Task<IActionResult> GetCalculationOfTurnoverByItems([Required] string pjUid, [Required] DateTime fromDate, DateTime? toDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pjUid))
                {
                    throw new ArgumentNullException("pjUid can not be null or empty");
                }

                string response = await _tomsoftLuceedService.GetCalculationOfTurnoverByItemsAsync(pjUid, fromDate, toDate);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}