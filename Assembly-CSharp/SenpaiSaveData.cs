using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C34 RID: 7220 RVA: 0x00148EC8 File Offset: 0x001470C8
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

	// Token: 0x06001C35 RID: 7221 RVA: 0x00148F28 File Offset: 0x00147128
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

	// Token: 0x040031B9 RID: 12729
	public bool customSenpai;

	// Token: 0x040031BA RID: 12730
	public string senpaiEyeColor = string.Empty;

	// Token: 0x040031BB RID: 12731
	public int senpaiEyeWear;

	// Token: 0x040031BC RID: 12732
	public int senpaiFacialHair;

	// Token: 0x040031BD RID: 12733
	public string senpaiHairColor = string.Empty;

	// Token: 0x040031BE RID: 12734
	public int senpaiHairStyle;

	// Token: 0x040031BF RID: 12735
	public int senpaiSkinColor;
}
