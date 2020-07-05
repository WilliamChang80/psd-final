using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api
{
    [Table("badge")]
    public class Badge
    {
        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; private set; }

        [JsonPropertyName("name")]
        public String Name { get; private set; }

        [JsonPropertyName("description")]
        public String Description { get; private set; }

        [JsonPropertyName("user_id")]
        public Guid UserID { get; private set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; private set; }

        public Badge(Guid ID, String Name, String Description, Guid UserID, DateTime CreatedAt)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.UserID = UserID;
            this.CreatedAt = CreatedAt;
        }

        public Badge()
        {

        }
    }
}
