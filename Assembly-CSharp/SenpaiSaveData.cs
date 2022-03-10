using System;

// Token: 0x02000405 RID: 1029
[Serializable]
public class SenpaiSaveData
{
	// Token: 0x06001C27 RID: 7207 RVA: 0x00148024 File Offset: 0x00146224
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

	// Token: 0x06001C28 RID: 7208 RVA: 0x00148084 File Offset: 0x00146284
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

	// Token: 0x04003185 RID: 12677
	public bool customSenpai;

	// Token: 0x04003186 RID: 12678
	public string senpaiEyeColor = string.Empty;

	// Token: 0x04003187 RID: 12679
	public int senpaiEyeWear;

	// Token: 0x04003188 RID: 12680
	public int senpaiFacialHair;

	// Token: 0x04003189 RID: 12681
	public string senpaiHairColor = string.Empty;

	// Token: 0x0400318A RID: 12682
	public int senpaiHairStyle;

	// Token: 0x0400318B RID: 12683
	public int senpaiSkinColor;
}
