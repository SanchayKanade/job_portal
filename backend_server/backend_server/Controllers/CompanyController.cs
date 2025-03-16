using AutoMapper;
using backend_server.Core.Context;
using backend_server.Core.Dtos.Company;
using backend_server.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        //Constructor to get context of applicaion db context
        private ApplicationDbContext _context {  get; }

        private IMapper _mapper { get; }
        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
        {
            Company newCompany = _mapper.Map<Company>(dto);
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            return Ok("Companty Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await _context.Companies.OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedCompanies = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);

            return Ok(convertedCompanies);
        }

        //Update

        //Delete

    }
}
