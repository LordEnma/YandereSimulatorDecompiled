using System;

// Token: 0x0200040A RID: 1034
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C48 RID: 7240 RVA: 0x0014A078 File Offset: 0x00148278
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

	// Token: 0x06001C49 RID: 7241 RVA: 0x0014A0D8 File Offset: 0x001482D8
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

	// Token: 0x040031E0 RID: 12768
	public bool customSenpai;

	// Token: 0x040031E1 RID: 12769
	public string senpaiEyeColor = string.Empty;

	// Token: 0x040031E2 RID: 12770
	public int senpaiEyeWear;

	// Token: 0x040031E3 RID: 12771
	public int senpaiFacialHair;

	// Token: 0x040031E4 RID: 12772
	public string senpaiHairColor = string.Empty;

	// Token: 0x040031E5 RID: 12773
	public int senpaiHairStyle;

	// Token: 0x040031E6 RID: 12774
	public int senpaiSkinColor;
}
