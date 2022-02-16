using System;
using System.Collections.Generic;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001BFB RID: 7163 RVA: 0x00145FA8 File Offset: 0x001441A8
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

	// Token: 0x06001BFC RID: 7164 RVA: 0x001460C4 File Offset: 0x001442C4
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

	// Token: 0x0400310D RID: 12557
	public float affection;

	// Token: 0x0400310E RID: 12558
	public float affectionLevel;

	// Token: 0x0400310F RID: 12559
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x04003110 RID: 12560
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x04003111 RID: 12561
	public int suitorProgress;

	// Token: 0x04003112 RID: 12562
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x04003113 RID: 12563
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x04003114 RID: 12564
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
