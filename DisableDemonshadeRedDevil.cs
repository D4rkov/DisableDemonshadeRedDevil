using Terraria.ModLoader;

namespace DisableDemonshadeRedDevil
{
	public class DisableDemonshadeRedDevil : Mod
	{
		public Mod CalamityMod;
		public bool CalamityLoaded;

		public override void Load()
		{
			CalamityLoaded = ModLoader.TryGetMod("CalamityMod", out CalamityMod);
		}

		public override void Unload()
		{
			CalamityMod = null;
			CalamityLoaded = false;
		}
    }
    public class DevilPlayer : ModPlayer
    {
		DisableDemonshadeRedDevil instance = ModContent.GetInstance<DisableDemonshadeRedDevil>();
        public override void PreUpdateBuffs()
        {
            if (instance.CalamityLoaded)
			{
				bool devil = instance.CalamityMod.TryFind("DemonshadeRedDevil", out ModProjectile devilProj);
				if (devil)
				{
					Player.ownedProjectileCounts[devilProj.Type] = 1;
				}
			}
        }
    }
}