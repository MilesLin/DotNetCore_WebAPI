﻿using DotNetCore_WebAPI.Models;
using System.Collections.Generic;

namespace DotNetCore_WebAPI
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto ()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park"
                },new CityDto ()
                {
                    Id = 2,
                    Name = "Antwrp",
                    Description = "The one with the cathedral that was never really finished"
                }
            };
        }
    }
}