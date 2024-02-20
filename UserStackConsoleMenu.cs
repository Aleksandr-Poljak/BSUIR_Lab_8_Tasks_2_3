using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_8_Tasks_2_3
{
    public class UserStackConsoleMenu<T> where T: BasePerson
    {
        public Stack<T> stack = new Stack<T>(0);
        public UserStackConsoleMenu() { }
        public UserStackConsoleMenu(Stack<T> stack): this()
        {
            this.stack = stack;
        }

        private string textMenu = "1- Извлечь первый элемент\n2- Показать первый элемент\n3- Добавить элемент вверх стека\n4- Проверить элемент по имени" +
            "\n5- Очистить стек\n6- Количество элементов в стеке\n0- Выход";

        public override string ToString()
        {
            return $"Console menu object {stack.ToString}. Count elements: {stack.Count}";
        }
        public void ShowMenu()
        {
            Console.WriteLine(textMenu);
        }
        private int inputNumber()
        {
            Console.WriteLine("Введите номер от 0 до 6:");
            int number;
            if (int.TryParse(Console.ReadLine(), out number) && number >= 0 && number <= 6) return number;
            else return 9999;

        }
        public virtual BasePerson CreateObject()
        {
            Console.WriteLine("Введите имя:");
            string? name = Console.ReadLine();
            name ??= "Unknonw";

            Console.WriteLine("Введите фамилию:");
            string? surname = Console.ReadLine();
            surname ??= "Unknonw";

            Console.WriteLine("Введите возраст");
            int age = int.TryParse(Console.ReadLine(), out int inputAge) ? inputAge : 0;

            Console.WriteLine("Введите пол M или F");
            string? genderStr = Console.ReadLine();
            char gender = 'Z';
            if (genderStr is not null)
            {
                genderStr = genderStr.ToUpper();
                char symbol = genderStr.ToCharArray()[0];
                if (symbol == 'M' || symbol == 'F') gender = symbol;
            }
            if (gender == 'Z') throw new ArgumentException();
            BasePerson user = new User(name, surname, age, gender);
            return user;
        }
        private bool SearchAtName(string name)
        {
            // Метод поиска элемента по имени в стеке.
            bool result = false;
            int size = this.stack.Count;
            Stack<T> tempStack = new Stack<T>(size);
            for (int i = 0; i < size; i++)
            {
                var obj = stack.Pop();
                if (obj.Name == name) result = true;
                tempStack.Push(obj);
            }

            for (int i = 0; i < size; i++)
            {
                var obj = tempStack.Pop();
                stack.Push(obj);
            }

                return result;
        }

        public void Start()
        {
            bool flagON = true;
            while(flagON)
            {
                ShowMenu();
                int number = inputNumber();
                switch(number)
                {
                    case 0:
                        flagON = false; break;
                    case 1:
                        try
                        {
                            Console.WriteLine($"Элемент извлечен: {stack.Pop()}");
                        }
                        catch(InvalidOperationException) { Console.WriteLine("Элементов в стеке нет."); }                     
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine($"Первый элемент в стеке: {stack.Peek()}");
                        }
                        catch (InvalidOperationException) { Console.WriteLine("Элементов в стеке нет."); }
                        break;
                    case 3:
                        try
                        {
                            T user = (T)CreateObject();
                            stack.Push(user);
                        }
                        catch (ArgumentException) { Console.WriteLine("Не верный ввод данных."); };      
                        break;
                    case 4:
                        Console.WriteLine("Введите имя: ");
                        string? name = Console.ReadLine();
                        if(name is not null)
                        {
                            if (SearchAtName(name)) Console.WriteLine($"Объект с именем {name} присувствует в стеке.");
                            else Console.WriteLine($"Объекта с именем {name} в стеке нет.");
                        }
                        break;
                    case 5:
                        stack.Clear();
                        Console.WriteLine("Стек очищен!");
                        break;
                    case 6:
                        Console.WriteLine($"В стеке {stack.Count} элементов.");
                        break;
                    default: Console.WriteLine("Не верный ввод"); break;
                }
            }
        }

    }
}
