using Lab1Pavlovich253505.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Pavlovich253505.Services;

public interface IDbService
{
    IEnumerable<HotelRoomCategory> GetAllCategories();
    IEnumerable<HotelRoomFeature> GetCategoryFeatures(int id);
    void Init();
}
