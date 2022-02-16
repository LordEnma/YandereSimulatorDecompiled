using System;

// Token: 0x020003FE RID: 1022
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C0A RID: 7178 RVA: 0x00146528 File Offset: 0x00144728
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

	// Token: 0x06001C0B RID: 7179 RVA: 0x001465C0 File Offset: 0x001447C0
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

	// Token: 0x04003129 RID: 12585
	public bool disableBloom;

	// Token: 0x0400312A RID: 12586
	public int disableFarAnimations = 5;

	// Token: 0x0400312B RID: 12587
	public bool disableOutlines;

	// Token: 0x0400312C RID: 12588
	public bool disablePostAliasing;

	// Token: 0x0400312D RID: 12589
	public bool enableShadows;

	// Token: 0x0400312E RID: 12590
	public int drawDistance;

	// Token: 0x0400312F RID: 12591
	public int drawDistanceLimit;

	// Token: 0x04003130 RID: 12592
	public bool fog;

	// Token: 0x04003131 RID: 12593
	public int fpsIndex;

	// Token: 0x04003132 RID: 12594
	public bool highPopulation;

	// Token: 0x04003133 RID: 12595
	public int lowDetailStudents;

	// Token: 0x04003134 RID: 12596
	public int particleCount;
}
