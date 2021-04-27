using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class InvoiceController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpPost("create")]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<InvoiceHDR>(invoiceDto);
            _unitOfWork.Repository<InvoiceHDR>().Add(invoice);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem on creating invoice"));
            return Ok(_mapper.Map<InvoiceDto>(invoice));
        }


        [HttpPost("update")]
        public async Task<ActionResult<InvoiceDto>> UpdateInvoice(InvoiceDto invoiceDto)
        {
            var Invoice = await _unitOfWork.Repository<InvoiceHDR>().GetByIdAsync(invoiceDto.InvoiceId);
            var editableInvoice = _mapper.Map<InvoiceDto, InvoiceHDR>(invoiceDto, Invoice);


            _unitOfWork.Repository<InvoiceHDR>().Update(editableInvoice);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem on updating  invoice"));
            return Ok(_mapper.Map<InvoiceDto>(editableInvoice));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            var spec = new InvoiceSpecification(id);
            var invoice = await _unitOfWork.Repository<InvoiceHDR>().GetEntityWithSpec(spec);
            if (invoice == null) return NotFound(new ApiResponse(404));
            var mappedInvoice = _mapper.Map<InvoiceDto>(invoice);

            return Ok(mappedInvoice);
        }



    }
}
