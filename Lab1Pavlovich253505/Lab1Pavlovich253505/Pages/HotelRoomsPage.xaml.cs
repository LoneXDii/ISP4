using Lab1Pavlovich253505.Entities;
using Lab1Pavlovich253505.Services;

namespace Lab1Pavlovich253505;

public partial class HotelRoomsPage : ContentPage
{
	private IDbService dbService;
	public HotelRoomsPage(IDbService service)
	{
		InitializeComponent();
		dbService = service;
	}

	private void OnPageLoaded(object sender, EventArgs e)
	{
		var hotelRoomCategories = dbService.GetAllCategories().ToList();
		RoomPicker.ItemsSource = hotelRoomCategories;
	}

	private void OnSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		if (picker.SelectedIndex != -1)
		{
			int index = ((HotelRoomCategory)picker.SelectedItem).Id;
			var categoryFeatures = dbService.GetCategoryFeatures(index).ToList();
			CategoryFeaturesView.ItemsSource = categoryFeatures;
		}
	}
}