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
        public Guid LogsID { get; set; }

        [JsonProperty("user_id")]
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        [JsonProperty("habit_id")]
        [ForeignKey(nameof(Habit))]
        public Guid HabitID { get; set; }

        public Habit habit { get; set; }

        [JsonPropertyName("day_name")]
        public String DayName { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
