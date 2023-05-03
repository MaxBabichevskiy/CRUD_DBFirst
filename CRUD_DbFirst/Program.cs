using CRUD_DbFirst;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Показать - 1\nДобавить - 2 \nУдалить - 3\nРедактировать - 4\nВариант: ");
        int menu = Convert.ToInt32(Console.ReadLine());

        switch (menu)
        {
            case 1:
                {
                    ShowAccounts(); break;
                }
            case 2:
                {
                    string name, surname, money, role;

                    Console.WriteLine("Имя: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Фамилия: ");
                    surname = Console.ReadLine();

                    Console.WriteLine("Деньги: ");
                    money = Console.ReadLine();

                    Console.WriteLine("Роль: ");
                    role = Console.ReadLine();

                    AddNewAccount(name, surname, money, role);
                    ShowAccounts(); break;

                }
                case 3:
                {
                    Console.WriteLine("Ид: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    RemoveAccount(id);
                    ShowAccounts();
                    break;
                }

                case 4: 
                {
                    int id;
                    string name, surname, money, role;

                    Console.WriteLine("Имя: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Имя: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Фамилия: ");
                    surname = Console.ReadLine();

                    Console.WriteLine("Деньги: ");
                    money = Console.ReadLine();

                    Console.WriteLine("Роль: ");
                    role = Console.ReadLine();

                    EditAccount(id, name, surname, money, role);
                    ShowAccounts();
                    break;
                }
        }

        static void ShowAccounts() {
            using (DbBankContext db = new DbBankContext())
            {
                var accounts = db.Accounts.ToList();
                Console.WriteLine(accounts.Count);
                foreach (Account u in accounts)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname} - {u.Money} - {u.Role}");
                }

            }
        }

        static void AddNewAccount(string name, string surname, string money, string role)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Account newAccount = new Account { Name = name, Surname = surname, Money = money, Role = role };
                db.Accounts.Add(newAccount);
                db.SaveChanges();
            }
        }


        static void EditAccount(int entityId, string name, string surname, string money, string role)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var existingEntity = db.Accounts.Find(entityId);
                if (existingEntity != null)
                {
                    existingEntity.Name = name;
                    existingEntity.Surname = surname;
                    existingEntity.Money = money;
                    existingEntity.Role = role;
                    db.Accounts.Update(existingEntity);
                    db.SaveChanges();
                }
            }
        }

        static void RemoveAccount(int entityId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var account = db.Accounts.Find(entityId);
                if (account != null)
                {
                    db.Accounts.Remove(account);
                    db.SaveChanges();
                }
            }
        }
    }
}