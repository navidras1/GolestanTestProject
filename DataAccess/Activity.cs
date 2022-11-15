using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ActivityModels;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Activity
    {
        //private IGolestanTestRepos<PROC_AddRetailStore_Result> _PROC_AddRetailStore_Result;
        private readonly GolestanTestDbContext _context;

        public Activity(GolestanTestDbContext context)
        {
            _context = context;
        }

        public PROC_AddRetailStore_Result? PROC_AddRetailStore(AddRetailStoreModel addRetailStoreModel)
        {

            var command = $"PROC_AddRetailStore '{addRetailStoreModel.Name}','{addRetailStoreModel.Address}','{addRetailStoreModel.Ipaddress}', '{addRetailStoreModel.OpeningDate}',{addRetailStoreModel.IsActive},{addRetailStoreModel.IsTell}";
            var res =  _context.PROC_AddRetailStore_Result.FromSqlRaw(command).AsEnumerable().FirstOrDefault();
            return res;
        }


        public PROC_UpdateRetailStore_Result? PROC_UpdateRetailStore(UpdateRetailModel model)
        {

            var command = $"PROC_UpdateRetailStore '{model.Id}', '{model.Name}','{model.Address}','{model.Ipaddress}', '{model.OpeningDate}',{model.IsActive},{model.IsTell}";
            var res = _context.PROC_UpdateRetailStore_Result.FromSqlRaw(command).AsEnumerable().FirstOrDefault();
            return res;
        }

        public PROC_DeleteRetailStore_Result? PROC_DeleteRetailStore(PROC_DeleteRetailStoreModel model)
        {
            var command = $"PROC_DeleteRetailStore '{model.Id}'";
            var res = _context.PROC_DeleteRetailStore_Result.FromSqlRaw(command).AsEnumerable().FirstOrDefault();
            return res;
        }


        public PROC_AddWorkStations_Result? PROC_AddWorkStations(PROC_AddWorkStationsModel model)
        {
            var command = $"PROC_AddWorkStations '{model.RetailStoreId}', {model.Name}, {model.Location} ,{model.IsActive}";
            var res = _context.PROC_AddWorkStations_Result.FromSqlRaw(command).AsEnumerable().FirstOrDefault();
            return res;
        }

        public PROC_UpdateWorkStations_Result? PROC_UpdateWorkStations(PROC_UpdateWorkStationsModel model)
        {
            var command = $"PROC_UpdateWorkStations  {model.Id},  '{model.RetailStoreId}' ,'{model.Name}' , '{model.Location}' ,{model.IsActive}";
            var res = _context.PROC_UpdateWorkStations_Result.FromSqlRaw(command).AsEnumerable().FirstOrDefault(); 
            return res;
        }

        public PROC_DeleteWorkStation_Result? PROC_DeleteWorkStation(PROC_DeleteWorkStationModel model)
        {
            var command = $"PROC_DeleteWorkStation {model.Id}";
            var res = _context.PROC_DeleteWorkStation_Result.FromSqlRaw(command).AsEnumerable().FirstOrDefault();
            return res;
        }


    }
}
