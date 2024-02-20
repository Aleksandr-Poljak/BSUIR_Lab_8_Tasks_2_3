using BSUIR_Lab_8_Tasks_2_3;
using System.Collections;

//Task 2

User alex = new User("Alex", "Petrov", 24, 'F');
User max = new User("Maxim", "Sidorov", 22, 'F');
User olga = new User("Olga", "Vasiliva", 34, 'M');
User anna = new User("Anna", "Kim", 19, 'M');
User vika = new User("Victoria", "Baranova", 29, 'M');

Stack<User> users = new Stack<User>(12);
users.Push(max);
users.Push(olga);
users.Push(anna);
users.Push(vika);
users.Push(alex);

UserStackConsoleMenu<User> menu = new UserStackConsoleMenu<User>(users);
menu.Start();

//Task 3
//Создайте обобщенный метод, который получает массив произвольного типа и возвращает количество элементов, не равных null.

User[] users1 = new User[] { alex, max, olga, null, vika, null, null, anna };
object[] users2 = new User[] { alex, max, olga, null, vika, null, null };
List<User> users3 = new List<User>() {olga, null, vika, null, null };

Console.WriteLine($"В массиве users1 {CountNotNull<User>(users1)} не null элементов!");
Console.WriteLine($"В массиве users2 типа object {CountNotNull<object>(users2)} не null элементов!");
Console.WriteLine($"В списке users3 {CountNotNull<User>(users3.ToArray())} не null элементов!");

int CountNotNull<T>(T[] arr)
{
    int counter = 0;
    for(int i = 0; i < arr.Length; i++)
    {
        if (arr[i] is not null) counter++;
    }
    return counter;
}

