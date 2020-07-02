using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api.Dto
{
    public class HabitRequest
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("days_off")]
        public List<String> DaysOff { get; set; }
    }

    public class HabitResponse
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonProperty("day_off")]
        public List<DayOff> DayOffList { get; set; }

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