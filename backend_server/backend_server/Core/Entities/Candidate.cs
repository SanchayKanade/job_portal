﻿namespace backend_server.Core.Entities
{
    public class Candidate : BaseEntities
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }

        // Relations

        public long JobId { get; set; }
        public Job Job { get; set; }
    }
}
