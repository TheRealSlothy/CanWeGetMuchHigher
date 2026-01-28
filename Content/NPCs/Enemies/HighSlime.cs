using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework;

namespace CanWeGetMuchHigher.Content.NPCs.Enemies
{
    internal class HighSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 36;
            NPC.height = 21;
            NPC.damage = 2;
            NPC.defense = 0;
            NPC.lifeMax = 25;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/Fart");
            //NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var DropRule = Main.ItemDropsDB.GetRulesForNPCID(NPCID.BlueSlime, false);
            foreach (var rule in DropRule)
            {
                npcLoot.Add(rule);
            }

            if (Main.rand.NextBool(2))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeables.Seed1>(), 10, 1, 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.SummonChip>(), 50, 1, 1));
            }
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 2f;
        }
    }
}