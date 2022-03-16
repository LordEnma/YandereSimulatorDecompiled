using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C22 RID: 7202 RVA: 0x00148380 File Offset: 0x00146580
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

	// Token: 0x06001C23 RID: 7203 RVA: 0x00148418 File Offset: 0x00146618
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

	// Token: 0x04003183 RID: 12675
	public bool disableBloom;

	// Token: 0x04003184 RID: 12676
	public int disableFarAnimations = 5;

	// Token: 0x04003185 RID: 12677
	public bool disableOutlines;

	// Token: 0x04003186 RID: 12678
	public bool disablePostAliasing;

	// Token: 0x04003187 RID: 12679
	public bool enableShadows;

	// Token: 0x04003188 RID: 12680
	public int drawDistance;

	// Token: 0x04003189 RID: 12681
	public int drawDistanceLimit;

	// Token: 0x0400318A RID: 12682
	public bool fog;

	// Token: 0x0400318B RID: 12683
	public int fpsIndex;

	// Token: 0x0400318C RID: 12684
	public bool highPopulation;

	// Token: 0x0400318D RID: 12685
	public int lowDetailStudents;

	// Token: 0x0400318E RID: 12686
	public int particleCount;
}
