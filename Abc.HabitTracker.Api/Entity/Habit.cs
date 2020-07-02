using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api
{
    public class Habit
    {
        [JsonPropertyName("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonPropertyName("user_id")]
        public Guid UserID { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("day_off")]
        [NotMapped]
        public virtual ICollection<DayOff> DayOffList { get; set; }

    }
}
