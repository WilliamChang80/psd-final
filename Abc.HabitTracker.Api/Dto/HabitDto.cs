using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Abc.HabitTracker.Api.Dto
{
    public class HabitDto
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("days_off")]
        public String[] DaysOff { get; set; }
    }
}