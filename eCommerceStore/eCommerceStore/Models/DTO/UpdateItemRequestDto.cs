﻿namespace eCommerceStore.Models.DTO
{
    public class UpdateItemRequestDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required float Price { get; set; }
    }
}