﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ART.Utilities.Reporting;
using ART.VehicleTracker.BL.Models;
using ART.VehicleTracker.PL;
using Microsoft.EntityFrameworkCore.Storage;

namespace ART.VehicleTracker.BL
{
    public static class VehicleManager
    {
        public async static Task<int> Insert(Models.Vehicle vehicle, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (VehicleEntities dc = new VehicleEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblVehicle newrow = new tblVehicle();

                    newrow.Id = Guid.NewGuid();
                    newrow.ColorId = vehicle.ColorId;
                    newrow.MakeId = vehicle.MakeId;
                    newrow.ModelId = vehicle.ModelId;
                    newrow.VIN = vehicle.VIN;
                    newrow.Year = vehicle.Year;

                    vehicle.Id = newrow.Id;

                    dc.tblVehicles.Add(newrow);
                    int results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int syncInsert(Models.Vehicle vehicle, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (VehicleEntities dc = new VehicleEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblVehicle newrow = new tblVehicle();

                    newrow.Id = Guid.NewGuid();
                    newrow.ColorId = vehicle.ColorId;
                    newrow.MakeId = vehicle.MakeId;
                    newrow.ModelId = vehicle.ModelId;
                    newrow.VIN = vehicle.VIN;
                    newrow.Year = vehicle.Year;

                    vehicle.Id = newrow.Id;

                    dc.tblVehicles.Add(newrow);
                    int results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<Guid> Insert( Guid colorId, Guid makeId, Guid modelId, string vin, int year, bool rollback = false)
        {
            try
            {
                Models.Vehicle vehicle = new Models.Vehicle 
                { 
                    ColorId = colorId,
                    MakeId = makeId,
                    ModelId =modelId,
                    VIN = vin,
                    Year = year
                };
                await Insert(vehicle);
                return vehicle.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle row = dc.tblVehicles.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblVehicles.Remove(row);

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                        return results;
                    }
                    else
                    {
                        throw new Exception("Row was not found");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int SyncDelete(Guid id, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle row = dc.tblVehicles.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblVehicles.Remove(row);

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                        return results;
                    }
                    else
                    {
                        throw new Exception("Row was not found");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<int> Update(Models.Vehicle vehicle, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle row = dc.tblVehicles.FirstOrDefault(c => c.Id == vehicle.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        row.ColorId = vehicle.ColorId;
                        row.MakeId = vehicle.MakeId;
                        row.ModelId = vehicle.ModelId;
                        row.VIN = vehicle.VIN;
                        row.Year = vehicle.Year;

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                        return results;
                    }
                    else
                    {
                        throw new Exception("Row was not found");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int SyncUpdate(Models.Vehicle vehicle, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle row = dc.tblVehicles.FirstOrDefault(c => c.Id == vehicle.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        row.ColorId = vehicle.ColorId;
                        row.MakeId = vehicle.MakeId;
                        row.ModelId = vehicle.ModelId;
                        row.VIN = vehicle.VIN;
                        row.Year = vehicle.Year;

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                        return results;
                    }
                    else
                    {
                        throw new Exception("Row was not found");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<Models.Vehicle> LoadById(Guid id)
        {
            try
            {
                using (VehicleEntities dc = new VehicleEntities())
                {
                    tblVehicle tblvehicle = dc.tblVehicles.FirstOrDefault(c => c.Id == id);
                    Models.Vehicle vehicle = new Models.Vehicle();

                    if (tblvehicle != null)
                    {
                        vehicle.Id = tblvehicle.Id;
                        vehicle.ColorId = tblvehicle.ColorId;
                        vehicle.MakeId = tblvehicle.MakeId;
                        vehicle.ModelId = tblvehicle.ModelId;
                        vehicle.VIN = tblvehicle.VIN;
                        vehicle.Year = tblvehicle.Year;
                        vehicle.ColorName = tblvehicle.Color.Description;
                        vehicle.MakeName = tblvehicle.Make.Description;
                        vehicle.ModelName = tblvehicle.Model.Description;

                        return vehicle;
                    }
                    else
                    {
                        throw new Exception("Could not find the row");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<IEnumerable<Models.Vehicle>> Load()
        {
            try
            {
                List<Vehicle> vehicles = new List<Vehicle>();

                using (VehicleEntities dc = new VehicleEntities())
                {
                    dc.tblVehicles
                        .ToList()
                        .ForEach(c => vehicles.Add(new Vehicle
                        {
                            Id = c.Id,
                            ColorId = c.ColorId,
                            MakeId = c.MakeId,
                            ModelId = c.ModelId,
                            VIN = c.VIN,
                            Year = c.Year,
                            ColorName = c.Color.Description,
                            MakeName = c.Make.Description,
                            ModelName = c.Model.Description
                }));
                    return vehicles;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<IEnumerable<Models.Vehicle>> Load(string colorName)
        {
            try
            {
                List<Models.Vehicle> vehicles = new List<Models.Vehicle>();

                using (VehicleEntities dc = new VehicleEntities())
                {
                    dc.tblVehicles
                        .Where(v => v.Color.Description.Contains(colorName))
                        .ToList()
                        .ForEach(c => vehicles.Add(new Models.Vehicle
                        {
                            Id = c.Id,
                            ColorId = c.ColorId,
                            ModelId = c.ModelId,
                            MakeId = c.MakeId,
                            VIN = c.VIN,
                            Year = c.Year,
                            ColorName = c.Color.Description,
                            MakeName = c.Make.Description,
                            ModelName = c.Model.Description
                        }));
                    return vehicles;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Export(List<Vehicle> vehicles)
        {
            try
            {
                string[,] data = new string[vehicles.Count + 1, 5];
                int counter = 0;

                data[counter, 0] = "VIN";
                data[counter, 1] = "Model";
                data[counter, 2] = "Make";
                data[counter, 3] = "Color";
                data[counter, 4] = "Year";

                counter++;

                foreach (Vehicle v in vehicles)
                {
                    data[counter, 0] = v.VIN;
                    data[counter, 1] = v.ModelName;
                    data[counter, 2] = v.MakeName;
                    data[counter, 3] = v.ColorName;
                    data[counter, 4] = v.Year.ToString();

                    counter++;
                }

                Excel.Export("Vehicles", data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
