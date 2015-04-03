#region

using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

#endregion

namespace AutoQ
{
    internal class Program
    {

        
        public static Spell Q;

        //Menu
        public static Menu Config;

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            

            //Create the spells
            Q = new Spell(SpellSlot.Q, 500f);
            

            //Create the menu
            Config = new Menu(ObjectManager.Player.BaseSkinName, ObjectManager.Player.BaseSkinName, true);

            Config.AddItem(new MenuItem("hold", "Use Q, hold").SetValue(new KeyBind('Z', KeyBindType.Press)));
            Config.AddItem(new MenuItem("toggle", "Use Q, toggle").SetValue(new KeyBind('X', KeyBindType.Toggle)));

            Config.AddToMainMenu();

            
            
            Game.OnUpdate += Game_OnGameUpdate;
        }

        private static void Game_OnGameUpdate(EventArgs args)
        {

            if (Config.Item("hold").GetValue<KeyBind>().Active || Config.Item("toggle").GetValue<KeyBind>().Active)
            {
                if (Q.IsReady())
                {
                    Q.Cast();
                }
            }
        }

    }
}