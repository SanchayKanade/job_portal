using backend_server.Core.Enums;

namespace backend_server.Core.Entities
{
    public class Job : BaseEntities
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        // Relations 
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        //1-n relation between candidate
        public ICollection<Candidate> Candidates { get; set; }
    }
}
