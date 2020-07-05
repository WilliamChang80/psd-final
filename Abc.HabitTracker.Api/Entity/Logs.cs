using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api
{
    [Table("user_habit")]
    public class Logs
    {
        [JsonPropertyName("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LogsID { get; private set; }

        [JsonProperty("user_id")]
        [ForeignKey(nameof(User))]
        public Guid UserID { get; private set; }

        [JsonProperty("habit_id")]
        [ForeignKey(nameof(Habit))]
        public Guid HabitID { get; private set; }

        [JsonPropertyName("day_name")]
        public String DayName { get; private set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; private set; }

        public Logs(Guid LogsID, Guid UserID, Guid HabitID, String DayName, DateTime CreatedAt)
        {
            this.LogsID = LogsID;
            this.UserID = UserID;
            this.HabitID = HabitID;
            this.DayName = DayName;
            this.CreatedAt = CreatedAt;
        }
    }
}
