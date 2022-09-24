using MediaLibrary2.Model;
using System.Text.Json;

namespace MediaLibrary2.Services
{
    public class FoodService
    {
        // Создаем список для хранения данных из источника
        List<Food> foodList = new();

        // Метод GetFood() служит для извлечения и сруктурирования данных
        // в соответсвии с существующей моделью данных
        public async Task<IEnumerable<Food>> GetFood()
        {
            // Если список содержит какие-то элементы
            // то вернется последовательность с содержимым этого списка
            if (foodList?.Count > 0)
                return foodList;

            // В данном блоке кода осуществляется подключение, чтение
            // и дессериализация файла - источника данных
            using var stream = await FileSystem.OpenAppPackageFileAsync("food.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            foodList = JsonSerializer.Deserialize<List<Food>>(contents);

            return foodList;
        }
    }
}
