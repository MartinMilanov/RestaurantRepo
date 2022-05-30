﻿using AutoMapper;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Tables;
using Restaurant.Mapping.Models.Tables;
using Restaurant.Services.Loggers;

namespace Restaurant.Services.Tables
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;
        private readonly TableRepository _tableRepo;

        public TableService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggingService = loggingService;
            _tableRepo = unitOfWork.Tables;
        }

        public async Task Create(TableCreateDto input)
        {
            var entity = _mapper.Map<Table>(input);

            await _tableRepo.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Tables");
        }

        public async Task Delete(string id)
        {
            var entityToDelete = await _tableRepo.GetBy(x => x.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Table does not exist");
            }

            _tableRepo.Delete(entityToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TableListDto>> GetAll(TablePaginationDto filters)
        {
            var query = _tableRepo.GetAll();

            if (filters.TableNumer != 0)
            {
                query = query.Where(x => x.TableNumber == filters.TableNumer);
            }

            if (filters.Seats != 0)
            {
                query = query.Where(x => x.Seats == filters.Seats);

            }

            if (filters.OrderBy == "TableNumber")
            {
                query = query.OrderBy(x => x.TableNumber);
            }

            if (filters.OrderBy == "Seats")
            {
                query = query.OrderBy(x => x.Seats);
            }

            query = query.Skip(filters.Skip).Take(filters.Take);

            var result = query.Select(x => _mapper.Map<TableListDto>(x));

            return result.ToList();
        }

        public async Task<int> GetCount(TablePaginationDto filters)
        {
            var query = _tableRepo.GetAll();

            if (filters.TableNumer != 0)
            {
                query = query.Where(x => x.TableNumber == filters.TableNumer);
            }

            if (filters.Seats != 0)
            {
                query = query.Where(x => x.Seats == filters.Seats);
            }

            return query.ToList().Count;
        }

        public async Task<TableResultDto> GetById(string id)
        {
            var result = await _tableRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Could not find table");
            }

            return _mapper.Map<TableResultDto>(result);
        }

        public async Task Update(string id, TableUpdateDto input)
        {
            var newData = _mapper.Map<Table>(input);

            newData.Id = id;

            _tableRepo.Update(id, newData);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Tables");
        }
    }
}
