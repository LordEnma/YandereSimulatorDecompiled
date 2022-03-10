using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C15 RID: 7189 RVA: 0x001474DC File Offset: 0x001456DC
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

	// Token: 0x06001C16 RID: 7190 RVA: 0x00147574 File Offset: 0x00145774
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

	// Token: 0x0400314F RID: 12623
	public bool disableBloom;

	// Token: 0x04003150 RID: 12624
	public int disableFarAnimations = 5;

	// Token: 0x04003151 RID: 12625
	public bool disableOutlines;

	// Token: 0x04003152 RID: 12626
	public bool disablePostAliasing;

	// Token: 0x04003153 RID: 12627
	public bool enableShadows;

	// Token: 0x04003154 RID: 12628
	public int drawDistance;

	// Token: 0x04003155 RID: 12629
	public int drawDistanceLimit;

	// Token: 0x04003156 RID: 12630
	public bool fog;

	// Token: 0x04003157 RID: 12631
	public int fpsIndex;

	// Token: 0x04003158 RID: 12632
	public bool highPopulation;

	// Token: 0x04003159 RID: 12633
	public int lowDetailStudents;

	// Token: 0x0400315A RID: 12634
	public int particleCount;
}
