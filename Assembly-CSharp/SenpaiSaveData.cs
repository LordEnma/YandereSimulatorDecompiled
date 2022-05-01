using System;

// Token: 0x0200040B RID: 1035
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x0014A8B4 File Offset: 0x00148AB4
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

	// Token: 0x06001C50 RID: 7248 RVA: 0x0014A914 File Offset: 0x00148B14
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

	// Token: 0x040031EF RID: 12783
	public bool customSenpai;

	// Token: 0x040031F0 RID: 12784
	public string senpaiEyeColor = string.Empty;

	// Token: 0x040031F1 RID: 12785
	public int senpaiEyeWear;

	// Token: 0x040031F2 RID: 12786
	public int senpaiFacialHair;

	// Token: 0x040031F3 RID: 12787
	public string senpaiHairColor = string.Empty;

	// Token: 0x040031F4 RID: 12788
	public int senpaiHairStyle;

	// Token: 0x040031F5 RID: 12789
	public int senpaiSkinColor;
}
