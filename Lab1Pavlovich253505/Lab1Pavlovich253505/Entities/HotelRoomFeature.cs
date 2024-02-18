using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Pavlovich253505.Entities;

[Table("RoomsFeatures")]
public class HotelRoomFeature
{
    [PrimaryKey, AutoIncrement, Indexed]
    [Column("Id")]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    [Indexed]
    public int HotelRoomCategoryId { get; set; }
}
