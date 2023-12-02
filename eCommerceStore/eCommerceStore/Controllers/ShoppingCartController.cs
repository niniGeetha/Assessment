using AutoMapper;
using eCommerceStore.Models.Domain;
using eCommerceStore.Models.DTO;
using eCommerceStore.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace eCommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {        
        private readonly IMapper mapper;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IItemRepository itemRepository;

        public ShoppingCartController(IMapper mapper, IShoppingCartRepository shoppingCartRepository, IItemRepository itemRepository)
        {            
            this.mapper = mapper;
            this.shoppingCartRepository = shoppingCartRepository;
            this.itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemsToCart(AddCartItemRequestDto addCartItemRequestDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            //map add cart request DTO to cartItem domain model
            var item = await itemRepository.GetItemByIdAsync(addCartItemRequestDto.ItemId);
            if (item == null) return NotFound(); 
            var cartItem = mapper.Map<CartItem>(addCartItemRequestDto);
            cartItem.Item = item;
            cartItem = await shoppingCartRepository.AddItemsToCartAsync(cartItem);
            // map domain to DTO
            var cartItemDTO = mapper.Map<CartItemDto>(cartItem); 
            return Ok(cartItemDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartContents()
        {            
            var cartContents = await shoppingCartRepository.GetAllItemsFromCartAsync();
            //convert cartItem domain to cartItemDto DTO object
            var cartItemDtos = mapper.Map<List<CartItemDto>>(cartContents);            
            return Ok(cartItemDtos);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItemQuantity(UpdateCartItemRequestDto updateCartItemRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = await itemRepository.GetItemByIdAsync(updateCartItemRequestDto.ItemId);
            if (item == null) return NotFound();
            //map updateCartItemRequest DTO to domain model cartItem
            var cartItem = mapper.Map<CartItem>(updateCartItemRequestDto);
            cartItem.Item = item;            
            cartItem = await shoppingCartRepository.UpdateCartAsync(cartItem);
            if (cartItem is null)
                return NotFound();            
            //map domain model cartItem to updateCartItemRequest DTO
            var cartItemDTO = mapper.Map<CartItemDto>(cartItem);
            return Ok(cartItemDTO);
        }
    }
}
