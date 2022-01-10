using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x00144F88 File Offset: 0x00143188
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

	// Token: 0x06001C11 RID: 7185 RVA: 0x00144FE8 File Offset: 0x001431E8
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

	// Token: 0x0400314A RID: 12618
	public bool customSenpai;

	// Token: 0x0400314B RID: 12619
	public string senpaiEyeColor = string.Empty;

	// Token: 0x0400314C RID: 12620
	public int senpaiEyeWear;

	// Token: 0x0400314D RID: 12621
	public int senpaiFacialHair;

	// Token: 0x0400314E RID: 12622
	public string senpaiHairColor = string.Empty;

	// Token: 0x0400314F RID: 12623
	public int senpaiHairStyle;

	// Token: 0x04003150 RID: 12624
	public int senpaiSkinColor;
}
