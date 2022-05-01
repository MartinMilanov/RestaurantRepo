﻿using Restaurant.Data.Common.Persistance.Repositories;

namespace Restaurant.Data.Common.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _context;

        public UnitOfWork(RestaurantDbContext context)
        {
            _context = context;

            Foods = new FoodRepository(context);
            Categories = new CategoryRepository(context);
            Tables = new TableRepository(context);
            Reservations = new ReservationRepository(context);
            Bills = new BillsRepository(context);
            FoodBills = new FoodBillRepository(context);
        }

        public FoodRepository Foods {get;set;}

        public CategoryRepository Categories {get;set; }

        public TableRepository Tables { get; set; }

        public ReservationRepository Reservations { get; set; }

        public BillsRepository Bills { get; set; }

        public FoodBillRepository FoodBills { get; set; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}