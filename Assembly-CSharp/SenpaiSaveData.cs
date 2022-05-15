using System;

// Token: 0x0200040C RID: 1036
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014B534 File Offset: 0x00149734
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

	// Token: 0x06001C56 RID: 7254 RVA: 0x0014B594 File Offset: 0x00149794
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

	// Token: 0x04003204 RID: 12804
	public bool customSenpai;

	// Token: 0x04003205 RID: 12805
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003206 RID: 12806
	public int senpaiEyeWear;

	// Token: 0x04003207 RID: 12807
	public int senpaiFacialHair;

	// Token: 0x04003208 RID: 12808
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003209 RID: 12809
	public int senpaiHairStyle;

	// Token: 0x0400320A RID: 12810
	public int senpaiSkinColor;
}
