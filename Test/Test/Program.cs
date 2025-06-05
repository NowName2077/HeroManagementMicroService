using HeroManagement.Application.Models.Player;
using HeroManagement.Application.Services;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
namespace Test;

class Program
{
    static void Main(string[] args)
    {
        StaticPresent();

        // string input = Console.ReadLine();
        // switch (input)
        // {
        //     case "1":
        //         Admin admin = new Admin(Guid.NewGuid(), new Username("Admin"));
        //         return;
        //     case"2":
        //         string name = Console.ReadLine();
        //         Player player = new Player(Guid.NewGuid(), new Username(name));
        //         return;
        // }
    }
    
    static void StaticPresent()
    {
        var (admin, player) = CreateActors("Admin", "Player");
        
        CreateHero(admin,"Scout");
        CreateHero(admin,"Warrior");
        CreateHero(admin,"Mage");
        
        CreateAbility(admin,"Running");
        CreateAbility(admin,"Cryomancy");
        CreateAbility(admin,"Night Vision");
        
        CreateItem(admin,"Sword");
        CreateItem(admin,"Gun");
        CreateItem(admin,"Axe");
        
        // admin.ActiveHero.ToList().ForEach(player.AddHero);
        // admin.ActiveItem.ToList().ForEach(player.AddItem);
        // admin.ActiveAbility.ToList().ForEach(player.AddAbilities);
        
        SelectHero(admin, player, 0);
        SelectItem(admin, player, 1);
        SelectAbility(admin, player, 2);
        PlayerPrint(player);
        RemoveHero(admin, player, 0);
        PlayerPrint(player);
        SelectHero(admin, player, 1);
        PlayerPrint(player);
        
    }
    
    static (Admin, Player) CreateActors(string adminName, string playerName)
    {
        Admin admin = new Admin(Guid.NewGuid(), new Username(adminName));
        Player player = new Player(Guid.NewGuid(), new Username(playerName));
        
        Console.WriteLine($"Creating admin\n{admin.Id}, {admin.Username}");
        Console.WriteLine($"Creating player\n{player.Id}, {player.Username}");
        return(admin, player);
    }
    static void CreateHero(Admin admin, string heroName)
    {
        var hero = admin.CreateAHero(new ObjectName(heroName));
        Console.WriteLine($"Создан герой: {hero.Id}, {hero.HeroName}");
        return;
    }
    
    static void CreateItem(Admin admin, string itemName)
    {
        var item = admin.CreateAnItem(new ObjectName(itemName));
        Console.WriteLine($"Создан предмет: {item.Id}, {item.ItemName}");
    }
    
    static void CreateAbility(Admin admin, string abilityName)
    {
        var ability = admin.CreateAnAbility(new ObjectName(abilityName));
        Console.WriteLine($"Создана способность: {ability.Id}, {ability.AbilityName}");
    }

    static void SelectHero(Admin admin,Player player,int num)
    {
        var heroes = admin.ActiveHero.ToList();
        player.AddHero(heroes[num]);

    }
    static void RemoveHero(Admin admin,Player player,int num)
    {
        var heroes = admin.ActiveHero.ToList();
        player.RemoveHero(heroes[num]);

    }
    
    static void SelectItem(Admin admin,Player player,int num)
    {
        var items = admin.ActiveItem.ToList();
        player.AddItem(items[num]);

    }
    static void RemoveItem(Admin admin,Player player,int num)
    {
        var items = admin.ActiveItem.ToList();
        player.RemoveItem(items[num]);

    }
    
    static void SelectAbility(Admin admin,Player player,int num)
    {
        var abilities=   admin.ActiveAbility.ToList();
        player.AddAbilities(abilities[num]); 

    }
    static void RemoveAbility(Admin admin,Player player,int num)
    {
        var abilities=   admin.ActiveAbility.ToList();
        player.RemoveAbilily(abilities[num]); 

    }
    
    static void PlayerPrint(Player player)
    {
        Console.WriteLine($"-------------------");
        Console.WriteLine($"{player.Id}, {player.Username}");
        foreach (Hero hero in player.ObservableHeroes)
        {
            Console.WriteLine($"{hero.Id}, {hero.HeroName}");
        }
        
        foreach (Item item in player.ObservableItems)
        {
                Console.WriteLine($"{item.Id}, {item.ItemName}");
        }
        
        foreach (Ability ability in player.ObservableAbilities)
        {
            Console.WriteLine($"{ability.Id}, {ability.AbilityName}");
        }
    }
    
    // static void CreateHero(Admin admin, string heroName)
    // {
    //     admin.CreateAHero(new ObjectName(heroName));
    //     
    //     foreach (var hero in admin.ActiveHero)
    //     {
    //         Console.WriteLine($"Creating player\n{hero.Id}, {hero.HeroName}");
    //     }
    //
    // }
    //
    // static void CreateItem(Admin admin, string itemName)
    // {
    //     admin.CreateAnItem(new ObjectName(itemName));
    //     
    //     foreach (var item in admin.ActiveItem)
    //     {
    //         Console.WriteLine($"Creating player\n{item.Id}, {item.ItemName}");
    //     }
    // }
    //
    // static void CreateAbility(Admin admin, string abilityName)
    // {
    //     admin.CreateAHero(new ObjectName(abilityName));
    //     
    //     foreach (var ability in admin.ActiveAbility)
    //     {
    //         Console.WriteLine($"Creating player\n{ability.Id}, {ability.AbilityName}");
    //     }
    // }
    
    
    
}