using Terraria.ModLoader;

namespace .Common.Systems
{
	public class BossDownedSystem : ModSystem
	{
		public static bool TrapperbossDowned = false;
		
		
		public override void ClearWorld()
		{
			TrapperbossDowned = false;
		}
		public override void SaveWorldData(TagCompound tag)
		{
			tag["TrapperbossDowned"] = TrapperbossDowned;
		}
		public override void LoadWorldData(TagCompound tag)
		{
			TrapperbossDowned = tag.GetBool("TrapperbossDowned");
		}

		public override void NotSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = TrapperbossDowned;
			writer.Write(flags);

		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			TrapperbossDowned = flags[0];
		}
	}