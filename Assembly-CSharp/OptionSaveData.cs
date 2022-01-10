using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001BFE RID: 7166 RVA: 0x00144440 File Offset: 0x00142640
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

	// Token: 0x06001BFF RID: 7167 RVA: 0x001444D8 File Offset: 0x001426D8
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

	// Token: 0x04003114 RID: 12564
	public bool disableBloom;

	// Token: 0x04003115 RID: 12565
	public int disableFarAnimations = 5;

	// Token: 0x04003116 RID: 12566
	public bool disableOutlines;

	// Token: 0x04003117 RID: 12567
	public bool disablePostAliasing;

	// Token: 0x04003118 RID: 12568
	public bool enableShadows;

	// Token: 0x04003119 RID: 12569
	public int drawDistance;

	// Token: 0x0400311A RID: 12570
	public int drawDistanceLimit;

	// Token: 0x0400311B RID: 12571
	public bool fog;

	// Token: 0x0400311C RID: 12572
	public int fpsIndex;

	// Token: 0x0400311D RID: 12573
	public bool highPopulation;

	// Token: 0x0400311E RID: 12574
	public int lowDetailStudents;

	// Token: 0x0400311F RID: 12575
	public int particleCount;
}
