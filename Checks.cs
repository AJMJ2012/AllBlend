using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AllBlend {
	public static class Checks {
		private static List<int> Exclude = new List<int> {
			TileID.Teleporter,
			TileID.SillyBalloonPink,
			TileID.SillyBalloonPurple,
			TileID.SillyBalloonGreen,
		};

		public static bool IsMergeable(int tileID) {
			return !Exclude.Any(s => s == (tileID)) && Main.tileSolid[tileID] && !Main.tileSolidTop[tileID] && !Main.tileNoAttach[tileID];
		}

		public static bool MergeTo(int tileID) {
			return IsMergeable(tileID) && !TileID.Sets.TeamTiles[tileID] && !TileID.Sets.Conversion.Grass[tileID] && !TileID.Sets.GrassSpecial[tileID];
		}
	}
}
