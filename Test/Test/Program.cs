using HeroManagement.Application.Models.Player;
using HeroManagement.Application.Services;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Present();
        // Console.WriteLine("=== Boot ===");
        // Console.WriteLine("1. авто тест");
        // Console.WriteLine("2. ручной тест");
        // Console.Write("Выберите действие: ");
        // switch (Console.ReadLine())
        // {
        //     case "1":
        //         StaticPresent();
        //         break;
        //
        //     case "2":
        //         Present();
        //         break;
        // }
    }

    static void Present()
    {
        Admin admin = new Admin(Guid.NewGuid(), new Username("Admin"));
        Player player = new Player(Guid.NewGuid(), new Username("Player"));
        
        Console.WriteLine($"Creating admin\n{admin.Id}, {admin.Username}");
        Console.WriteLine($"Creating player\n{player.Id}, {player.Username}");
        
        admin.CreateAHero(new ObjectName("Warrior"));
        var items = admin.CreateAnItem(new ObjectName("Gun"));
        admin.CreateAnAbility(new ObjectName("Runing"));


        IList<T> collection = [];
        player.AddItem(items);
        
        foreach (Item item in player.ObservableItems)
        {
                Console.WriteLine($"{item.Id}, {item.ItemName}");
        }
        
    }

    // static void Present()
    // {
    //     Console.Clear();
    //     Console.WriteLine("=== Hero Management System ===");
    //     Console.WriteLine("1. Создать администратора и игрока");
    //     Console.WriteLine("2. Создать героя");
    //     Console.WriteLine("3. Добавить сущность игроку");
    //     Console.WriteLine("4. Удалить сущность у игрока");
    //     Console.WriteLine("5. Изменить имя игрока");
    //     Console.WriteLine("6. Удалить сущность у администратора");
    //     Console.WriteLine("7. Выход");
    //     Console.Write("Выберите действие: ");
    //     switch (Console.ReadLine())
    //     {
    //         case "1":
    //             var (admin, player) = CreateActors("Admin", "Player");
    //             return;
    //
    //         case "2": 
    //             Console.Write($"Введите имя героя");
    //             
    //             string heroName = Console.ReadLine();
    //             //CreateHero(admin, heroName);
    //             
    //             break;
    //
    //         case "3": // Добавить сущность игроку
    //             
    //             break;
    //
    //         case "4": // Удалить сущность у игрока
    //             
    //             break;
    //
    //         case "5": // Изменить имя игрока
    //             break;
    //
    //         case "6": // Удалить сущность у администратора
    //             break;
    //         
    //
    //         default:
    //             Console.WriteLine("Неверный ввод!");
    //             break;
    //     }
    // }
    // static void StaticPresent()
    // {
    //     Console.Clear();
    //     var (admin, player) = CreateActors("Admin", "Player");
    //     
    //     CreateHero(admin,"Scout");
    //     CreateHero(admin,"Warrior");
    //     CreateHero(admin,"Mage");
    //     CreateHero(admin, "Archer");
    //     
    //     CreateAbility(admin,"Running");
    //     CreateAbility(admin,"Cryomancy");
    //     CreateAbility(admin,"Night Vision");
    //     CreateAbility(admin, "Healing");
    //     
    //     CreateItem(admin,"Sword");
    //     CreateItem(admin, "Bow");
    //     CreateItem(admin, "Potion");
    //     CreateItem(admin,"Axe");
    //     
    //     SelectHero(admin, player, 0);
    //     SelectItem(admin, player, 1);
    //     SelectAbility(admin, player, 2);
    //     PlayerPrint(player);
    //     RemoveHero(admin, player, 0);
    //     PlayerPrint(player);
    //     SelectHero(admin, player, 1);
    //     PlayerPrint(player);
    //     var items = admin.ActiveItem.ToList();
    //     Console.WriteLine($"1{items[1].ItemName}");
    //     admin.DeleteAnItem(items[1]);
    //     Console.WriteLine($"2{items[1].ItemName}");
    //     PlayerPrint(player);
    // }
    //
    // static (Admin, Player) CreateActors(string adminName, string playerName)
    // {
    //     Admin admin = new Admin(Guid.NewGuid(), new Username(adminName));
    //     Player player = new Player(Guid.NewGuid(), new Username(playerName));
    //     
    //     Console.WriteLine($"Creating admin\n{admin.Id}, {admin.Username}");
    //     Console.WriteLine($"Creating player\n{player.Id}, {player.Username}");
    //     return(admin, player);
    // }
    // static void CreateHero(Admin admin, string heroName)
    // {
    //     var hero = admin.CreateAHero(new ObjectName(heroName));
    //     Console.WriteLine($"Создан герой: {hero.Id}, {hero.HeroName}");
    //     return;
    // }
    //
    // static void CreateItem(Admin admin, string itemName)
    // {
    //     var item = admin.CreateAnItem(new ObjectName(itemName));
    //     Console.WriteLine($"Создан предмет: {item.Id}, {item.ItemName}");
    // }
    //
    // static void CreateAbility(Admin admin, string abilityName)
    // {
    //     var ability = admin.CreateAnAbility(new ObjectName(abilityName));
    //     Console.WriteLine($"Создана способность: {ability.Id}, {ability.AbilityName}");
    // }
    //
    // static void SelectHero(Admin admin,Player player,int num)
    // {
    //     var heroes = admin.ActiveHero.ToList();
    //     player.AddHero(heroes[num]);
    //
    // }
    // static void RemoveHero(Admin admin,Player player,int num)
    // {
    //     var heroes = admin.ActiveHero.ToList();
    //     player.RemoveHero(heroes[num]);
    //
    // }
    //
    // static void SelectItem(Admin admin,Player player,int num)
    // {
    //     var items = admin.ActiveItem.ToList();
    //     player.AddItem(items[num]);
    //
    // }
    // static void RemoveItem(Admin admin,Player player,int num)
    // {
    //     var items = admin.ActiveItem.ToList();
    //     player.RemoveItem(items[num]);
    //
    // }
    //
    // static void SelectAbility(Admin admin,Player player,int num)
    // {
    //     var abilities=   admin.ActiveAbility.ToList();
    //     player.AddAbilities(abilities[num]); 
    //
    // }
    // static void RemoveAbility(Admin admin,Player player,int num)
    // {
    //     var abilities=   admin.ActiveAbility.ToList();
    //     player.RemoveAbilily(abilities[num]); 
    //
    // }
    //
    // static void PlayerPrint(Player player)
    // {
    //     Console.WriteLine($"-------------------");
    //     Console.WriteLine($"{player.Id}, {player.Username}");
    //     foreach (Hero hero in player.ObservableHeroes)
    //     {
    //         Console.WriteLine($"{hero.Id}, {hero.HeroName}");
    //     }
    //     
    //     foreach (Item item in player.ObservableItems)
    //     {
    //             Console.WriteLine($"{item.Id}, {item.ItemName}");
    //     }
    //     
    //     foreach (Ability ability in player.ObservableAbilities)
    //     {
    //         Console.WriteLine($"{ability.Id}, {ability.AbilityName}");
    //     }
    // }
}