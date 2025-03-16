using backend_server.Core.Enums;

namespace backend_server.Core.Entities
{
    public class Company : BaseEntities
    {
        public string Name { get; set; }

        public CompanySize Size { get; set; }

        //List in C# are Icollections
        //Relations
        public ICollection<Job> Jobs { get; set; }


    }
}
