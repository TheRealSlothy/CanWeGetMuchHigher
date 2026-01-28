using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;


namespace CanWeGetMuchHigher.Content.Systems
{
	public class SoundDelaySystem : ModSystem
	{
		private static int timer = 0;
		private static bool active = false;
		private static Vector2 soundPosition;

		public static void StartTimer(Vector2 position, int delayTicks)
		{
			soundPosition = position;
			timer = delayTicks;
			active = true;
		}

		public override void PostUpdateEverything()
		{
			if (!active)
				return;

			timer--;

			if (timer <= 0)
			{

				SoundEngine.PlaySound(
					new SoundStyle("CanWeGetMuchHigher/Content/Sounds/别担心，你的电脑没事，这只是个恶作剧，呵呵"),
					soundPosition
				);

				active = false;
			}
		}
	}
}