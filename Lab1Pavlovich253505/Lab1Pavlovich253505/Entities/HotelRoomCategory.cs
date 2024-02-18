using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Pavlovich253505.Entities;

[Table("HotelRooms")]
public class HotelRoomCategory
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double CostPerNight { get; set; }
}
