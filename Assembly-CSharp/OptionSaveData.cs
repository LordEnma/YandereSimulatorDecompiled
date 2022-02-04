using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C01 RID: 7169 RVA: 0x00146090 File Offset: 0x00144290
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

	// Token: 0x06001C02 RID: 7170 RVA: 0x00146128 File Offset: 0x00144328
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

	// Token: 0x04003120 RID: 12576
	public bool disableBloom;

	// Token: 0x04003121 RID: 12577
	public int disableFarAnimations = 5;

	// Token: 0x04003122 RID: 12578
	public bool disableOutlines;

	// Token: 0x04003123 RID: 12579
	public bool disablePostAliasing;

	// Token: 0x04003124 RID: 12580
	public bool enableShadows;

	// Token: 0x04003125 RID: 12581
	public int drawDistance;

	// Token: 0x04003126 RID: 12582
	public int drawDistanceLimit;

	// Token: 0x04003127 RID: 12583
	public bool fog;

	// Token: 0x04003128 RID: 12584
	public int fpsIndex;

	// Token: 0x04003129 RID: 12585
	public bool highPopulation;

	// Token: 0x0400312A RID: 12586
	public int lowDetailStudents;

	// Token: 0x0400312B RID: 12587
	public int particleCount;
}
