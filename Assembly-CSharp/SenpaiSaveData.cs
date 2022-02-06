using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C15 RID: 7189 RVA: 0x00146D70 File Offset: 0x00144F70
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

	// Token: 0x06001C16 RID: 7190 RVA: 0x00146DD0 File Offset: 0x00144FD0
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

	// Token: 0x04003159 RID: 12633
	public bool customSenpai;

	// Token: 0x0400315A RID: 12634
	public string senpaiEyeColor = string.Empty;

	// Token: 0x0400315B RID: 12635
	public int senpaiEyeWear;

	// Token: 0x0400315C RID: 12636
	public int senpaiFacialHair;

	// Token: 0x0400315D RID: 12637
	public string senpaiHairColor = string.Empty;

	// Token: 0x0400315E RID: 12638
	public int senpaiHairStyle;

	// Token: 0x0400315F RID: 12639
	public int senpaiSkinColor;
}
