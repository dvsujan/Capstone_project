﻿namespace CofeeStoreManagement.Models.DTO.MenuDTO
{
    public class SuperCategoryDto
    {
        public string Name { get; set; }
        public List<CategoryDto> Children { get; set; }
    }
}