using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;

namespace AllBlend;

public static class Checks
{
	// TODO: Add way to extend this with calls and configs
	private static readonly List<int> exclude = [
		TileID.Teleporter,
		TileID.SillyBalloonPink,
		TileID.SillyBalloonPurple,
		TileID.SillyBalloonGreen,
	];

	public static bool IsMergeable(int tileID)
	{
		return !exclude.Any(s => s == tileID) && Main.tileSolid[tileID] && !Main.tileSolidTop[tileID] && !Main.tileNoAttach[tileID];
	}

	public static bool MergeTo(int tileID)
	{
		return IsMergeable(tileID) && !TileID.Sets.TeamTiles[tileID] && !TileID.Sets.Conversion.Grass[tileID] && !TileID.Sets.GrassSpecial[tileID];
	}
}
