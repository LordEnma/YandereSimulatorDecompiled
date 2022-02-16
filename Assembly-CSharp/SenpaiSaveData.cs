using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C1C RID: 7196 RVA: 0x00147070 File Offset: 0x00145270
	public static SenpaiSaveData ReadFromGlobals()
	{
		return new SenpaiSaveData
		{
			customSenpai = SenpaiGlobals.CustomSenpai,
			senpaiEyeColor = SenpaiGlobals.SenpaiEyeColor,
			senpaiEyeWear = SenpaiGlobals.SenpaiEyeWear,
			senpaiFacialHair = SenpaiGlobals.SenpaiFacialHair,
			senpaiHairColor = SenpaiGlobals.SenpaiHairColor,
			senpaiHairStyle = SenpaiGlobals.SenpaiHairStyle,
			senpaiSkinColor = SenpaiGlobals.SenpaiSkinColor
		};
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x001470D0 File Offset: 0x001452D0
	public static void WriteToGlobals(SenpaiSaveData data)
	{
		SenpaiGlobals.CustomSenpai = data.customSenpai;
		SenpaiGlobals.SenpaiEyeColor = data.senpaiEyeColor;
		SenpaiGlobals.SenpaiEyeWear = data.senpaiEyeWear;
		SenpaiGlobals.SenpaiFacialHair = data.senpaiFacialHair;
		SenpaiGlobals.SenpaiHairColor = data.senpaiHairColor;
		SenpaiGlobals.SenpaiHairStyle = data.senpaiHairStyle;
		SenpaiGlobals.SenpaiSkinColor = data.senpaiSkinColor;
	}

	// Token: 0x0400315F RID: 12639
	public bool customSenpai;

	// Token: 0x04003160 RID: 12640
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003161 RID: 12641
	public int senpaiEyeWear;

	// Token: 0x04003162 RID: 12642
	public int senpaiFacialHair;

	// Token: 0x04003163 RID: 12643
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003164 RID: 12644
	public int senpaiHairStyle;

	// Token: 0x04003165 RID: 12645
	public int senpaiSkinColor;
}
