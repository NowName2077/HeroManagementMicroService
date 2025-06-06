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
    }

    static void Present()
    {
        Admin admin = new Admin(Guid.NewGuid(), new Username("Admin"));
        Player player = new Player(Guid.NewGuid(), new Username("Player"));
        
        Console.WriteLine($"Creating admin\n{admin.Id}, {admin.Username}");
        Console.WriteLine($"Creating player\n{player.Id}, {player.Username}");
        
        ICollection<Hero> heroes = [];
        ICollection<Item> items = [];
        ICollection<Ability> abilities = [];
        
        AddHero(admin,heroes,"Scout");
        AddHero(admin,heroes,"Warrior");
        AddHero(admin,heroes,"Mage");
        AddHero(admin,heroes,"Archer");
        
        AddItem(admin,items,"Sword");
        AddItem(admin,items,"Bow");
        AddItem(admin,items,"Potion");
        AddItem(admin,items,"Axe");
        
        AddAbility(admin,abilities,"Running");
        AddAbility(admin,abilities,"Cryomancy");
        AddAbility(admin,abilities,"Night Vision");
        AddAbility(admin,abilities, "Healing");
        
        SelectHero(player, heroes, 2);
        SelectItem(player, items, 1);
        SelectAbility(player, abilities, 3);
        
        PlayerPrint(player);
        RemoveHero(player, heroes, 2);
        PlayerPrint(player);
        SelectHero(player,heroes, 1);
        PlayerPrint(player);
    }

    static void AddHero(Admin admin, ICollection<Hero> heroes, string heroName)
    {
        heroes.Add(admin.CreateAHero(new ObjectName(heroName)));
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
}