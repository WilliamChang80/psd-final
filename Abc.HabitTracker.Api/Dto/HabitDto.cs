using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Abc.HabitTracker.Api.Dto
{
    public class HabitRequest
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "days_off")]
        public List<String> DaysOff { get; set; }

        private bool CheckIfDaysIsUnique(List<String> DaysOff)
        {
            return DaysOff.Count == DaysOff.Distinct().Count();
        }

        [JsonConstructor]
        public HabitRequest(String Name, List<String> DaysOff)
        {
            if (Name.Length < 2 || Name.Length > 100 || Name == null)
            {
                throw new Exception("Name Length Must Between 2 and 100 character");
            }
            if (DaysOff.Count >= 7 || !CheckIfDaysIsUnique(DaysOff))
            {
                throw new Exception("Day Off Must Different and Less than 7");
            }
            this.Name = Name;
            this.DaysOff = DaysOff;
        }
    }

    public class HabitResponse
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("day_off")]
        public List<String> DayOffList { get; set; }

        [JsonPropertyName("current_streak")]
        public Int16 CurrentStreak { get; set; }

        [JsonPropertyName("longest_streak")]
        public Int16 LongestStreak { get; set; }

        [JsonPropertyName("log_count")]
        public Int16 LogCount { get; set; }

        [JsonPropertyName("logs")]
        public List<DateTime> Logs { get; set; }

        [JsonPropertyName("user_id")]
        public Guid UserID { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}