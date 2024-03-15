﻿namespace Consultorio.Domain.Entity.InputDTOs
{
    public class ServiceInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Duration { get; set; }
    }
}
