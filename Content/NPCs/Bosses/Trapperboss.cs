using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Content.NPCs.Bosses
{
	[AutoloadBossHead]
	public class Trapperboss : ModNPC
	{

		private int state
		{
			get => (int)NPC.ai[0];
			set => NPC.ai[0] = value;
		}
		private int subState
		{
			get => (int)NPC.ai[1];
			set => NPC.ai[1] = value;
		}

		private int stateTimer
		{
			get => (int)NPC.ai[2];
			set => NPC.ai[2] = value;
		}

		private int stateTimer2
		{
			get => (int)NPC.ai[3];
			set => NPC.ai[3] = value;
		}




		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Trapper");

			//how many frames we using for this npc
			Main.npcFrameCount[NPC.type] = 1;

			//for the immunity and other frameworks like summoning and shit
			NPCID.Sets.MPAllowedEnemies[NPC.type] = true;
			NPCID.Sets.NPCBestiaryDrawOffset.Add(typeof, drawMods);
		}


		public override void SetDefaults()
		{
			//npc basic stats
			//hitboxes
			NPC.width = 100;
			NPC.height = 100;

			//Damage , defense, life
			NPC.damage = 50;
			NPC.defense = 20;
			NPC.lifeMax = 5000;

			//sounds
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;

			//knockback resist
			NPC.knockBackResist = 0.2f;

			//custom ai
			NPC.aiStyle = -1;

			//boss settings
			NPC.boss = true;
			NPC.SpawnWithHigherTime(30);
			NPC.npcSlots = 10f;

		}

		//so ye aint stun locked lmao
		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			cooldownSlot = ImmunityCooldownID.Bosses;
			return true;
		}
		override public void OnKill()
		{
			//set boss downed flag to true
			Common.Systems.BossDownedSystem.TrapperbossDowned = true;
			//spawn some loot or whatever
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				NPC.DropBossBags();
			}
		}


	}
}