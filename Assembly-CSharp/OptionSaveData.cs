using System;

// Token: 0x02000405 RID: 1029
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C3D RID: 7229 RVA: 0x00149D6C File Offset: 0x00147F6C
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

	// Token: 0x06001C3E RID: 7230 RVA: 0x00149E04 File Offset: 0x00148004
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

	// Token: 0x040031B9 RID: 12729
	public bool disableBloom;

	// Token: 0x040031BA RID: 12730
	public int disableFarAnimations = 5;

	// Token: 0x040031BB RID: 12731
	public bool disableOutlines;

	// Token: 0x040031BC RID: 12732
	public bool disablePostAliasing;

	// Token: 0x040031BD RID: 12733
	public bool enableShadows;

	// Token: 0x040031BE RID: 12734
	public int drawDistance;

	// Token: 0x040031BF RID: 12735
	public int drawDistanceLimit;

	// Token: 0x040031C0 RID: 12736
	public bool fog;

	// Token: 0x040031C1 RID: 12737
	public int fpsIndex;

	// Token: 0x040031C2 RID: 12738
	public bool highPopulation;

	// Token: 0x040031C3 RID: 12739
	public int lowDetailStudents;

	// Token: 0x040031C4 RID: 12740
	public int particleCount;
}
