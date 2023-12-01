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
    public class ShoppingCartController : ControllerBase
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public ShoppingCartController(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemsToCart(AddCartItemRequestDto addCartItemRequestDto)
        {            
            //map add cart request DTO to cartItem domain model
            var cartItem = mapper.Map<CartItem>(addCartItemRequestDto);
            await dbContext.CartItems.AddAsync(cartItem);
            await dbContext.SaveChangesAsync();
            // map domain to DTO
            var cartItemDTO = mapper.Map<CartItemDto>(cartItem); 
            return Ok(cartItemDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartContents()
        {
            var cartContents = await dbContext.CartItems.Include("Item").ToListAsync();
            //convert cartItem domain to cartItemDto DTO object
            var cartItemDtos = mapper.Map<List<CartItemDto>>(cartContents);            
            return Ok(cartItemDtos);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItemQuantity(UpdateCartItemRequestDto updateCartItemRequestDto)
        {
            var existingCartItem = await dbContext.CartItems.FirstOrDefaultAsync(x => x.ItemId == updateCartItemRequestDto.ItemId);
            if (existingCartItem == null)
            {
                return NotFound();
            }
            existingCartItem.Quantity = updateCartItemRequestDto.Quantity;            
            await dbContext.SaveChangesAsync();
            return Ok(existingCartItem);
        }
    }
}
