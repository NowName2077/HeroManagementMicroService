using HeroManagement.Application.Models.Player;
using HeroManagement.Application.Services;
using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Admin admin = new Admin(Guid.NewGuid(), new Username("Admin"));
        admin.CreateAHero(new ObjectName("Scout"));
        admin.CreateAnItem(new ObjectName("Sword"));
        admin.CreateAnAbility(new ObjectName("Running"));
        
        Player player = new Player(Guid.NewGuid(), new Username("Player"));
    }
}