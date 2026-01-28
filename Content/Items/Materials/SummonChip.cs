using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CanWeGetMuchHigher.Content.Items.Materials
{

    internal class SummonChip : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
        }
    }
}