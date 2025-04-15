using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace ЖКХ
{
    public partial class RegistrationWindow : Page
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            LoadBuildings();
        }

        private void LoadBuildings()
        {
            using (var db = new Entities1())
            {
                buildingComboBox.ItemsSource = db.Buildings.ToList();
                buildingComboBox.DisplayMemberPath = "Address";
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация данных
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(firstNameText.Text))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(lastNameText.Text))
                errors.AppendLine("Укажите фамилию");

            var phoneRegex = new Regex(@"^\+7\d{10}$");
            if (!phoneRegex.IsMatch(phoneText.Text))
                errors.AppendLine("Номер телефона должен быть в формате +7XXXXXXXXXX");

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(emailText.Text))
                errors.AppendLine("Неверный формат email");

            if (string.IsNullOrWhiteSpace(loginText.Text))
                errors.AppendLine("Укажите логин");

            if (passwordText.Password.Length < 6)
                errors.AppendLine("Пароль должен быть не менее 6 символов");

            if (passwordText.Password != confirmPasswordText.Password)
                errors.AppendLine("Пароли не совпадают");

            if (buildingComboBox.SelectedItem == null)
                errors.AppendLine("Выберите дом");

            if (!int.TryParse(apartmentNumberText.Text, out _))
                errors.AppendLine("Номер квартиры должен быть числом");

            if (!decimal.TryParse(areaText.Text, out _))
                errors.AppendLine("Площадь должна быть числом");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var db = new Entities1())
                {
                    // Проверка уникальности логина
                    if (db.Users.Any(u => u.Username == loginText.Text))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                                      MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Создание жильца
                    var resident = new Resident
                    {
                        FirstName = firstNameText.Text,
                        LastName = lastNameText.Text,
                        PhoneNumber = phoneText.Text,
                        Email = emailText.Text,
                        RoleID = 2 // Роль "Жилец"
                    };
                    db.Residents.Add(resident);
                    db.SaveChanges();

                    // Создание квартиры
                    var selectedBuilding = (Building)buildingComboBox.SelectedItem;
                    var apartment = new Apartment
                    {
                        BuildingID = selectedBuilding.BuildingID,
                        ApartmentNumber = int.Parse(apartmentNumberText.Text),
                        Area = decimal.Parse(areaText.Text),
                        ResidentID = resident.ResidentID
                    };
                    db.Apartments.Add(apartment);
                    db.SaveChanges();

                    // Создание пользователя
                    var user = new User
                    {
                        Username = loginText.Text,
                        Password = AuthorizationPage.GetHash(passwordText.Password),
                        RoleID = 2 // Роль "Жилец"
                        // ResidentID не нужно, так как нет такого поля в User
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("Регистрация успешно завершена!", "Успех",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new AuthorizationPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}