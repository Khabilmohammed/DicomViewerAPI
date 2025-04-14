using FellowOakDicom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DicomViewerAPI.Controllers
{
    [Route("api/Dicom")]
    [ApiController]
    public class DicomController : ControllerBase
    {
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadDicom(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            try
            {
                using var stream = file.OpenReadStream();
                var dicomFile = await DicomFile.OpenAsync(stream);
                var dataset = dicomFile.Dataset;

                var metadata = new
                {
                    PatientName = dataset.GetSingleValueOrDefault(DicomTag.PatientName, string.Empty),
                    PatientID = dataset.GetSingleValueOrDefault(DicomTag.PatientID, string.Empty),
                    StudyDate = dataset.GetSingleValueOrDefault(DicomTag.StudyDate, string.Empty),
                    Modality = dataset.GetSingleValueOrDefault(DicomTag.Modality, string.Empty),
                    StudyDescription = dataset.GetSingleValueOrDefault(DicomTag.StudyDescription, string.Empty),
                    SeriesInstanceUID = dataset.GetSingleValueOrDefault(DicomTag.SeriesInstanceUID, string.Empty),
                    StudyInstanceUID = dataset.GetSingleValueOrDefault(DicomTag.StudyInstanceUID, string.Empty),
                    InstitutionName = dataset.GetSingleValueOrDefault(DicomTag.InstitutionName, string.Empty),
                    Manufacturer = dataset.GetSingleValueOrDefault(DicomTag.Manufacturer, string.Empty),
                    BodyPartExamined = dataset.GetSingleValueOrDefault(DicomTag.BodyPartExamined, string.Empty)
                };

                return Ok(metadata);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error processing DICOM file: {ex.Message}");
            }
        }
    }
}
