﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using UnityEngine;

namespace ZombieSuicideHotline
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class RetreatCommand : ICommand
    {
        public string Command => "retreat";

        public string[] Aliases => null;

        public string Description => "Allows SCP-173 to teleport to other SCPs";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "";
            Player player = Player.Get(((CommandSender)sender).SenderId);
            if (player.Role == RoleType.Scp173)
            {
               Player ScpTpPlayer = GetTeleportTarget(player);
                if (ScpTpPlayer != null)
                {
                    if (Timerfunc())
                    {
                        player.Position = ScpTpPlayer.Position;
                        response = "Excaped!";
                    }
                    else
                    {
                        response = "retreat is on cooldown for " + (Lasttime + Plugin.Singleton.Config.RetreatCooldown - Time.time).ToString();
                    }
                }
                if (response == "")
                {
                    response = "No alive SCPs!";
                }
            }
            else
            {
                response = "You must be SCP 173 to use this command!";
            }
            return true;
        }
        public float Lasttime = 0;
        public bool Timerfunc()
        {
            if (Lasttime + Plugin.Singleton.Config.RetreatCooldown < Time.time)
            {
                Lasttime = Time.time;
                return true;
            }
            return false;
        }
        public Player GetTeleportTarget(Player sourcePlayer)
        {
            Player targetPlayer = null;
            foreach (Player player in Exiled.API.Features.Player.List)
            {
                if (sourcePlayer.UserId.Equals(player.UserId))
                {
                    continue;
                }

                if (player.Role == RoleType.Scp079)
                {
                    continue;
                }

                if (player.Team == Team.SCP)
                {
                    targetPlayer = player;
                    break;
                }
            }
            if (targetPlayer == null)
            {
                if (Plugin.Singleton.Config.Gobacktospawn.ContainsKey(sourcePlayer.Role.ToString()))
                {
                    sourcePlayer.Position = Plugin.Singleton.Config.Gobacktospawn[sourcePlayer.Role.ToString()];
                }
            }
            return targetPlayer;
        }
    }
}
