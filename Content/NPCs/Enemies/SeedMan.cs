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
    internal class SeedMan : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }
            
        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 128;
            NPC.damage = 2;
            NPC.defense = 0;
            NPC.lifeMax = 1;
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = new SoundStyle("CanWeGetMuchHigher/Content/Sounds/Fart");
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 14; // Floating AI (like Wraith)
            AIType = NPCID.Wraith;
            AnimationType = NPCID.Wraith;
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
            return SpawnCondition.Sky.Chance * 5f;
        }

        int shootTimer = 0;

        public override void AI()
        {
            NPC.TargetClosest(true);

            shootTimer++;

            if (shootTimer >= 150 && shootTimer < 180)
            {
                if (Main.rand.NextBool(2)) // 50% chance each tick for smoke
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                    Main.dust[dust].velocity *= 0.5f;
                    Main.dust[dust].noGravity = true;
                }
            }

            if (shootTimer >= 180) // Shoots every 3 seconds (60 ticks = 1 sec)
            {
                shootTimer = 0;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Player target = Main.player[NPC.target];

                    Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    float speed = 8f;
                    Vector2 velocity = direction * speed;

                    Projectile.NewProjectile(
                        NPC.GetSource_FromAI(),
                        NPC.Center,
                        velocity,
                        ModContent.ProjectileType<Projectiles.NPCs.Enemies.SeedManProj>(),
                        15, // Damage
                        1f, // Knockback
                        Main.myPlayer
                    );
                    SoundEngine.PlaySound(new SoundStyle("CanWeGetMuchHigher/Content/Sounds/Spit"), NPC.position);
                }
            }
        }
    }
}