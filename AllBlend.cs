using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBlend;

public class AllBlend : Mod
{
	public override void PostSetupContent()
	{
		if (Main.netMode != NetmodeID.Server)
		{
			UI.SetLoadingMessage(string.Format("{0}: {1}", DisplayName, GetLocalization("BlendingTiles").Value));
			uint blended = 0;
			uint total = (uint)TileLoader.TileCount;
			for (int i = 0; i < TileLoader.TileCount; i++)
			{
				if (Main.tileBlendAll[i] || Main.tileMergeDirt[i] || i == TileID.Dirt)
				{
					Main.tileBlendAll[i] = false;
					Main.tileMergeDirt[i] = false;
					Main.tileBrick[i] = true;
				}
				for (int j = 0; j < TileLoader.TileCount; j++)
				{
					Main.tileMerge[i][j] = false;
					if ((Checks.MergeTo(i) && Checks.IsMergeable(j)) || (Main.tileRope[i] && (Main.tileRope[j] || Checks.IsMergeable(j))))
					{
						Main.tileMerge[i][j] = true;
					}
				}
				blended++;
				UI.SetLoadingMessageProgress((float)blended / total);
				UI.SetLoadingMessageSubProgressText(string.Format("{0} / {1}", blended, TileLoader.TileCount));
			}
		}
	}
}
