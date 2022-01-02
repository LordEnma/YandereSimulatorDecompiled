using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001BF7 RID: 7159 RVA: 0x001440CC File Offset: 0x001422CC
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

	// Token: 0x06001BF8 RID: 7160 RVA: 0x00144164 File Offset: 0x00142364
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

	// Token: 0x0400310E RID: 12558
	public bool disableBloom;

	// Token: 0x0400310F RID: 12559
	public int disableFarAnimations = 5;

	// Token: 0x04003110 RID: 12560
	public bool disableOutlines;

	// Token: 0x04003111 RID: 12561
	public bool disablePostAliasing;

	// Token: 0x04003112 RID: 12562
	public bool enableShadows;

	// Token: 0x04003113 RID: 12563
	public int drawDistance;

	// Token: 0x04003114 RID: 12564
	public int drawDistanceLimit;

	// Token: 0x04003115 RID: 12565
	public bool fog;

	// Token: 0x04003116 RID: 12566
	public int fpsIndex;

	// Token: 0x04003117 RID: 12567
	public bool highPopulation;

	// Token: 0x04003118 RID: 12568
	public int lowDetailStudents;

	// Token: 0x04003119 RID: 12569
	public int particleCount;
}
