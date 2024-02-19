using Lab1Pavlovich253505.Entities;
using Lab1Pavlovich253505.Services;

namespace Lab1Pavlovich253505;

public partial class HotelRooms : ContentPage
{
	private IDbService dbService;
	public HotelRooms(IDbService service)
	{
		InitializeComponent();
		dbService = service;
		BindingContext = this;
	}

	private void OnPageLoaded(object sender, EventArgs e)
	{
		var hotelRoomCategories = dbService.GetAllCategories().ToList();
		RoomPicker.ItemsSource = hotelRoomCategories;
	}

	private void OnSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int index = picker.SelectedIndex;
		if(index != -1)
		{
			var categoryFeatures = dbService.GetCategoryFeatures(index + 1).ToList();
			CategoryFeaturesView.ItemsSource = categoryFeatures;
		}
	}
}