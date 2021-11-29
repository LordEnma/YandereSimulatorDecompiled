using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001BFF RID: 7167 RVA: 0x00143F58 File Offset: 0x00142158
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

	// Token: 0x06001C00 RID: 7168 RVA: 0x00143FB8 File Offset: 0x001421B8
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

	// Token: 0x04003113 RID: 12563
	public bool customSenpai;

	// Token: 0x04003114 RID: 12564
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003115 RID: 12565
	public int senpaiEyeWear;

	// Token: 0x04003116 RID: 12566
	public int senpaiFacialHair;

	// Token: 0x04003117 RID: 12567
	public string senpaiHairColor = string.Empty;

	// Token: 0x04003118 RID: 12568
	public int senpaiHairStyle;

	// Token: 0x04003119 RID: 12569
	public int senpaiSkinColor;
}
