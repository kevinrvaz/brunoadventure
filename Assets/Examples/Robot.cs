// Single line comments

/*
Robot for our game
Yey!!
*/

using System;
using UnityEngine;

namespace RPG.Example
{
    // public class Robot : MonoBehaviour
    // {
    //     // Variables
    //     public int age = 1;
    //     public float price = 99.99f;
    //     // private string name = "McBot";
    //     public bool isTurnedOn = false;

    //     public Robot()
    //     {
    //         // isTurnedOn = true;
    //         // enabled = true;
    //         float newPrice = CalculatePrice(0.1f, 0);

    //         if (newPrice > 75f)
    //         {
    //             price = newPrice;
    //         }
    //         else
    //         {
    //             // print("Price is too low.");
    //             // Debug.Log("Price is too low.");
    //             // Debug.LogWarning("Too Low!!!");
    //             // Debug.LogError("Price is too low!!");
    //             Log("Price is too low.");
    //             Log<int>(age);
    //             Log(isTurnedOn);
    //         }
    //     }

    //     [Obsolete("Deprecated, Use ApplyDiscount instead.")]
    //     public float CalculatePrice(float discount, int quantity)
    //     {
    //         return (price - (price * discount)) * quantity;
    //     }

    //     public void Log<T>(T message)
    //     {
    //         Debug.Log(message);
    //     }

    //     public float ApplyDiscount(float discount)
    //     {
    //         return price - (price * discount);
    //     }
    // }
    public class Robot: MonoBehaviour
    {
        private BatteryRegulations includedBattery;

        public Robot()
        {
            includedBattery = new Battery(20f);
            print(includedBattery.health);
            Charger.ChargeBattery(includedBattery);
            includedBattery.CheckHealth();
            print(includedBattery.health);
        }
    }

    public class Battery: BatteryRegulations
    {

        public Battery(float newHealth): base(newHealth) {}
        
        public override void CheckHealth()
        {
            Debug.Log(health);
        }
    }

    static class Charger
    {
        public static bool chargerInUse = false;
        public static void ChargeBattery(BatteryRegulations batteryToCharge)
        {
            chargerInUse = true;
            batteryToCharge.health = 100f;
        }
    }

    public abstract class BatteryRegulations
    {
        public float health;
        public abstract void CheckHealth();

        public BatteryRegulations(float newHealth)
        {
            health = newHealth;
            Debug.Log("New battery created");
        }
    }
}