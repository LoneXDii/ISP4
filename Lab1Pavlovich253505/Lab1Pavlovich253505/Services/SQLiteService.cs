using Lab1Pavlovich253505.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lab1Pavlovich253505.Services;

class SQLiteService:IDbService
{
    private SQLiteConnection? database = null;
    public SQLiteService()
    {
        Init();
    }
    public IEnumerable<HotelRoomCategory> GetAllCategories()
    {
        return database.Table<HotelRoomCategory>().ToList();
    }

    public IEnumerable<HotelRoomFeature> GetCategoryFeatures(int id)
    {
        return from feature in database.Table<HotelRoomFeature>()
               where feature.HotelRoomCategoryId == id
               select feature;
    }

    public void Init()
    {
        if (database != null) return;
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db");
        database = new SQLiteConnection(dbPath);

        database.DropTable<HotelRoomCategory>();
        database.DropTable<HotelRoomFeature>();

        database.CreateTable<HotelRoomCategory>();
        database.CreateTable<HotelRoomFeature>();

        List<HotelRoomCategory> categoties = new List<HotelRoomCategory>
        {
            new HotelRoomCategory {CostPerNight = 500, Name = "Suite"},
            new HotelRoomCategory {CostPerNight = 300, Name = "Apartment"},
            new HotelRoomCategory {CostPerNight = 100, Name = "Studio"}
        };

        List<HotelRoomFeature> features = new List<HotelRoomFeature>
        {
            new HotelRoomFeature {HotelRoomCategoryId = 1, Name = "Huge living space", Description = "Living space is 75 m^2"},
            new HotelRoomFeature {HotelRoomCategoryId = 1, Name = "3 rooms", Description = "Contains restroom, working cabinet and bedroom"},
            new HotelRoomFeature {HotelRoomCategoryId = 1, Name = "2 toilet rooms", Description = "Separate toilet room for guests"},
            new HotelRoomFeature {HotelRoomCategoryId = 1, Name = "Huge bed", Description = "Bed is 200*200 sm"},
            new HotelRoomFeature {HotelRoomCategoryId = 1, Name = "Safe", Description = "Contais safe for guest's valuables"},

            new HotelRoomFeature {HotelRoomCategoryId = 2, Name = "Large living space", Description = "Living space is 40 m^2"},
            new HotelRoomFeature {HotelRoomCategoryId = 2, Name = "2 rooms", Description = "Contains restroom and bedroom"},
            new HotelRoomFeature {HotelRoomCategoryId = 2, Name = "Mini bar", Description = "Contains mini bar"},
            new HotelRoomFeature {HotelRoomCategoryId = 2, Name = "Large bed", Description = "Bed is 180*200 sm"},
            new HotelRoomFeature {HotelRoomCategoryId = 2, Name = "TV", Description = "Contains TV"},

            new HotelRoomFeature {HotelRoomCategoryId = 3, Name = "Big living space", Description = "Living space is 25 m^2"},
            new HotelRoomFeature {HotelRoomCategoryId = 3, Name = "1 room", Description = "Cotains big living room"},
            new HotelRoomFeature {HotelRoomCategoryId = 3, Name = "Computer with internet connection", Description = "Avaible upun guest's request"},
            new HotelRoomFeature {HotelRoomCategoryId = 3, Name = "Big bed", Description = "Bed is 160*200 sm"},
            new HotelRoomFeature {HotelRoomCategoryId = 3, Name = "Bath accessories", Description = "Contains bathrobe, shower towels etc."},
        };

        database.InsertAll(categoties);
        database.InsertAll(features);
    }
}
