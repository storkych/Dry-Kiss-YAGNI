using System;

    class Person
    {
        private string? name;
        private int age;

        public string Name
        {
            get { return name!; }
            set { if (!String.IsNullOrEmpty(value)) name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 && value <= 70) // Уточнение для всех классов, где возраст имеет ограничения
                {
                    if (this is Teenager && value >= 13 && value <= 19)
                        age = value;
                    else if (this is Worker && value >= 16)
                        age = value;
                    else if (!(this is Teenager || this is Worker)) // Для класса Man
                        age = value;
                }
            }
        }

        public override string? ToString()
        {
            return $"Человек, {Name}, {Age}";
        }
    }

    class Teenager : Person
    {
        public string? School { get; set; }

        public override string? ToString()
        {
            return $"Подросток, {Name}, {Age}, Место учебы: {School}";
        }
    }

    class Worker : Person
    {
        public string? Workplace { get; set; }

        public override string? ToString()
        {
            return $"Работник, {Name}, {Age}, Место работы: {Workplace}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Nikita";
            person1.Age = 25;
            Person person2 = new Person();
            person2.Name = "Mark";
            person2.Age = 20;
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());

            Teenager teenager1 = new Teenager();
            teenager1.Name = "Anna";
            teenager1.Age = 16;
            teenager1.School = "School nmb 46";
            Teenager teenager2 = new Teenager();
            teenager2.Name = "Milana";
            teenager2.Age = 14;
            teenager2.School = "School nmb 21";
            Console.WriteLine(teenager1.ToString());
            Console.WriteLine(teenager2.ToString());

            Worker worker1 = new Worker();
            worker1.Name = "Alex";
            worker1.Age = 40;
            worker1.Workplace = "Disney";
            Worker worker2 = new Worker();
            worker2.Name = "Vladimir";
            worker2.Age = 30;
            worker2.Workplace = "Pixar";
            Console.WriteLine(worker1.ToString());
            Console.WriteLine(worker2.ToString());
        }
    }

