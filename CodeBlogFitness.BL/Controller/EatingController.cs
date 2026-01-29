using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public class EatingController
    {
        private readonly User user;
        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "пользователь не может быть пустым");
            Foods = GetAllFoods();
        }
        private List<Food> GetAllFoods() 
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    return formatter.Deserialize(fs) as List<Food> ?? new List<Food>();
                }
                else
                {
                    return new List<Food>();
                }
            }
        }
    }
}
