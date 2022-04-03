using System;

// Token: 0x02000409 RID: 1033
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C3E RID: 7230 RVA: 0x00149984 File Offset: 0x00147B84
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

	// Token: 0x06001C3F RID: 7231 RVA: 0x001499E4 File Offset: 0x00147BE4
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

	// Token: 0x040031D2 RID: 12754
	public bool customSenpai;

	// Token: 0x040031D3 RID: 12755
	public string senpaiEyeColor = string.Empty;

	// Token: 0x040031D4 RID: 12756
	public int senpaiEyeWear;

	// Token: 0x040031D5 RID: 12757
	public int senpaiFacialHair;

	// Token: 0x040031D6 RID: 12758
	public string senpaiHairColor = string.Empty;

	// Token: 0x040031D7 RID: 12759
	public int senpaiHairStyle;

	// Token: 0x040031D8 RID: 12760
	public int senpaiSkinColor;
}
