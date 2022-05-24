using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C44 RID: 7236 RVA: 0x0014ACA8 File Offset: 0x00148EA8
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

	// Token: 0x06001C45 RID: 7237 RVA: 0x0014AD40 File Offset: 0x00148F40
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

	// Token: 0x040031D6 RID: 12758
	public bool disableBloom;

	// Token: 0x040031D7 RID: 12759
	public int disableFarAnimations = 5;

	// Token: 0x040031D8 RID: 12760
	public bool disableOutlines;

	// Token: 0x040031D9 RID: 12761
	public bool disablePostAliasing;

	// Token: 0x040031DA RID: 12762
	public bool enableShadows;

	// Token: 0x040031DB RID: 12763
	public int drawDistance;

	// Token: 0x040031DC RID: 12764
	public int drawDistanceLimit;

	// Token: 0x040031DD RID: 12765
	public bool fog;

	// Token: 0x040031DE RID: 12766
	public int fpsIndex;

	// Token: 0x040031DF RID: 12767
	public bool highPopulation;

	// Token: 0x040031E0 RID: 12768
	public int lowDetailStudents;

	// Token: 0x040031E1 RID: 12769
	public int particleCount;
}
