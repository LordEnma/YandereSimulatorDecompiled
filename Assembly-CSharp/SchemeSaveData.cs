using System;
using System.Collections.Generic;

// Token: 0x020003FE RID: 1022
[Serializable]
public class SchemeSaveData
{
	// Token: 0x06001C01 RID: 7169 RVA: 0x00144398 File Offset: 0x00142598
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

	// Token: 0x06001C02 RID: 7170 RVA: 0x001444AC File Offset: 0x001426AC
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

	// Token: 0x0400312E RID: 12590
	public int currentScheme;

	// Token: 0x0400312F RID: 12591
	public bool darkSecret;

	// Token: 0x04003130 RID: 12592
	public IntAndIntDictionary schemePreviousStage = new IntAndIntDictionary();

	// Token: 0x04003131 RID: 12593
	public IntAndIntDictionary schemeStage = new IntAndIntDictionary();

	// Token: 0x04003132 RID: 12594
	public IntHashSet schemeStatus = new IntHashSet();

	// Token: 0x04003133 RID: 12595
	public IntHashSet schemeUnlocked = new IntHashSet();

	// Token: 0x04003134 RID: 12596
	public IntHashSet servicePurchased = new IntHashSet();
}
