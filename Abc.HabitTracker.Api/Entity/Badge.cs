using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Abc.HabitTracker.Api
{
    public class Badge
    {
        [JsonPropertyName("id")]
        [Key]
        public Guid ID { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("description")]
        public String Description { get; set; }

        [JsonProperty("user")]
        public User user;

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
