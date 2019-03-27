using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {


        public Program()
        {

        }

        public void Save()
        {

        }

        public void Main(string argument, UpdateType updateSource)
        {
            List<IMyTerminalBlock> allMyBlocks = new List<IMyTerminalBlock>(); // New list containing all blocks on the grid
            List<IMyTextPanel> allMyTextPanels = new List<IMyTextPanel>(); // New list containing all LCD screens on the grid
            allMyBlocks.AddRange(allMyTextPanels); // list of LCDs is now a list under my list containing all blocks on the grid

            GridTerminalSystem.GetBlocksOfType(allMyTextPanels); // retrieves my list of LCDs

            if (allMyTextPanels.Count == 0) // If there is nothing in my list
            {
                Echo("No LCD's on this grid"); // display this on my programmable block hud
            }
            else if (allMyTextPanels.Count > 0) // and if there are LCDs in my list
            {
                Echo("Located LCD's"); // display this on my programmable block hud
                Echo(" "); // an empty space

                foreach (IMyTextPanel textPanel in allMyTextPanels) // for each LCD in my list of LCDs
                {
                    Echo(textPanel.CustomName); // display its custom name on my programmable block hud

                    if (textPanel.CustomName.Contains("LCD1")) // if there is text in one of my LCDs containing "LCD1"
                    {
                        string text = "Hello World!"; // assigns a message string to a variable named text

                        textPanel.WritePublicText(text); // write the text to the LCD meeting the previously defined conditions
                    }
                }
            }
        }
    }
}