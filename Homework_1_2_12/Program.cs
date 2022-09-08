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
            const string CASE_SPELL_RASHAMON = "1";
         //   const string caseSpellRashamon = "1";
            const string CASE_SPELL_HYGANZAKURA = "2";
         //   const string caseSpellHyganzakura = "2";
            const string CASE_SPELL_INTERDIMENSIONAL_FRACTURE = "3";
         //   const string caseSpellInterdimensionalFracture = "3";
            const string CASE_SPELL_SHADOWMAIN = "4";
         //   const string caseSpellShadowmain = "4";
            const string CASE_TOTEM_SERENITY = "3";
         //   const string caseTotemSerenity = "3";
            const string CASE_FURY_TOTEM = "1";
         //   const string caseFuryTotem = "1";
            const string CASE_RAGE_TOTEM = "2";
         //   const string caseRageTotem = "2";

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
                Console.Write(CASE_SPELL_RASHAMON + ". ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Рашамон");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": призывает " + spellRashamonCountShadowGhost + " теневого духа. Отнимает " + spellRashamonSelfDamage + " здоровья игроку.");
                Console.Write(CASE_SPELL_HYGANZAKURA + ". ");

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
                Console.Write(CASE_SPELL_INTERDIMENSIONAL_FRACTURE + ". ");

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
                Console.Write(CASE_SPELL_SHADOWMAIN + ". ");

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
                    case CASE_SPELL_RASHAMON:
                        countShadowGhost += spellRashamonCountShadowGhost;
                        playerHealthPoints -= spellRashamonSelfDamage;
                        Console.WriteLine("Вы применили заклинание Рашамон, нанесли себе " + spellRashamonSelfDamage + " ед. урона и призвали " + spellRashamonCountShadowGhost + " теневого духа:");
                        break;
                    case CASE_SPELL_HYGANZAKURA:
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
                    case CASE_SPELL_INTERDIMENSIONAL_FRACTURE:
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
                    case CASE_SPELL_SHADOWMAIN:
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
                    Console.Write(CASE_FURY_TOTEM + ". ");

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
                    Console.Write(CASE_RAGE_TOTEM + ". ");

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
                    Console.Write(CASE_TOTEM_SERENITY + ". ");
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
                            commandBoss = CASE_RAGE_TOTEM;
                        }
                        else
                        {
                            commandBoss = CASE_TOTEM_SERENITY;
                        }
                    }
                    else
                    {
                        if(totemPower>0)
                        {
                            commandBoss = CASE_FURY_TOTEM;
                        }
                        else
                        {
                            commandBoss = CASE_TOTEM_SERENITY;
                        }
                    }

                    switch (commandBoss)
                    {
                        case CASE_FURY_TOTEM:
                            playerHealthPoints -= furyTotemDamage;
                            totemPower--;
                            Console.WriteLine("Босс применил тотемную ярость и нанес вам " + furyTotemDamage + " ед. урона");
                            break;
                        case CASE_RAGE_TOTEM:
                            countShadowGhost--;
                            Console.WriteLine("Босс применил тотемное бешенство и уничтожил вашего теневого духа");
                            break;
                        case CASE_TOTEM_SERENITY:
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