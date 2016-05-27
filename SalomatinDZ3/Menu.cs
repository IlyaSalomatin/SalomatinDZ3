using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SalomatinDZ3
{
    public class Menu
    {
        List<Employee> fbi = new List<Employee>();
        public string Verification { get; set; }

        public void Deserialize()
        {
            if (Verification=="bin")
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream("FBIbin.dat", FileMode.OpenOrCreate))
                    {
                        fbi = (List<Employee>)bf.Deserialize(fs);
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (Verification == "xml")
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
                    using (FileStream fs = new FileStream("FBIxml.xml", FileMode.OpenOrCreate))
                    {
                        fbi = (List<Employee>)xs.Deserialize(fs);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Ошибка файла option.ini.");
                Console.ReadLine();
            }
        }
        
        public void TypeSerializ()
        {
            try
            {
                //File.Create(@"option.ini");
                string codeword;
                using (StreamReader sr = new StreamReader(@"option.ini", System.Text.Encoding.Default))
                {
                    codeword = sr.ReadToEnd();
                }
                codeword.ToLower();
                if (codeword == "xml")
                {
                    Verification = codeword;

                }
                else if (codeword == "bin")
                {
                    Verification = codeword;

                }
                else
                {
                    Console.WriteLine("Неправильный формат ввода!!!! Файл должен содержать одно из слов : XML / BIN");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void StartProgram()
        {

            fbi.Add(new Employee("Tom", 27, "programmer", 3850));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вас приветствует база данных  FBI :)");
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("Просмотреть записи всех агентов - введите ALL.");
                Console.WriteLine("Просмотреть только одного - введите ONE.");
                Console.WriteLine("Добавить нового агента - введите '+'. ");
                Console.WriteLine("Тзбавиться от агента - введите '-'.");
                Console.WriteLine("Хотите нас покинуть...? Нажмите '0'.");
                Console.Write("Введите команду:");
                string comand = Console.ReadLine();
                comand.ToLower();
                switch (comand)
                {
                    case "all":
                        {
                            AllPeople();
                        }
                        break;
                    case "one":
                        {
                            OnePeople();
                        }
                        break;
                    case "+":
                        {
                            NewPeople();
                        }
                        break;
                    case "-":
                        {
                            KillPeople();
                        }
                        break;
                    case "0":
                        {
                            SetSerializ();
                        }
                        return;
                    default:
                        {
                            Console.WriteLine("Ошибочный ввод!!!");
                            Console.ReadLine();
                        }
                        break;
                }
            }
        }

        public void AllPeople()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("нпп    Имя:     Возраст:    Должность:    ЗП:");
                if (fbi.Count == 0)
                {
                    Console.WriteLine("А здесь никого...((((((");
                }
                int npp = 1;
                foreach (Employee i in fbi)
                {
                    Console.WriteLine(npp++ + "       " + i.Name + "       " + i.Age + "      " + i.Position + "        " + i.Salary + ".");
                }
                Console.WriteLine();
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("Просмотреть только одного - введите ONE.");
                Console.WriteLine("Добавить нового агента - введите '+'. ");
                Console.WriteLine("Тзбавиться от агента - введите '-'.");
                Console.WriteLine("Главное меню -  нажмите '0'.");
                Console.Write("Введите команду:");
                string comand = Console.ReadLine();
                comand.ToLower();
                switch (comand)
                {
                    case "one":
                        {
                            OnePeople();
                        }
                        break;
                    case "+":
                        {
                            NewPeople();
                        }
                        break;
                    case "-":
                        {
                            KillPeople();
                        }
                        break;
                    case "0":
                        return;
                    default:
                        {
                            Console.WriteLine("Ошибочный ввод!!!");
                            Console.ReadLine();
                        }
                        break;
                }
            }
        }
        public void OnePeople()
        {
            Console.Write("Введите порядковый номер агента : ");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number>0&&number<=fbi.Count)
                {
                    --number;
                    Console.Clear();
                    Console.WriteLine("Имя:     Возраст:    Должность:    ЗП:");
                    Console.WriteLine(" " + fbi[number].Name + "       " + fbi[number].Age + "      " + fbi[number].Position + "        " + fbi[number].Salary + ".");
                    Console.WriteLine("Нажмите энтер для разврата....");
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный ввод!!! нажмите энтер для продолжения.");
                Console.ReadLine();
            }
            
        }
        public void NewPeople()
        {
            try
            {
                Console.Write("Вы решили добавить новенького))) Введите его имя...");
                string name = Console.ReadLine();
                Console.Write("Возраст...");
                int age = Convert.ToInt32(Console.ReadLine());
                if (age<=0&&age>150)
                {
                    Console.WriteLine("Ошибочка вышла!!!!!!");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Должность...");
                string position = Console.ReadLine();
                Console.Write("ЗП...");
                int salary = Convert.ToInt32(Console.ReadLine());
                if (salary < 0)
                {
                    Console.WriteLine("Ошибочка вышла!!!!!!");
                    Console.ReadLine();
                    return;
                }
                fbi.Add(new Employee(name, age, position, salary));
                Console.Write("Поздравляем с новым человечком))) жми энтер.");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибочка вышла!!!!!! Нажимай энтер....");
                Console.ReadLine();
            }
            
        }
        public void KillPeople()
        {
            Console.Write("Если вы решили кого-то убрать - не беда)))) Просто введите его порядковвый номер...");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number > 0 && number <= fbi.Count)
                {
                    fbi.RemoveAt(--number);
                    Console.WriteLine("Поздравляем! Одной проблемой меньше))) Если вам понравило - нажмите энтер.");
                }
                else
                {
                    Console.WriteLine("А такого номера нет!!!!!!");
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный ввод!!! нажмите энтер для продолжения.");
                Console.ReadLine();
            } 
        }
        public void SetSerializ() 
        {
            if (Verification == "bin")
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream("FBIbin.dat",FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fs, fbi);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (Verification == "xml")
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
                    using (FileStream fs = new FileStream("FBIxml.xml", FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fs, fbi);
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }  
            }
            else
            {
                Console.WriteLine("Ошибка при конечной сериализации!!!!");
                Console.ReadLine();
            }
        }

    }
}