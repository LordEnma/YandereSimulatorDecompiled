using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C43 RID: 7235 RVA: 0x0014A9EC File Offset: 0x00148BEC
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

	// Token: 0x06001C44 RID: 7236 RVA: 0x0014AA84 File Offset: 0x00148C84
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

	// Token: 0x040031CE RID: 12750
	public bool disableBloom;

	// Token: 0x040031CF RID: 12751
	public int disableFarAnimations = 5;

	// Token: 0x040031D0 RID: 12752
	public bool disableOutlines;

	// Token: 0x040031D1 RID: 12753
	public bool disablePostAliasing;

	// Token: 0x040031D2 RID: 12754
	public bool enableShadows;

	// Token: 0x040031D3 RID: 12755
	public int drawDistance;

	// Token: 0x040031D4 RID: 12756
	public int drawDistanceLimit;

	// Token: 0x040031D5 RID: 12757
	public bool fog;

	// Token: 0x040031D6 RID: 12758
	public int fpsIndex;

	// Token: 0x040031D7 RID: 12759
	public bool highPopulation;

	// Token: 0x040031D8 RID: 12760
	public int lowDetailStudents;

	// Token: 0x040031D9 RID: 12761
	public int particleCount;
}
