using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api
{
    [Table("habit_day_off")]
    public class DayOff
    {
        [JsonProperty("habit_id")]
        [ForeignKey(nameof(Habit))]
        public Guid HabitID { get; set; }

        [JsonPropertyName("day_name")]
        public String DayName { get; set; }
    }
}
