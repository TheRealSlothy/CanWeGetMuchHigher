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
    internal class SwampFly : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 52;
            NPC.height = 44;
            NPC.damage = 28;
            NPC.defense = 5;
            NPC.lifeMax = 120;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/SF1");
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 14;
            AIType = NPCID.EnchantedSword;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var DropRule = Main.ItemDropsDB.GetRulesForNPCID(NPCID.Wraith, false);
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
            return SpawnCondition.Sky.Chance * 10f;
        }

        public override void AI()
        {
            // ai[0] = direction (1 or -1)
            if (NPC.ai[0] == 0)
                NPC.ai[0] = 1;

            // Rotation speed
            float spinSpeed = 0.05f;

            NPC.rotation += spinSpeed * NPC.ai[0];

            // Change direction at limits
            if (NPC.rotation > 0.6f)
                NPC.ai[0] = -1;

            if (NPC.rotation < -0.6f)
                NPC.ai[0] = 1;
        }
    }
}