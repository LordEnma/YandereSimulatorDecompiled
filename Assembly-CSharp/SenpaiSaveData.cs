using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C09 RID: 7177 RVA: 0x00144C14 File Offset: 0x00142E14
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

	// Token: 0x06001C0A RID: 7178 RVA: 0x00144C74 File Offset: 0x00142E74
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

	// Token: 0x04003144 RID: 12612
	public bool customSenpai;

	// Token: 0x04003145 RID: 12613
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003146 RID: 12614
	public int senpaiEyeWear;

	// Token: 0x04003147 RID: 12615
	public int senpaiFacialHair;

	// Token: 0x04003148 RID: 12616
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003149 RID: 12617
	public int senpaiHairStyle;

	// Token: 0x0400314A RID: 12618
	public int senpaiSkinColor;
}
