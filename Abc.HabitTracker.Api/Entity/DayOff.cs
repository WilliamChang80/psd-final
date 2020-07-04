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

        public DayOff(String DayName)
        {
            List<String> requiredDayOff = new List<String>() {
                "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"
            };
            if (!requiredDayOff.Contains(DayName))
            {
                throw new Exception("Day Format Is Wrong!");
            }
            this.DayName = DayName;
        }
    }
}
