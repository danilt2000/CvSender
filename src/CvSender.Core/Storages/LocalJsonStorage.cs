using System.Text.Json;
using CvSender.Core.Models;
using System.Xml;

namespace CvSender.Core.Storages
{
        internal class LocalJsonStorage
        {
                private readonly string _filePath;

                public LocalJsonStorage(string filePath)
                {
                        _filePath = filePath;
                }

                public List<JobLink> LoadData(string site)
                {
                        if (!File.Exists(_filePath))
                        {
                                return new List<JobLink>();
                        }

                        var json = File.ReadAllText(_filePath);

                        var output = JsonSerializer.Deserialize<List<JobLink>>(json);

                        return (output ?? throw new InvalidOperationException()).Where(x => x.Site == site).ToList();
                }

                //public void SaveData(List<User> users)
                //{
                //        var json = JsonConvert.SerializeObject(users, Formatting.Indented);
                //        File.WriteAllText(_filePath, json);
                //}

                //// Метод обновления пользователя по ID
                //public void UpdateUser(int id, string newName, string newEmail)
                //{
                //        var users = LoadData();
                //        var user = users.Find(u => u.Id == id);

                //        if (user != null)
                //        {
                //                user.Name = newName;
                //                user.Email = newEmail;

                //                SaveData(users); // Сохранить обновленные данные обратно в файл
                //        }
                //        else
                //        {
                //                Console.WriteLine($"User with ID {id} not found.");
                //        }
                //}
        }
}
