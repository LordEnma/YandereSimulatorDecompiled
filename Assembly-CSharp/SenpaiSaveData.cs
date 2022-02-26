using System;

// Token: 0x02000405 RID: 1029
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C25 RID: 7205 RVA: 0x00147AE8 File Offset: 0x00145CE8
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

	// Token: 0x06001C26 RID: 7206 RVA: 0x00147B48 File Offset: 0x00145D48
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

	// Token: 0x0400316F RID: 12655
	public bool customSenpai;

	// Token: 0x04003170 RID: 12656
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003171 RID: 12657
	public int senpaiEyeWear;

	// Token: 0x04003172 RID: 12658
	public int senpaiFacialHair;

	// Token: 0x04003173 RID: 12659
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003174 RID: 12660
	public int senpaiHairStyle;

	// Token: 0x04003175 RID: 12661
	public int senpaiSkinColor;
}
