using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x00143CD0 File Offset: 0x00141ED0
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

	// Token: 0x06001BF6 RID: 7158 RVA: 0x00143D68 File Offset: 0x00141F68
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

	// Token: 0x04003107 RID: 12551
	public bool disableBloom;

	// Token: 0x04003108 RID: 12552
	public int disableFarAnimations = 5;

	// Token: 0x04003109 RID: 12553
	public bool disableOutlines;

	// Token: 0x0400310A RID: 12554
	public bool disablePostAliasing;

	// Token: 0x0400310B RID: 12555
	public bool enableShadows;

	// Token: 0x0400310C RID: 12556
	public int drawDistance;

	// Token: 0x0400310D RID: 12557
	public int drawDistanceLimit;

	// Token: 0x0400310E RID: 12558
	public bool fog;

	// Token: 0x0400310F RID: 12559
	public int fpsIndex;

	// Token: 0x04003110 RID: 12560
	public bool highPopulation;

	// Token: 0x04003111 RID: 12561
	public int lowDetailStudents;

	// Token: 0x04003112 RID: 12562
	public int particleCount;
}
