using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class OptionSaveData
{
	// Token: 0x06001C36 RID: 7222 RVA: 0x00149530 File Offset: 0x00147730
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

	// Token: 0x06001C37 RID: 7223 RVA: 0x001495C8 File Offset: 0x001477C8
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

	// Token: 0x040031AA RID: 12714
	public bool disableBloom;

	// Token: 0x040031AB RID: 12715
	public int disableFarAnimations = 5;

	// Token: 0x040031AC RID: 12716
	public bool disableOutlines;

	// Token: 0x040031AD RID: 12717
	public bool disablePostAliasing;

	// Token: 0x040031AE RID: 12718
	public bool enableShadows;

	// Token: 0x040031AF RID: 12719
	public int drawDistance;

	// Token: 0x040031B0 RID: 12720
	public int drawDistanceLimit;

	// Token: 0x040031B1 RID: 12721
	public bool fog;

	// Token: 0x040031B2 RID: 12722
	public int fpsIndex;

	// Token: 0x040031B3 RID: 12723
	public bool highPopulation;

	// Token: 0x040031B4 RID: 12724
	public int lowDetailStudents;

	// Token: 0x040031B5 RID: 12725
	public int particleCount;
}
