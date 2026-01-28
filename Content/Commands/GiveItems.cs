using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CanWeGetMuchHigher.Content.Systems;

namespace CanWeGetMuchHigher.Content.Commands
{
    public class GiveItems : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "safe";
        public override string Description => "??? 瑞克卷";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = caller.Player;

            player.QuickSpawnItem(null, ItemID.Safe);

            SoundDelaySystem.StartTimer(player.position, 900);

            Main.NewText("Wow a Safe!", Color.LightGreen);
        }
    }
}