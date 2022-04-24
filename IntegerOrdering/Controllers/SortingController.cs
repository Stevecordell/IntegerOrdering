using IntegerOrdering.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IntegerOrdering.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {
        private ISortingService _sortingService;
        private IFileService _fileService;

        public SortingController(ISortingService sortingService, IFileService fileService)
        {
            _sortingService = sortingService;
            _fileService = fileService;
        }

        [HttpGet]
        public ActionResult ReturnSortedIntegers()
        {
            try
            {
                return Ok(_fileService.GetLatestResults());
            }
            catch
            {
                return NotFound("No results currently available");
            }
        }

        [HttpPost]
        [Route("/SortString")]
        public ActionResult SortIntegersFromString([FromBody] string values)
        {
            try
            {
                return Ok(_sortingService.SortStringData(values));
            }
            catch (FormatException fex)
            {
                return BadRequest(fex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("/SortArray")]
        public ActionResult SortIntegersFromArray([FromBody] params int[] values)
        {
            try
            {
                return Ok(_sortingService.SortIntArray(values));
            }
            catch (FormatException fex)
            {
                return BadRequest(fex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
