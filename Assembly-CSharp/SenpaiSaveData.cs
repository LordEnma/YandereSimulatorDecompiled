using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C13 RID: 7187 RVA: 0x00146BD8 File Offset: 0x00144DD8
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

	// Token: 0x06001C14 RID: 7188 RVA: 0x00146C38 File Offset: 0x00144E38
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

	// Token: 0x04003156 RID: 12630
	public bool customSenpai;

	// Token: 0x04003157 RID: 12631
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003158 RID: 12632
	public int senpaiEyeWear;

	// Token: 0x04003159 RID: 12633
	public int senpaiFacialHair;

	// Token: 0x0400315A RID: 12634
	public string senpaiHairColor = string.Empty;

	// Token: 0x0400315B RID: 12635
	public int senpaiHairStyle;

	// Token: 0x0400315C RID: 12636
	public int senpaiSkinColor;
}
