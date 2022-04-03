using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C2C RID: 7212 RVA: 0x00148E3C File Offset: 0x0014703C
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

	// Token: 0x06001C2D RID: 7213 RVA: 0x00148ED4 File Offset: 0x001470D4
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

	// Token: 0x0400319C RID: 12700
	public bool disableBloom;

	// Token: 0x0400319D RID: 12701
	public int disableFarAnimations = 5;

	// Token: 0x0400319E RID: 12702
	public bool disableOutlines;

	// Token: 0x0400319F RID: 12703
	public bool disablePostAliasing;

	// Token: 0x040031A0 RID: 12704
	public bool enableShadows;

	// Token: 0x040031A1 RID: 12705
	public int drawDistance;

	// Token: 0x040031A2 RID: 12706
	public int drawDistanceLimit;

	// Token: 0x040031A3 RID: 12707
	public bool fog;

	// Token: 0x040031A4 RID: 12708
	public int fpsIndex;

	// Token: 0x040031A5 RID: 12709
	public bool highPopulation;

	// Token: 0x040031A6 RID: 12710
	public int lowDetailStudents;

	// Token: 0x040031A7 RID: 12711
	public int particleCount;
}
