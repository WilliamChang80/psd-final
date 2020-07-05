using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api.Dto
{
    public class LogsResponse
    {
        [JsonPropertyName("current_streak")]
        public Int32 CurrentStreak { get; set; }

        [JsonPropertyName("longest_streak")]
        public Int32 LongestStreak { get; set; }

        [JsonPropertyName("log_count")]
        public Int32 LogCount { get; set; }

        [JsonPropertyName("logs")]
        public List<DateTime> Logs { get; set; }
    }
}