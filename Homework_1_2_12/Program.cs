using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string bossName = "Тотемный скрытень";
            int bossHealthPointsMax = 2000;
            int bossHealthPoints = bossHealthPointsMax;
            string playerName = "Теневой маг";
            int playerHealthPointsMax = 1000;
            int playerHealthPoints = playerHealthPointsMax;
            bool isBattle = false;
            int furyTotemDamage = 100;
            int totemPowerMax = 3;
            int totemPower = totemPowerMax;
            int furyTotemCostTotemPower = 1;
            int totemSerenityHealingOnOneTotemPower = 20;
            int spellRashamonSelfDamage = 100;
            int spellHyganzakuraDamageOnOneShadowGhost = 100;
            int spellInterdimensionalFractureHealing = 250;
            int spellShadowmainMinCountShadowGhost = 3;
            int spellShadowmainMaxHealthPointsPercent = 10;
            int countShadowGhost = 0;
            int spellRashamonCountShadowGhost = 1;
            bool unableSpellShadowmain = false;
            bool isPlayerInvulnerability;
            int spellInterdimensionalFractureMinShadowGhost = 1;
            int spellInterdimensionalFractureShadowGhostGain = 1;
            int totemSerenityTotemPowerGain = 1;
            int round = 0;
            bool isCorrectCommand = true;
            int healing;
            int healingMax;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Добро пожаловать, " + playerName + "! Твой противник — " + bossName + "! Покажи на что ты способен!");
            Console.WriteLine("Нажмите любую кнопку для начала боя");
            Console.ReadKey();

            while (isBattle==false)
            {
                Console.Clear();

                if (isCorrectCommand==true)
                {
                    round++;
                }

                Console.WriteLine("Раунд " + round + ":");
                Console.WriteLine();
                Console.WriteLine("Атаки героя:");
                Console.WriteLine();
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Рашамон");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": призывает " + spellRashamonCountShadowGhost + " теневого духа. Отнимает " + spellRashamonSelfDamage + " здоровья игроку.");
                Console.Write("2. ");

                if (countShadowGhost > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write("Хуганзакура");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": Может быть выполнен только если у вас под контролем есть теневой дух. Наносит " + spellHyganzakuraDamageOnOneShadowGhost + " ед. урона за каждого теневого духа на вашей стороне.");
                Console.Write("3. ");

                if (countShadowGhost >= spellInterdimensionalFractureMinShadowGhost)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write("Межпространственный разлом");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": позволяет скрыться в разломе до вашего следующего хода и восстановить " + spellInterdimensionalFractureHealing + " ед. здоровья. Пока вы в разломе, вы неуязвимы. Необходимо чтобы под контролем было хотя бы " + spellInterdimensionalFractureMinShadowGhost + " теневых духа. После использования заклинания минимальная необходимость количества теневых духов под контролем увеличивается на " + spellInterdimensionalFractureShadowGhostGain + ".");
                Console.Write("4. ");

                if (countShadowGhost >= spellShadowmainMinCountShadowGhost && unableSpellShadowmain==false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write("Шэдоумэйн");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": можно использовать только если у вас под контролем " + spellShadowmainMinCountShadowGhost + " или более теневых духов. Ваше максимальное здоровье увеличивается на " + spellShadowmainMaxHealthPointsPercent + "% до конца боя. Полностью восстанавливаете здоровье. Уничтожаете всех ваших теневых духов. Может быть использовано один раз за бой.");
                Console.WriteLine();
                Console.WriteLine("Количество здоровья - " + playerHealthPoints);

                if (countShadowGhost > 0)
                {
                    Console.WriteLine("У вас под контролем " + countShadowGhost + " теневых духов");
                }
                
                Console.WriteLine();
                Console.Write("Введите номер заклинания: ");
                string commandPlayer = Console.ReadLine();
                isCorrectCommand = true;
                isPlayerInvulnerability = false;
                Console.WriteLine();

                switch (commandPlayer)
                {
                    case "1":
                        countShadowGhost += spellRashamonCountShadowGhost;
                        playerHealthPoints -= spellRashamonSelfDamage;
                        Console.WriteLine("Вы применили заклинание Рашамон, нанесли себе " + spellRashamonSelfDamage + " ед. урона и призвали " + spellRashamonCountShadowGhost + " теневого духа:");
                        break;
                    case "2":
                        if (countShadowGhost > 0)
                        {
                            int damage = countShadowGhost * spellHyganzakuraDamageOnOneShadowGhost;
                            bossHealthPoints -= damage;
                            Console.WriteLine("Вы применили заклинание Хуганзакура, нанесли противнику " + damage + " ед. урона:");
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать данное заклинание");
                            isCorrectCommand = false;
                        }

                        break;
                    case "3":
                        if (countShadowGhost >= spellInterdimensionalFractureMinShadowGhost)
                        {
                            isPlayerInvulnerability = true;
                            healing = spellInterdimensionalFractureHealing;
                            healingMax = playerHealthPointsMax - playerHealthPoints;

                            if (healingMax < healing)
                            {
                                healing = healingMax;
                            }

                            playerHealthPoints += healing;
                            spellInterdimensionalFractureMinShadowGhost += spellInterdimensionalFractureShadowGhostGain;
                            Console.WriteLine("Вы применили заклинание Межпространственный разлом, восстановили " + healing + " ед. здоровья");
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать данное заклинание");
                            isCorrectCommand = false;
                        }

                        break;
                    case "4":
                        if (countShadowGhost >= spellShadowmainMinCountShadowGhost && unableSpellShadowmain==false)
                        {
                            unableSpellShadowmain = true;
                            playerHealthPointsMax += playerHealthPointsMax * spellShadowmainMaxHealthPointsPercent/100;
                            playerHealthPoints = playerHealthPointsMax;
                            countShadowGhost = 0;
                            Console.WriteLine("Вы применили заклинание Шэдоумэйн, ваши теневые духи отдали свои жизни и усилили вас. Теперь ваш максимальный запас здоровья равен " + playerHealthPointsMax);
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать данное заклинание");
                            isCorrectCommand = false;
                        }

                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        isCorrectCommand = false;
                        break;
                }



                if (isCorrectCommand==true)
                {
                    Console.WriteLine(playerName + " - количество здоровья: " + playerHealthPoints);
                    Console.WriteLine(bossName + " - количество здоровья: " + bossHealthPoints);
                    Console.WriteLine("У вас под контролем " + countShadowGhost + " теневых духов");
                    Console.WriteLine("Количество тотемной силы - " + totemPower);
                    Console.WriteLine();
                    Console.WriteLine("Атаки противника:");
                    Console.WriteLine();
                    Console.Write("1. ");

                    if (totemPower > 0 && isPlayerInvulnerability==false)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write("Тотемная ярость");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": призывает с небес тотем ярости, который попадает на главного противника и взрывается нанося " + furyTotemDamage + " ед. урона. Не может быть применен на вспомогательные цели. Расходует " + furyTotemCostTotemPower + " ед. тотемной силы.");
                    Console.Write("2. ");

                    if (isPlayerInvulnerability==true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write("Тотемное бешенство");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": уничтожает теневого духа. Можно использовать только если главный противник неуязвим.");
                    Console.Write("3. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Тотемная безмятежность");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": максимальное количество тотемной силы увеличивается на " + totemSerenityTotemPowerGain + ". Накапливает полный запас тотемной силы. Восстанавливает " + totemSerenityHealingOnOneTotemPower + " ед. здоровья за каждую единицу тотемной силы.");
                    Console.WriteLine();
                    Console.WriteLine("Количество тотемной силы - " + totemPower);
                    Console.WriteLine("Количество здоровья - " + bossHealthPoints);
                    Console.WriteLine();
                    string commandBoss;

                    if (isPlayerInvulnerability==true)
                    {
                        if (countShadowGhost>0)
                        {
                            commandBoss = "2";
                        }
                        else
                        {
                            commandBoss = "3";
                        }
                    }
                    else
                    {
                        if(totemPower>0)
                        {
                            commandBoss = "1";
                        }
                        else
                        {
                            commandBoss = "3";
                        }
                    }

                    switch (commandBoss)
                    {
                        case "1":
                            playerHealthPoints -= furyTotemDamage;
                            totemPower--;
                            Console.WriteLine("Босс применил тотемную ярость и нанес вам " + furyTotemDamage + " ед. урона");
                            break;
                        case "2":
                            countShadowGhost--;
                            Console.WriteLine("Босс применил тотемное бешенство и уничтожил вашего теневого духа");
                            break;
                        case "3":
                            totemPowerMax++;
                            totemPower = totemPowerMax;
                            healing = totemSerenityHealingOnOneTotemPower * totemPower;
                            healingMax = bossHealthPointsMax - bossHealthPoints;

                            if (healingMax < healing)
                            {
                                healing = healingMax;
                            }

                            bossHealthPoints += healing;
                            Console.WriteLine("Босс применил тотемную безмятежность, восстановил " + healing + " ед. здоровья.");
                            break;
                        default:
                            Console.WriteLine("Ошибка логики ИИ");
                            isBattle = true;
                            break;
                    }
                }

                Console.WriteLine(playerName + " - количество здоровья: " + playerHealthPoints);
                Console.WriteLine(bossName + " - количество здоровья: " + bossHealthPoints);
                Console.WriteLine("У игрока под контролем " + countShadowGhost + " теневых духов");
                Console.WriteLine("Количество тотемной силы - " + totemPower);
                Console.WriteLine();
                Console.ReadKey();

                if (playerHealthPoints <= 0 || bossHealthPoints <= 0)
                {
                    isBattle = true;
                    Console.WriteLine();
                    Console.WriteLine(playerName + " - количество здоровья: " + playerHealthPoints);
                    Console.WriteLine(bossName + " - количество здоровья: " + bossHealthPoints);
                    
                    if (playerHealthPoints<=0 && bossHealthPoints <= 0)
                    {
                        Console.WriteLine("Ничья!");
                    }
                    else if (playerHealthPoints <= 0)
                    {
                        Console.WriteLine("Победил " + bossName);
                    }
                    else
                    { 
                        Console.WriteLine("Победил " + playerName);
                    }
                }
            }
        }
    }
}