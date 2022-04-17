using System;
using System.Collections.Generic;

// Token: 0x020003FF RID: 1023
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001C27 RID: 7207 RVA: 0x00148FB0 File Offset: 0x001471B0
	public static DatingSaveData ReadFromGlobals()
	{
		DatingSaveData datingSaveData = new DatingSaveData();
		datingSaveData.affection = DatingGlobals.Affection;
		datingSaveData.affectionLevel = DatingGlobals.AffectionLevel;
		foreach (int num in DatingGlobals.KeysOfComplimentGiven())
		{
			if (DatingGlobals.GetComplimentGiven(num))
			{
				datingSaveData.complimentGiven.Add(num);
			}
		}
		foreach (int num2 in DatingGlobals.KeysOfSuitorCheck())
		{
			if (DatingGlobals.GetSuitorCheck(num2))
			{
				datingSaveData.suitorCheck.Add(num2);
			}
		}
		datingSaveData.suitorProgress = DatingGlobals.SuitorProgress;
		foreach (int num3 in DatingGlobals.KeysOfSuitorTrait())
		{
			datingSaveData.suitorTrait.Add(num3, DatingGlobals.GetSuitorTrait(num3));
		}
		foreach (int num4 in DatingGlobals.KeysOfTopicDiscussed())
		{
			if (DatingGlobals.GetTopicDiscussed(num4))
			{
				datingSaveData.topicDiscussed.Add(num4);
			}
		}
		foreach (int num5 in DatingGlobals.KeysOfTraitDemonstrated())
		{
			datingSaveData.traitDemonstrated.Add(num5, DatingGlobals.GetTraitDemonstrated(num5));
		}
		return datingSaveData;
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x001490CC File Offset: 0x001472CC
	public static void WriteToGlobals(DatingSaveData data)
	{
		DatingGlobals.Affection = data.affection;
		DatingGlobals.AffectionLevel = data.affectionLevel;
		foreach (int complimentID in data.complimentGiven)
		{
			DatingGlobals.SetComplimentGiven(complimentID, true);
		}
		foreach (int checkID in data.suitorCheck)
		{
			DatingGlobals.SetSuitorCheck(checkID, true);
		}
		DatingGlobals.SuitorProgress = data.suitorProgress;
		foreach (KeyValuePair<int, int> keyValuePair in data.suitorTrait)
		{
			DatingGlobals.SetSuitorTrait(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (int topicID in data.topicDiscussed)
		{
			DatingGlobals.SetTopicDiscussed(topicID, true);
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in data.traitDemonstrated)
		{
			DatingGlobals.SetTraitDemonstrated(keyValuePair2.Key, keyValuePair2.Value);
		}
	}

	// Token: 0x0400318E RID: 12686
	public float affection;

	// Token: 0x0400318F RID: 12687
	public float affectionLevel;

	// Token: 0x04003190 RID: 12688
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x04003191 RID: 12689
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x04003192 RID: 12690
	public int suitorProgress;

	// Token: 0x04003193 RID: 12691
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x04003194 RID: 12692
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x04003195 RID: 12693
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
