using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x00144818 File Offset: 0x00142A18
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

	// Token: 0x06001C08 RID: 7176 RVA: 0x00144878 File Offset: 0x00142A78
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

	// Token: 0x0400313D RID: 12605
	public bool customSenpai;

	// Token: 0x0400313E RID: 12606
	public string senpaiEyeColor = string.Empty;

	// Token: 0x0400313F RID: 12607
	public int senpaiEyeWear;

	// Token: 0x04003140 RID: 12608
	public int senpaiFacialHair;

	// Token: 0x04003141 RID: 12609
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003142 RID: 12610
	public int senpaiHairStyle;

	// Token: 0x04003143 RID: 12611
	public int senpaiSkinColor;
}
