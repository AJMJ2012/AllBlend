using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBlend {
	public class AllBlend : Mod {
		public override void PostSetupContent() {
			if (Main.netMode != 2) {
				DALib.UI.SetLoadingMessage("AllBlend: Blending Tiles");
				int blended = 0;
				int total = (int)Math.Pow(TileLoader.TileCount, 2);
				for (int i = 0; i < TileLoader.TileCount; i++) {
					if (Main.tileBlendAll[i] || Main.tileMergeDirt[i] || i == TileID.Dirt) {
						Main.tileBlendAll[i] = false;
						Main.tileMergeDirt[i] = false;
						Main.tileBrick[i] = true;
					}
					for (int j = 0; j < TileLoader.TileCount; j++) {
						Main.tileMerge[i][j] = false;
						if ((Checks.MergeTo(i) && Checks.IsMergeable(j)) || (Main.tileRope[i] && (Main.tileRope[j] || Checks.IsMergeable(j)))) {
							Main.tileMerge[i][j] = true;
						}
						blended++;
						DALib.UI.SetLoadingMessageProgress((float)Math.Sqrt(blended) / TileLoader.TileCount);
						DALib.UI.SetLoadingMessageSubProgressText((int)Math.Sqrt(blended) + "/" + TileLoader.TileCount);
					}
				}
				DALib.UI.SetLoadingMessage("Finalizing...");
				return;
			}
		}
	}
}
