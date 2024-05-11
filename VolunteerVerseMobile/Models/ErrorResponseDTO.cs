using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class ErrorResponseDTO
    {
        public ErrorResponseDTO(string message)
        {
            Errors = new List<string>() { message };
        }

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }
    }
}
