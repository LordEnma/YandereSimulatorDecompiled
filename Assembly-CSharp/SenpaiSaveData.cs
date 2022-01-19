using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C12 RID: 7186 RVA: 0x00146690 File Offset: 0x00144890
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

	// Token: 0x06001C13 RID: 7187 RVA: 0x001466F0 File Offset: 0x001448F0
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

	// Token: 0x0400314F RID: 12623
	public bool customSenpai;

	// Token: 0x04003150 RID: 12624
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003151 RID: 12625
	public int senpaiEyeWear;

	// Token: 0x04003152 RID: 12626
	public int senpaiFacialHair;

	// Token: 0x04003153 RID: 12627
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003154 RID: 12628
	public int senpaiHairStyle;

	// Token: 0x04003155 RID: 12629
	public int senpaiSkinColor;
}
