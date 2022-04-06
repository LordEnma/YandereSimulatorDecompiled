using System;

// Token: 0x0200040A RID: 1034
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C44 RID: 7236 RVA: 0x00149C68 File Offset: 0x00147E68
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

	// Token: 0x06001C45 RID: 7237 RVA: 0x00149CC8 File Offset: 0x00147EC8
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

	// Token: 0x040031D5 RID: 12757
	public bool customSenpai;

	// Token: 0x040031D6 RID: 12758
	public string senpaiEyeColor = string.Empty;

	// Token: 0x040031D7 RID: 12759
	public int senpaiEyeWear;

	// Token: 0x040031D8 RID: 12760
	public int senpaiFacialHair;

	// Token: 0x040031D9 RID: 12761
	public string senpaiHairColor = string.Empty;

	// Token: 0x040031DA RID: 12762
	public int senpaiHairStyle;

	// Token: 0x040031DB RID: 12763
	public int senpaiSkinColor;
}
