using HeroManagement.Application.Models.Player;
using HeroManagement.Application.Services;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
namespace Test;

class Program
{
    static void Main(string[] args)
    {
        // string name  = Console.ReadLine();
        // ObjectName objectName = new ObjectName(name);
        // Console.WriteLine(objectName);
        // Hero hero = new Hero(Guid.NewGuid(), objectName);
        // Console.WriteLine($"{hero.Id} {hero.HeroName}");


        // string name  = Console.ReadLine();
        // string titel = Console.ReadLine();
        //
        //
        // Username username = new Username(name);
        // ObjectName objectName = new ObjectName(titel);
        //
        // Player  player = new Player(Guid.NewGuid(), username);
        // Hero hero = new Hero(objectName);
        // player.PickAHero(hero);
        //
        // Console.WriteLine($"{hero.Id} {hero.HeroName}");
        // Console.WriteLine($"{player.Id} {player.Username} {player.ObservableHeroes}");




        // string name = Console.ReadLine();
        //
        // Username username = new Username(name);
        //
        // Admin admin = new Admin(Guid.NewGuid(), username);
        //
        // Console.WriteLine(admin.Username);
        // string newName = Console.ReadLine();
        
        PlayerCreateModel player = new PlayerCreateModel(Guid.NewGuid(), "Player");
        
        
        
    }
}