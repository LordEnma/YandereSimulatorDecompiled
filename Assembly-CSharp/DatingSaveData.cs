using System;
using System.Collections.Generic;

[Serializable]
public class DatingSaveData
{
	public float affection;

	public float affectionLevel;

	public IntHashSet complimentGiven = new IntHashSet();

	public IntHashSet suitorCheck = new IntHashSet();

	public int suitorProgress;

	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	public IntHashSet topicDiscussed = new IntHashSet();

	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();

	public static DatingSaveData ReadFromGlobals()
	{
		DatingSaveData datingSaveData = new DatingSaveData();
		datingSaveData.affection = DatingGlobals.Affection;
		datingSaveData.affectionLevel = DatingGlobals.AffectionLevel;
		int[] array = DatingGlobals.KeysOfComplimentGiven();
		foreach (int num in array)
		{
			if (DatingGlobals.GetComplimentGiven(num))
			{
				datingSaveData.complimentGiven.Add(num);
			}
		}
		array = DatingGlobals.KeysOfSuitorCheck();
		foreach (int num2 in array)
		{
			if (DatingGlobals.GetSuitorCheck(num2))
			{
				datingSaveData.suitorCheck.Add(num2);
			}
		}
		datingSaveData.suitorProgress = DatingGlobals.SuitorProgress;
		array = DatingGlobals.KeysOfSuitorTrait();
		foreach (int num3 in array)
		{
			datingSaveData.suitorTrait.Add(num3, DatingGlobals.GetSuitorTrait(num3));
		}
		array = DatingGlobals.KeysOfTopicDiscussed();
		foreach (int num4 in array)
		{
			if (DatingGlobals.GetTopicDiscussed(num4))
			{
				datingSaveData.topicDiscussed.Add(num4);
			}
		}
		array = DatingGlobals.KeysOfTraitDemonstrated();
		foreach (int num5 in array)
		{
			datingSaveData.traitDemonstrated.Add(num5, DatingGlobals.GetTraitDemonstrated(num5));
		}
		return datingSaveData;
	}

	public static void WriteToGlobals(DatingSaveData data)
	{
		DatingGlobals.Affection = data.affection;
		DatingGlobals.AffectionLevel = data.affectionLevel;
		foreach (int item in data.complimentGiven)
		{
			DatingGlobals.SetComplimentGiven(item, true);
		}
		foreach (int item2 in data.suitorCheck)
		{
			DatingGlobals.SetSuitorCheck(item2, true);
		}
		DatingGlobals.SuitorProgress = data.suitorProgress;
		foreach (KeyValuePair<int, int> item3 in data.suitorTrait)
		{
			DatingGlobals.SetSuitorTrait(item3.Key, item3.Value);
		}
		foreach (int item4 in data.topicDiscussed)
		{
			DatingGlobals.SetTopicDiscussed(item4, true);
		}
		foreach (KeyValuePair<int, int> item5 in data.traitDemonstrated)
		{
			DatingGlobals.SetTraitDemonstrated(item5.Key, item5.Value);
		}
	}
}
