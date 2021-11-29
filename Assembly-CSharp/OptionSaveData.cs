using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001BED RID: 7149 RVA: 0x00143410 File Offset: 0x00141610
	public static OptionSaveData ReadFromGlobals()
	{
		return new OptionSaveData
		{
			disableBloom = OptionGlobals.DisableBloom,
			disableFarAnimations = OptionGlobals.DisableFarAnimations,
			disableOutlines = OptionGlobals.DisableOutlines,
			disablePostAliasing = OptionGlobals.DisablePostAliasing,
			enableShadows = OptionGlobals.EnableShadows,
			drawDistance = OptionGlobals.DrawDistance,
			drawDistanceLimit = OptionGlobals.DrawDistanceLimit,
			fog = OptionGlobals.Fog,
			fpsIndex = OptionGlobals.FPSIndex,
			highPopulation = OptionGlobals.HighPopulation,
			lowDetailStudents = OptionGlobals.LowDetailStudents,
			particleCount = OptionGlobals.ParticleCount
		};
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x001434A8 File Offset: 0x001416A8
	public static void WriteToGlobals(OptionSaveData data)
	{
		OptionGlobals.DisableBloom = data.disableBloom;
		OptionGlobals.DisableFarAnimations = data.disableFarAnimations;
		OptionGlobals.DisableOutlines = data.disableOutlines;
		OptionGlobals.DisablePostAliasing = data.disablePostAliasing;
		OptionGlobals.EnableShadows = data.enableShadows;
		OptionGlobals.DrawDistance = data.drawDistance;
		OptionGlobals.DrawDistanceLimit = data.drawDistanceLimit;
		OptionGlobals.Fog = data.fog;
		OptionGlobals.FPSIndex = data.fpsIndex;
		OptionGlobals.HighPopulation = data.highPopulation;
		OptionGlobals.LowDetailStudents = data.lowDetailStudents;
		OptionGlobals.ParticleCount = data.particleCount;
	}

	// Token: 0x040030DD RID: 12509
	public bool disableBloom;

	// Token: 0x040030DE RID: 12510
	public int disableFarAnimations = 5;

	// Token: 0x040030DF RID: 12511
	public bool disableOutlines;

	// Token: 0x040030E0 RID: 12512
	public bool disablePostAliasing;

	// Token: 0x040030E1 RID: 12513
	public bool enableShadows;

	// Token: 0x040030E2 RID: 12514
	public int drawDistance;

	// Token: 0x040030E3 RID: 12515
	public int drawDistanceLimit;

	// Token: 0x040030E4 RID: 12516
	public bool fog;

	// Token: 0x040030E5 RID: 12517
	public int fpsIndex;

	// Token: 0x040030E6 RID: 12518
	public bool highPopulation;

	// Token: 0x040030E7 RID: 12519
	public int lowDetailStudents;

	// Token: 0x040030E8 RID: 12520
	public int particleCount;
}
