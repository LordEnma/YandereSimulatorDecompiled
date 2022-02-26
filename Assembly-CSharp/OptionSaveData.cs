using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C13 RID: 7187 RVA: 0x00146FA0 File Offset: 0x001451A0
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

	// Token: 0x06001C14 RID: 7188 RVA: 0x00147038 File Offset: 0x00145238
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

	// Token: 0x04003139 RID: 12601
	public bool disableBloom;

	// Token: 0x0400313A RID: 12602
	public int disableFarAnimations = 5;

	// Token: 0x0400313B RID: 12603
	public bool disableOutlines;

	// Token: 0x0400313C RID: 12604
	public bool disablePostAliasing;

	// Token: 0x0400313D RID: 12605
	public bool enableShadows;

	// Token: 0x0400313E RID: 12606
	public int drawDistance;

	// Token: 0x0400313F RID: 12607
	public int drawDistanceLimit;

	// Token: 0x04003140 RID: 12608
	public bool fog;

	// Token: 0x04003141 RID: 12609
	public int fpsIndex;

	// Token: 0x04003142 RID: 12610
	public bool highPopulation;

	// Token: 0x04003143 RID: 12611
	public int lowDetailStudents;

	// Token: 0x04003144 RID: 12612
	public int particleCount;
}
