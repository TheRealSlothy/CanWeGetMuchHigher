using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework;

namespace CanWeGetMuchHigher.Content.NPCs.Friendly
{
    [AutoloadHead]
    public class Drew : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ActsLikeTownNPC[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 40;
            NPC.damage = 0;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0f;
            NPC.friendly = true;
            NPC.townNPC = true;
            NPC.aiStyle = 7;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;

            if (NPC.frameCounter >= 6) // speed (lower = faster)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y >= frameHeight * 23)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            return true;
        }

        public override string GetChat()
        {
            return "Yo, its drew here.";
        }
    }
}