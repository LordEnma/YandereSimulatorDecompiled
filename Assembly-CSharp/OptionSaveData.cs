using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C32 RID: 7218 RVA: 0x00149120 File Offset: 0x00147320
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

	// Token: 0x06001C33 RID: 7219 RVA: 0x001491B8 File Offset: 0x001473B8
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

	// Token: 0x0400319F RID: 12703
	public bool disableBloom;

	// Token: 0x040031A0 RID: 12704
	public int disableFarAnimations = 5;

	// Token: 0x040031A1 RID: 12705
	public bool disableOutlines;

	// Token: 0x040031A2 RID: 12706
	public bool disablePostAliasing;

	// Token: 0x040031A3 RID: 12707
	public bool enableShadows;

	// Token: 0x040031A4 RID: 12708
	public int drawDistance;

	// Token: 0x040031A5 RID: 12709
	public int drawDistanceLimit;

	// Token: 0x040031A6 RID: 12710
	public bool fog;

	// Token: 0x040031A7 RID: 12711
	public int fpsIndex;

	// Token: 0x040031A8 RID: 12712
	public bool highPopulation;

	// Token: 0x040031A9 RID: 12713
	public int lowDetailStudents;

	// Token: 0x040031AA RID: 12714
	public int particleCount;
}
