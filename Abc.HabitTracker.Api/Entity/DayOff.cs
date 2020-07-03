using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api
{
    [Table("habit_dayoff")]
    public class DayOff
    {

        [JsonPropertyName("habit_id")]
        [ForeignKey(nameof(Habit))]
        public Guid HabitID { get; set; }
        [JsonPropertyName("day_name")]
        public String DayName { get; set; }
    }
}
