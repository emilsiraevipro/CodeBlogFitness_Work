using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; }
        public Dictionary<Food, double> Foods { get; }
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не задан");
            DateTime Moment = DateTime.UtcNow;
            Dictionary<Food, double> Foods = new Dictionary<Food, double>(); //Foods = new Dictionary<Food, double>(); - это тоже самое
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
