using Business.Interfaces;
using Contracts.Responses;
using Domain;
using SlotBookingWebAPI.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utility;
using System;

namespace SlotBookingWebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SkipMyGlobalActionFilter]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;
        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(ApiRoutes.Slot.AddPatientRecord)]
        public async Task<IActionResult> AddPatientRecord([FromBody] PatientRecord patientRecord)
        {
            if (patientRecord != null)
            {
                return Ok(await _slotService.AddPatientRecord(patientRecord));
            }
            else
            {
                var errorResponse = new ErrorResponse();
                var errorModel = new ErrorModel
                {
                    FieldName = "patientRecord",
                    Message = "patientRecord model is null"
                };
                errorResponse.Errors.Add(errorModel);
                return BadRequest(errorResponse);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Slot.GetAllPatientRecords)]
        public async Task<IActionResult> GetAllPatientRecords()
        {
            return Ok(await _slotService.GetAllPatientRecords());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Slot.GetSlotBookingsById)]
        public async Task<IActionResult> GetSlotBookingsById([FromRoute] int CreatedBy)
        {
            return Ok(await _slotService.GetSlotBookings(CreatedBy));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Slot.GetDashboardDetails)]
        public async Task<IActionResult> GetDashboardDetails([FromRoute] int HospitalId,int SlotId,DateTime SlotDate)
        {
            return Ok(await _slotService.GetDashboardDetails(HospitalId, SlotId, SlotDate));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Slot.GetPatientRecordsByFilter)]
        public async Task<IActionResult> GetPatientRecordsByFilter([FromRoute] int HospitalId, int SlotId, DateTime SlotDate)
        {
            return Ok(await _slotService.GetPatientRecordsByFilter(HospitalId, SlotId, SlotDate));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Slot.GetAllHospitals)]
        public async Task<IActionResult> GetAllHospitals()
        {
            return Ok(await _slotService.GetAllHospitals());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Slot.GetAllSlots)]
        public async Task<IActionResult> GetAllSlots()
        {
            return Ok(await _slotService.GetAllSlots());
        }
    }
}