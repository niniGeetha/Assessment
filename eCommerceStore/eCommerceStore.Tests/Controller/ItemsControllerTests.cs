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
    public  class ItemsControllerTests
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;
        public ItemsControllerTests()
        {
            this.mapper = A.Fake<IMapper>();
            this.itemRepository = A.Fake<IItemRepository>(); 
            
        }

        [Fact]
        public void ItemsController_GetItems_ReturnOK()
        {
            //Arrange
            var itemsDTO = A.Fake<ICollection<ItemDto>>();
            var itemsList = A.Fake<List<ItemDto>>();
            A.CallTo(() => mapper.Map<List<ItemDto>>(itemsDTO)).Returns(itemsList);
            ItemsController itemsController = new ItemsController(mapper, itemRepository);
            var result = itemsController.GetItems().Result;
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItemController_CreateItems_ReturnOK() 
        { 
            var addItemRequestDto = A.Fake<AddItemRequestDto>();
            var itemsDTO = A.Fake<ItemDto>();
            var item = A.Fake<Item>();
            A.CallTo(() => mapper.Map<Item>(addItemRequestDto)).Returns(item);
            ItemsController itemsController = new(mapper, itemRepository);
            var result = itemsController.CreateItems(addItemRequestDto).Result;
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
