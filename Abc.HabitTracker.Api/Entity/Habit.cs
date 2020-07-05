using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api
{
    [Table("habit")]
    public class Habit
    {
        [JsonPropertyName("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; private set; }

        [JsonPropertyName("name")]
        public String Name { get; private set; }

        [JsonPropertyName("user_id")]
        public Guid UserID { get; private set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; private set; }

        [JsonProperty("day_off")]
        [NotMapped]
        public List<DayOff> DayOffList { get; private set; }

        public Habit(Guid ID, String Name, Guid UserID, DateTime CreatedAt, List<DayOff> DayOffList)
        {
            this.ID = ID;
            this.Name = Name;
            this.UserID = UserID;
            this.CreatedAt = CreatedAt;
            this.DayOffList = DayOffList;
        }

        public Habit(Guid ID, String Name, Guid UserID, DateTime CreatedAt)
        {
            this.ID = ID;
            this.Name = Name;
            this.UserID = UserID;
            this.CreatedAt = CreatedAt;
        }
    }
}
