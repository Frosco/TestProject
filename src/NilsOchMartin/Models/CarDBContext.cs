using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NilsOchMartin.Models.Entities
{
    public partial class CarDBContext
    {
        // Konstruktor för att ta emot connection-strängen från startup.cs
        public CarDBContext(DbContextOptions<CarDBContext> contextOptions) : base(contextOptions)
        {

        }

        public async Task<CarsIndexVM[]> GetAllCarsAsync()
        {
            return await Car
                .Join(OwnerCarRelations, c => c.Id, r => r.CarId, (c, r) => new
                {
                    Brand = c.Brand,
                    TopSpeed = c.TopSpeed,
                    OwnerId = r.OwnerId
                })
                .Join(Owner, r => r.OwnerId, o => o.Id, (r, o) => new CarsIndexVM
                {
                    Brand = r.Brand,
                    ShowAsFast = (r.TopSpeed > 250),
                    Owner = o.FirstName + " " + o.LastName
                })
                .ToArrayAsync();
        }

        public async Task AddCarAsync(CarsCreateVM viewModel)
        {
            var car = Mapper.Map<Car>(viewModel);

            Car.Add(car);

            await SaveChangesAsync();
        }
    }
}
