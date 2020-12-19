using AutoMapper;
using Domain.Services;
using eVendas.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVendas.ServicoEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericController<TKey, TEntity, TModel> : ControllerBase where TKey : struct where TEntity : BaseEntity<TKey>
    {

        private protected readonly IServiceBase<TKey, TEntity> _serviceBase;
        private protected readonly IMapper _mapper;

        public GenericController(IServiceProvider serviceProvider)
        {
            _serviceBase = serviceProvider.GetRequiredService<IServiceBase<TKey, TEntity>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TEntity> entities = await _serviceBase.GetAllAsync();
            IEnumerable<TModel> models = _mapper.Map<IEnumerable<TModel>>(entities);
            return Ok(models);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItem(TKey id)
        {
            TEntity entity = await _serviceBase.GetItem(id);
            if (entity == null) return NotFound();
            TModel model = _mapper.Map<TModel>(entity);
            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] TEntity model)
        {
            TEntity entity = await _serviceBase.AddAsync(model);
            string uri = Url.Action("GetAll", ControllerContext.ActionDescriptor.ControllerName, new { id = entity.Id });
            return Created(uri, _mapper.Map<TModel>(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TEntity model)
        {
            TEntity entity = await _serviceBase.UpdateAsync(model);
            return Ok(_mapper.Map<TModel>(entity));
        }


    }
}
