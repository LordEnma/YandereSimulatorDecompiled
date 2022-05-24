using System;

// Token: 0x0200040C RID: 1036
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C56 RID: 7254 RVA: 0x0014B7F0 File Offset: 0x001499F0
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

	// Token: 0x06001C57 RID: 7255 RVA: 0x0014B850 File Offset: 0x00149A50
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

	// Token: 0x0400320C RID: 12812
	public bool customSenpai;

	// Token: 0x0400320D RID: 12813
	public string senpaiEyeColor = string.Empty;

	// Token: 0x0400320E RID: 12814
	public int senpaiEyeWear;

	// Token: 0x0400320F RID: 12815
	public int senpaiFacialHair;

	// Token: 0x04003210 RID: 12816
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003211 RID: 12817
	public int senpaiHairStyle;

	// Token: 0x04003212 RID: 12818
	public int senpaiSkinColor;
}
