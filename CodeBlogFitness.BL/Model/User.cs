using System;
using System.Net.Cache;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User // класс
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; } // свойство
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; } // свойство
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; } // свойство
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; } // свойство
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; } // свойство
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { 
            get { return DateTime.Now.Year - BirthDate.Year; }
        } // свойство
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рорждения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height) // создание конеструктора с 5-ю перегрузками
        {
        #region Проверка исключений(условий)
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "имя не может быть пустым или null.");
            }

            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender), "Пол не может быть пустым или null.");
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("пользователь не может быть старше 125 лет и младше 0.");
            }
            if(weight <= 0)

            {
                throw new ArgumentException("Пользователь не может весить меньше 0 кг.", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("пользователь не может быть ниже 0 см.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }
        public User (string name) //создание конструктора с 1-й перегрузкой
            : this(
                  name: name,
                  gender: new Gender("Не указан"),
                  birthDate: DateTime.UtcNow.AddYears(-30),
                  weight: 70.0,
                  height: 175.0
                  )
        {

        }
        public override string ToString() //переопределение метода ToString()
        {
            return Name + " " + Age;
        }
    }
}
