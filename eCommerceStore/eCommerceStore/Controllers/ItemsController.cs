using AutoMapper;
using eCommerceStore.Models.Data;
using eCommerceStore.Models.Domain;
using eCommerceStore.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public ItemsController(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems() {

            var items =  await dbContext.Items.ToListAsync();
            //Map domain model to DTO 
            var itemsDto = mapper.Map<List<ItemDto>>(items);
            return Ok(itemsDto);

        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            //Map domain to DTO
            var itemDTO = mapper.Map<ItemDto>(item);
            return Ok(itemDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItems(AddItemRequestDto addItemRequestDto)
        {
            //Map DTO to domain model
            var item = mapper.Map<Item>(addItemRequestDto);
            
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            //Map Domain to DTO
            var itemDto = mapper.Map<ItemDto>(item);

            return Ok(itemDto);
        }

        [HttpPut]        
        public async Task<IActionResult> UpdateItem(UpdateItemRequestDto updateItemRequestDto)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == updateItemRequestDto.Id);
            if(existingItem == null)
            {
                return NotFound();
            }
            existingItem = mapper.Map<Item>(updateItemRequestDto);
            await dbContext.SaveChangesAsync();
            //map domain model to DTO
            var itemDTO = mapper.Map<ItemDto>(existingItem);
            return Ok(itemDTO);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(existingItem == null)
            {
                return NotFound();
            }
            dbContext.Items.Remove(existingItem);
            await dbContext.SaveChangesAsync();
            return Ok();

        }


    }
}
