using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CanWeGetMuchHigher.Content.MyPlayer
{
    internal class MyPlayer420 : ModPlayer
    {
        public override void PostUpdate()
        {
            Item petSlotItem = Player.miscEquips[0];

            if (petSlotItem.type == ModContent.ItemType<Items.Pets.Roomba>())
            {
                if (!Player.HasBuff(ModContent.BuffType<Buffs.RoombaBuff>()))
                {
                    Player.AddBuff(ModContent.BuffType<Buffs.RoombaBuff>(), 3600);
                }
            }
        }
    }
}