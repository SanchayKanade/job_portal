﻿using AutoMapper;
using backend_server.Core.Context;
using backend_server.Core.Dtos.Job;
using backend_server.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }
        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD 

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();

            return Ok("Job Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await _context.Jobs.Include(job => job.Company).OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertdJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(convertdJobs);
        }
    }
}
