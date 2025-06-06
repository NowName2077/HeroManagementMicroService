using HeroManagement.Application.Models.Player;
using HeroManagement.Application.Services;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n=== Boot ===");
        Console.WriteLine("1. Авто тест");
        Console.WriteLine("2. Ручной тест");
        Console.Write("Выберите действие: ");
        switch (Console.ReadLine())
        {
            case "1":
                AutoPresent();
                break;

            case "2":
                Present();
                break;
        }
    }

    static void Present()
    {
        ICollection<Hero> heroes = [];
        ICollection<Item> items = [];
        ICollection<Ability> abilities = [];
        
        Console.WriteLine("\n=== Hero Management System ===");
        Console.WriteLine("1. Показать все сущности администратора");

        Console.Write("Выберите действие: ");

        switch (Console.ReadLine())
        {
            case "1":
                Admin admin = new Admin(Guid.NewGuid(), new Username("Admin"));
                Player player = new Player(Guid.NewGuid(), new Username("Player"));
                break;
            case "2":
                string heroName = Console.ReadLine();
                break;
        }
    }
    static void AutoPresent()
    {
        Console.Clear();
        
        Admin admin = new Admin(Guid.NewGuid(), new Username("Admin"));
        Player player = new Player(Guid.NewGuid(), new Username("Player"));

        //Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Creating admin\nID:{admin.Id}\nUsername: {admin.Username}\n");
        //Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Creating player\nID:{player.Id}\nUsername: {player.Username}\n");
        
        ICollection<Hero> heroes = [];
        ICollection<Item> items = [];
        ICollection<Ability> abilities = [];
        
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"Creating heroes:");
        Console.ResetColor();

        AddHero(admin,heroes,"Scout");
        AddHero(admin,heroes,"Warrior");
        AddHero(admin,heroes,"Mage");
        AddHero(admin,heroes,"Archer");
        Console.WriteLine($"******************");
        foreach (Hero hero in heroes)
        {
            Console.WriteLine($"ID:{hero.Id}\nObjectName: {hero.HeroName}");
        }
        
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"\nCreating items:");
        Console.ResetColor();

        AddItem(admin,items,"Sword");
        AddItem(admin,items,"Bow");
        AddItem(admin,items,"Potion");
        AddItem(admin,items,"Axe");
        Console.WriteLine($"******************");
        foreach (Item item in items)
        {
            Console.WriteLine($"ID:{item.Id}\nObjectName: {item.ItemName}");
        }
        
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"\nCreating abilities:");
        Console.ResetColor();

        AddAbility(admin,abilities,"Running");
        AddAbility(admin,abilities,"Cryomancy");
        AddAbility(admin,abilities,"Night Vision");
        AddAbility(admin,abilities, "Healing");
        Console.WriteLine($"******************");
        foreach (Ability ability in abilities)
        {
            Console.WriteLine($"ID:{ability.Id}\nObjectName: {ability.AbilityName}");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSelect objects");
        Console.ResetColor();
        
        SelectHero(player, heroes, 2);
        SelectItem(player, items, 1);
        SelectAbility(player, abilities, 3);
        
        PlayerPrint(player);
        RemoveHero(player, heroes, 2);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nRemoving heroes");
        Console.ResetColor();
        
        PlayerPrint(player);
        SelectHero(player,heroes, 1);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSelect heroes");
        Console.ResetColor();
        
        PlayerPrint(player);
    }

    static void AddHero(Admin admin, ICollection<Hero> heroes, string heroName)
    {
        var hero = admin.CreateAHero(new ObjectName(heroName));
        heroes.Add(hero);
        // Console.WriteLine($"ID:{hero.Id}\nObjectName{hero.HeroName}\n");
    }
    
    static void AddItem(Admin admin, ICollection<Item> items, string itemName)
    {
        items.Add(admin.CreateAnItem(new ObjectName(itemName)));
    }
    
    static void AddAbility(Admin admin, ICollection<Ability> abilities, string abilityName)
    {
        abilities.Add(admin.CreateAnAbility(new ObjectName(abilityName)));
    }
    
    static void SelectHero(Player player,ICollection<Hero> heroes,int num)
    {
        player.AddHero(heroes.ToList()[num]);
    }
    static void RemoveHero(Player player,ICollection<Hero> heroes,int num)
    {
        player.RemoveHero(heroes.ToList()[num]);
    
    }
    
    static void SelectItem(Player player,ICollection<Item> items,int num)
    {
        player.AddItem(items.ToList()[num]);
    }
    static void RemoveItem(Player player,ICollection<Item> items,int num)
    {
        player.RemoveItem(items.ToList()[num]);
    }
    
    static void SelectAbility(Player player,ICollection<Ability> abilities,int num)
    {
        player.AddAbilities(abilities.ToList()[num]); 
    }
    static void RemoveAbility(Player player,ICollection<Ability> abilities,int num)
    {
        player.RemoveAbilily(abilities.ToList()[num]); 
    }
    static void PlayerPrint(Player player)
    {
        Console.WriteLine($"\n------Player------");
        Console.WriteLine($"ID:{player.Id}\nUsername: {player.Username}\n");
        
        foreach (Hero hero in player.ObservableHeroes)
        { 
            Console.WriteLine($"Hero: {hero.HeroName}");
        }

        foreach (Item item in player.ObservableItems)
        {
            Console.WriteLine($"Item: {item.ItemName}");
        }

        foreach (Ability ability in player.ObservableAbilities)
        {
            Console.WriteLine($"Ability: {ability.AbilityName}");
        }
    }
}