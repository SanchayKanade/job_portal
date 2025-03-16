using backend_server.Core.Enums;

namespace backend_server.Core.Dtos.Company
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }

        public CompanySize Size { get; set; }
    }
}
