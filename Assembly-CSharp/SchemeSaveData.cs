using System;
using System.Collections.Generic;

[Serializable]
public class SchemeSaveData
{
	public int currentScheme;

	public bool darkSecret;

	public IntAndIntDictionary schemePreviousStage = new IntAndIntDictionary();

	public IntAndIntDictionary schemeStage = new IntAndIntDictionary();

	public IntHashSet schemeStatus = new IntHashSet();

	public IntHashSet schemeUnlocked = new IntHashSet();

	public IntHashSet servicePurchased = new IntHashSet();

	public static SchemeSaveData ReadFromGlobals()
	{
		SchemeSaveData schemeSaveData = new SchemeSaveData();
		schemeSaveData.currentScheme = SchemeGlobals.CurrentScheme;
		schemeSaveData.darkSecret = SchemeGlobals.EmbarassingSecret;
		int[] array = SchemeGlobals.KeysOfSchemePreviousStage();
		foreach (int num in array)
		{
			schemeSaveData.schemePreviousStage.Add(num, SchemeGlobals.GetSchemePreviousStage(num));
		}
		array = SchemeGlobals.KeysOfSchemeStage();
		foreach (int num2 in array)
		{
			schemeSaveData.schemeStage.Add(num2, SchemeGlobals.GetSchemeStage(num2));
		}
		array = SchemeGlobals.KeysOfSchemeStatus();
		foreach (int num3 in array)
		{
			if (SchemeGlobals.GetSchemeStatus(num3))
			{
				schemeSaveData.schemeStatus.Add(num3);
			}
		}
		array = SchemeGlobals.KeysOfSchemeUnlocked();
		foreach (int num4 in array)
		{
			if (SchemeGlobals.GetSchemeUnlocked(num4))
			{
				schemeSaveData.schemeUnlocked.Add(num4);
			}
		}
		array = SchemeGlobals.KeysOfServicePurchased();
		foreach (int num5 in array)
		{
			if (SchemeGlobals.GetServicePurchased(num5))
			{
				schemeSaveData.servicePurchased.Add(num5);
			}
		}
		return schemeSaveData;
	}

	public static void WriteToGlobals(SchemeSaveData data)
	{
		SchemeGlobals.CurrentScheme = data.currentScheme;
		SchemeGlobals.EmbarassingSecret = data.darkSecret;
		foreach (KeyValuePair<int, int> item in data.schemePreviousStage)
		{
			SchemeGlobals.SetSchemePreviousStage(item.Key, item.Value);
		}
		foreach (KeyValuePair<int, int> item2 in data.schemeStage)
		{
			SchemeGlobals.SetSchemeStage(item2.Key, item2.Value);
		}
		foreach (int item3 in data.schemeStatus)
		{
			SchemeGlobals.SetSchemeStatus(item3, true);
		}
		foreach (int item4 in data.schemeUnlocked)
		{
			SchemeGlobals.SetSchemeUnlocked(item4, true);
		}
		foreach (int item5 in data.servicePurchased)
		{
			SchemeGlobals.SetServicePurchased(item5, true);
		}
	}
}
