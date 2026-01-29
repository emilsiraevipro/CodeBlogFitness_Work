using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    public class Food
    {

        public string Name { get; }
        public double MyProperty { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории на 100 гр.
        /// </summary>
        public double Calories { get; }

        //private double CalloriesOneGramm => Calories / 100.0; //property via expression - bodied member
        //private double ProteinsOneGramm => Proteins / 100.0; //property via expression - bodied member
        //private double FatsOneGramm => Fats / 100.0; //property via expression - bodied member
        //private double CarbonhydratesOneGramm => Carbohydrates / 100.0; //property via expression - bodied member

        public Food(string name) : this(name, 0, 0, 0, 0){}

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя не может быть пустым полем.");
            }
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
