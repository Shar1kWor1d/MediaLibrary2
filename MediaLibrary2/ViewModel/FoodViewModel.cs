using MediaLibrary2.Model;
using MediaLibrary2.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MediaLibrary2.ViewModel
{
    public class FoodViewModel : BindableObject
    {
        // Переменная для хранения состояния
        // выбранного элемента коллекции
        private Food _selectedItem;
        // Объект с логикой по извлечению данных
        // из источника
        FoodService foodService = new();

        // Коллекция извлекаемых объектов
        public ObservableCollection<Food> Foods { get; } = new();

        // Конструктор с вызовом метода
        // получения данных
        public FoodViewModel()
        {
            GetFoodsAsync();
        }

        // Публичное свойство для представления
        // описания выбранного элемента из коллекции
        public string Desc { get; set; }
        public string Title { get; set; }
        public bool CurrentColor { get; set; }


        // Свойство для представления и изменения
        // состояния выбранного объекта
        public Food SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Desc = value?.Description;
                Title = value?.Name;
                CurrentColor = true;
                // Метод отвечает за обновление данных
                // в реальном времени
                OnPropertyChanged(nameof(Desc));
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CurrentColor));
            }
        }

        //команда для добавления нового элемента
        public ICommand AddItemCommand => new Command(() => AddNewItem());

        private void AddNewItem()
        {
            var medialibrary = new Food
            {
                Id = Foods.Count + 1,
                Name = "Title" + Foods.Count,
                Description = "Description",
                TypeOfFood = "country"
            };
            Foods.Insert(0, medialibrary);
        }

        public ICommand RemoveItemCommand => new Command(() => RemoveItem());

        private void RemoveItem()
        {
            Foods.Remove(_selectedItem);
        }

        // Метод получения коллекции объектов
        async Task GetFoodsAsync()
        {
            try
            {
                var foods = await foodService.GetFood();

                if (Foods.Count != 0)
                    Foods.Clear();

                foreach (var food in foods)
                {
                    Foods.Add(food);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!",
                    $"Что-то пошло не так: {ex.Message}", "OK");
            }
        }
    }
}

