using AutoMapper;
using eCommerceStore.Controllers;
using eCommerceStore.Models.Domain;
using eCommerceStore.Models.DTO;
using eCommerceStore.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceStore.Tests.Controller
{
    public class ShoppingCartControllerTests
    {
        private readonly IMapper mapper;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IItemRepository itemRepository;
        public ShoppingCartControllerTests()
        {
            this.mapper = A.Fake<IMapper>();
            this.itemRepository = A.Fake<IItemRepository>();
            this.shoppingCartRepository = A.Fake<IShoppingCartRepository>();
        }

        [Fact]
        public void ShoppingCartController_GetCartContents_ReturnsOK()
        {
            //var cartContents = A.Fake<List<CartItem>>();
            ShoppingCartController shoppingCartController = new(mapper, shoppingCartRepository, itemRepository);
            var result = shoppingCartController.GetCartContents().Result;
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ShoppingCartController_AddItemsToCart_ReturnsOK()
        {

            var addCartItemRequestDto = A.Fake<AddCartItemRequestDto>();
            var item = A.Fake<Item>();
            var cartItem = A.Fake<CartItem>();
            A.CallTo(() => itemRepository.GetItemByIdAsync(addCartItemRequestDto.ItemId)).Returns(item);
            A.CallTo(() => mapper.Map<CartItem>(addCartItemRequestDto)).Returns(cartItem);
            ShoppingCartController shoppingCartController = new(mapper, shoppingCartRepository, itemRepository);
            var result = shoppingCartController.AddItemsToCart(addCartItemRequestDto).Result;
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }
    }
}
