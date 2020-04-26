using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkz_school_service.Models
{
    public class SC_STUDENT
    {
        [JsonProperty("Id")]
        public Guid STD_ID { get; set; }
        [JsonProperty("Name")]
        public string STD_NAME { get; set; }
        [JsonProperty("LastName")]
        public string STD_LAST_NAME { get; set; }
        [JsonProperty("BirthDate")]
        public DateTime? STD_BIRTH_DATE { get; set; }
        [JsonProperty("Image")]
        public string STD_IMAGE { get; set; }
        [JsonProperty("Email")]
        public string STD_EMAIL { get; set; }
        [JsonProperty("Active")]
        public bool STD_ACTIVE { get; set; }
        [JsonProperty("FullName")]
        public string STD_FULL_NAME { get; set; }
    }
}
