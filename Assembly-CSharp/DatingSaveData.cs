using System;
using System.Collections.Generic;

// Token: 0x020003FE RID: 1022
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001C1D RID: 7197 RVA: 0x001488BC File Offset: 0x00146ABC
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

	// Token: 0x06001C1E RID: 7198 RVA: 0x001489D8 File Offset: 0x00146BD8
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

	// Token: 0x04003180 RID: 12672
	public float affection;

	// Token: 0x04003181 RID: 12673
	public float affectionLevel;

	// Token: 0x04003182 RID: 12674
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x04003183 RID: 12675
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x04003184 RID: 12676
	public int suitorProgress;

	// Token: 0x04003185 RID: 12677
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x04003186 RID: 12678
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x04003187 RID: 12679
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
