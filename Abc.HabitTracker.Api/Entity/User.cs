using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Abc.HabitTracker.Api
{
    public class User
    {
        [JsonPropertyName("id")]
        [Key]
        public Guid ID { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

    }
}
