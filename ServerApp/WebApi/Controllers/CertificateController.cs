﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.CertificateOperations.Commands.CreateCertificate;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    //TODO: Add Authorize attribute here:
    [ApiController]
    [Route("[controller]s")]
    public class CertificateController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;

        public CertificateController(IAcademyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCertificate([FromBody]CreateCertificateModel model)
        {
            CreateCertificateCommand command = new(_context, _mapper);
            command.Model = model;

            command.Handle();

            return Ok();
        }
    }
}