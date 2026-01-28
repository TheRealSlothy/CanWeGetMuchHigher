using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CanWeGetMuchHigher.Content.Items.Materials
{

    internal class OGKush : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
        }
    }
}