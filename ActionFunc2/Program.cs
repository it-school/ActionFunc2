using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFunc2
{
    class UserInfo
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public decimal Salary { get; private set; }
        public int Age { get => age; set => age = value; }

        private int age;


        public UserInfo(string Name, string Family, decimal Salary, int age)
        {
            this.Name = Name;
            this.Family = Family;
            this.Salary = Salary;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2:C}, age: {3}", Name, Family, Salary, Age);
        }

        // Данный метод введен для соответствия сигнатуре делегата Func
        public static bool UserSalary(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Salary > obj2.Salary;
        }
        public static bool UserName(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Name.CompareTo(obj2.Name) < 0 ? true : false;
        }
        public static bool UserFamily(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Family.CompareTo(obj2.Family) < 0 ? true : false;
        }
        public static bool UserAgeDecremental(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Age > obj2.Age;
        }
        public static bool UserAgeIncremental(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Age < obj2.Age;
        }
    }

    class ArrSort
    {
        // Реализуем обобщенный метод сортировки
        public static void Sort<T>(IList<T> sortArray, Func<T, T, bool> res)
        {
            bool mySort = true;
            do
            {
                mySort = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (res(sortArray[i + 1], sortArray[i]))
                    {
                        T j = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = j;
                        mySort = true;
                    }
                }
            } while (mySort);
        }
    }

    class Program
    {
        static void Main()
        {
            // Массив
            UserInfo[] userinfo = { new UserInfo("Дмитрий","Чалкин", 50000, 34),
                                            new UserInfo("Алексей","Галкин", 10000, 23),
                                            new UserInfo("Евгений","Малкин", 40000, 45),
                                            new UserInfo("Сергей","Залкинд", 5000, 17),
                                            new UserInfo("Василий","Палкин", 100000, 20)
                                        };

            ArrSort.Sort(userinfo, UserInfo.UserSalary);

            Console.WriteLine("Сортируем исходный массив объектов по доходу: \n-------------------------------------\n");
            foreach (var ui in userinfo)
                Console.WriteLine(ui);

            // Список
            List<UserInfo> userInfos = new List<UserInfo>();
            userInfos.Add(new UserInfo("Дмитрий", "Чалкин", 50000, 34));
            userInfos.Add(new UserInfo("Алексей", "Галкин", 10000, 45));
            userInfos.Add(new UserInfo("Евгений", "Малкин", 40000, 56));
            userInfos.Add(new UserInfo("Сергей", "Залкинд", 5000, 78));
            userInfos.Add(new UserInfo("Василий", "Палкин", 100000, 20));

            Console.WriteLine("\n-------------------------------------\nПеред сортировкой:\n");
            ArrSort.Sort(userInfos, UserInfo.UserName);
            foreach (var ui in userInfos)
                Console.WriteLine(ui);

            Console.WriteLine("Сортируем исходный список из объектов по Доходу: \n-------------------------------------\n");
            ArrSort.Sort(userInfos, UserInfo.UserSalary);
            foreach (var ui in userInfos)
                Console.WriteLine(ui);

            Console.WriteLine("Сортируем исходный список из объектов по Имени: \n-------------------------------------\n");
            ArrSort.Sort(userInfos, UserInfo.UserName);
            foreach (var ui in userInfos)
                Console.WriteLine(ui);

            Console.WriteLine("Сортируем исходный список из объектов по Фамилии: \n-------------------------------------\n");
            ArrSort.Sort(userInfos, UserInfo.UserFamily);
            foreach (var ui in userInfos)
                Console.WriteLine(ui);

            Console.WriteLine("Сортируем исходный список из объектов по убыванию возраста: \n-------------------------------------\n");
            ArrSort.Sort(userInfos, UserInfo.UserAgeDecremental);
            foreach (var ui in userInfos)
                Console.WriteLine(ui);
            
            Console.WriteLine("Сортируем исходный список из объектов по возрастанию возраста: \n-------------------------------------\n");
            ArrSort.Sort(userInfos, UserInfo.UserAgeIncremental);
            foreach (var ui in userInfos)
                Console.WriteLine(ui);
        }
    }
}
