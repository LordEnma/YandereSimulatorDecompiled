using System;
using System.Collections.Generic;

// Token: 0x02000401 RID: 1025
[Serializable]
public class SchemeSaveData
{
	// Token: 0x06001C0C RID: 7180 RVA: 0x00146210 File Offset: 0x00144410
	public static SchemeSaveData ReadFromGlobals()
	{
		SchemeSaveData schemeSaveData = new SchemeSaveData();
		schemeSaveData.currentScheme = SchemeGlobals.CurrentScheme;
		schemeSaveData.darkSecret = SchemeGlobals.EmbarassingSecret;
		foreach (int num in SchemeGlobals.KeysOfSchemePreviousStage())
		{
			schemeSaveData.schemePreviousStage.Add(num, SchemeGlobals.GetSchemePreviousStage(num));
		}
		foreach (int num2 in SchemeGlobals.KeysOfSchemeStage())
		{
			schemeSaveData.schemeStage.Add(num2, SchemeGlobals.GetSchemeStage(num2));
		}
		foreach (int num3 in SchemeGlobals.KeysOfSchemeStatus())
		{
			if (SchemeGlobals.GetSchemeStatus(num3))
			{
				schemeSaveData.schemeStatus.Add(num3);
			}
		}
		foreach (int num4 in SchemeGlobals.KeysOfSchemeUnlocked())
		{
			if (SchemeGlobals.GetSchemeUnlocked(num4))
			{
				schemeSaveData.schemeUnlocked.Add(num4);
			}
		}
		foreach (int num5 in SchemeGlobals.KeysOfServicePurchased())
		{
			if (SchemeGlobals.GetServicePurchased(num5))
			{
				schemeSaveData.servicePurchased.Add(num5);
			}
		}
		return schemeSaveData;
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x00146324 File Offset: 0x00144524
	public static void WriteToGlobals(SchemeSaveData data)
	{
		SchemeGlobals.CurrentScheme = data.currentScheme;
		SchemeGlobals.EmbarassingSecret = data.darkSecret;
		foreach (KeyValuePair<int, int> keyValuePair in data.schemePreviousStage)
		{
			SchemeGlobals.SetSchemePreviousStage(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in data.schemeStage)
		{
			SchemeGlobals.SetSchemeStage(keyValuePair2.Key, keyValuePair2.Value);
		}
		foreach (int schemeID in data.schemeStatus)
		{
			SchemeGlobals.SetSchemeStatus(schemeID, true);
		}
		foreach (int schemeID2 in data.schemeUnlocked)
		{
			SchemeGlobals.SetSchemeUnlocked(schemeID2, true);
		}
		foreach (int serviceID in data.servicePurchased)
		{
			SchemeGlobals.SetServicePurchased(serviceID, true);
		}
	}

	// Token: 0x04003140 RID: 12608
	public int currentScheme;

	// Token: 0x04003141 RID: 12609
	public bool darkSecret;

	// Token: 0x04003142 RID: 12610
	public IntAndIntDictionary schemePreviousStage = new IntAndIntDictionary();

	// Token: 0x04003143 RID: 12611
	public IntAndIntDictionary schemeStage = new IntAndIntDictionary();

	// Token: 0x04003144 RID: 12612
	public IntHashSet schemeStatus = new IntHashSet();

	// Token: 0x04003145 RID: 12613
	public IntHashSet schemeUnlocked = new IntHashSet();

	// Token: 0x04003146 RID: 12614
	public IntHashSet servicePurchased = new IntHashSet();
}
