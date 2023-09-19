using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    public static class Do_1_Interlock2
    {

        public class Character
        {
            private int _armor;
            private int _health = 100;

            public int Health
            {
                get => _health;
                private set => _health = value;
            }

            public int Armor
            {
                get => _armor;
                private set => _armor = value;
            }

            public void Hit(int damage)
            {
                // Health -= damage - Armor;
                int actualDamage = Interlocked.Add(ref damage, -Armor);
                Interlocked.Add(ref _health, -actualDamage);
            }

            public void Heal(int health)
            {
                //Health += health;
                Interlocked.Add(ref _health, health);
            }

            public void CastArmorSpell(bool isPositive)
            {
                if (isPositive)
                {
                    Interlocked.Increment(ref _armor);
                    //Armor++;
                }
                else
                {
                    //Armor--;
                    Interlocked.Decrement(ref _armor);
                }
            }
        }

        
        public static void TestCharacter()
        {
            Character c = new Character();
            
            var tasks = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                Task t1 = Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        c.CastArmorSpell(true);
                    }
                });
                tasks.Add(t1);

                Task t2 = Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        c.CastArmorSpell(false);
                    }
                });
                tasks.Add(t2);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Resulting armor = {c.Armor}");
        }

        private static void Swap(object obj1, object obj2)
        {
            object obj1Ref = Interlocked.Exchange(ref obj1, obj2);
            Interlocked.Exchange(ref obj2, obj1Ref);  
        }
    }


    public static class Lazy<T> where T : class, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                // if current is null, we need to create new instance
                if (_instance == null)
                {
                    // attempt create, it will only set if previous was null
                    Interlocked.CompareExchange(ref _instance, new T(), (T)null);
                }

                return _instance;
            }
        }
    }


}