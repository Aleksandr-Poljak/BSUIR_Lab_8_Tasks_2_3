using BSUIR_Lab_8_Tasks_2_3;

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

