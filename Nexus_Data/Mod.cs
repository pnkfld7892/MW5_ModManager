﻿using System;

namespace Nexus_Data
{

    public class Mod
    {
        public string name { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public string picture_url { get; set; }
        public long uid { get; set; }
        public int mod_id { get; set; }
        public int game_id { get; set; }
        public bool allow_rating { get; set; }
        public string domain_name { get; set; }
        public int category_id { get; set; }
        public string version { get; set; }
        public int endorsement_count { get; set; }
        public int created_timestamp { get; set; }
        public DateTime created_time { get; set; }
        public int updated_timestamp { get; set; }
        public DateTime updated_time { get; set; }
        public string author { get; set; }
        public string uploaded_by { get; set; }
        public string uploaded_users_profile_url { get; set; }
        public bool contains_adult_content { get; set; }
        public string status { get; set; }
        public bool available { get; set; }
        public User user { get; set; }
        public Endorsement endorsement { get; set; }
    }
}
