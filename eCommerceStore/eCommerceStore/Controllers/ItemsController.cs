using AutoMapper;
using eCommerceStore.Models.Data;
using eCommerceStore.Models.Domain;
using eCommerceStore.Models.DTO;
using eCommerceStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {        
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public ItemsController(IMapper mapper, IItemRepository itemRepository)
        {            
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems() {

            var items = await itemRepository.GetAllItemsAsync();
            //Map domain model to DTO 
            var itemsDto = mapper.Map<List<ItemDto>>(items);
            return Ok(itemsDto);

        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetItemById(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = await itemRepository.GetItemByIdAsync(id);
            if (item is null)
                return NotFound();
            //Map domain to DTO
            var itemDTO = mapper.Map<ItemDto>(item);
            return Ok(itemDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItems(AddItemRequestDto addItemRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //Map DTO to domain model
            var item = mapper.Map<Item>(addItemRequestDto);

            item = await itemRepository.CreateItemAsync(item);

            //Map Domain to DTO
            var itemDto = mapper.Map<ItemDto>(item);

            return Ok(itemDto);
        }

        [HttpPut]        
        public async Task<IActionResult> UpdateItem(UpdateItemRequestDto updateItemRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //map domain model to DTO
            var item = mapper.Map<Item>(updateItemRequestDto);
            item = await itemRepository.UpdateItemAsync(item);
            if (item is null)
                return NotFound();
            var itemDTO = mapper.Map<ItemDto>(item);
            return Ok(itemDTO);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = await itemRepository.DeleteItemAsync(id);
            if (item is null)
                return NotFound();
            var itemDTO = mapper.Map<ItemDto>(item);
            return Ok(itemDTO);

        }

    }
}
