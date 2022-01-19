using System;
using System.Collections.Generic;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001BF1 RID: 7153 RVA: 0x001455C8 File Offset: 0x001437C8
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

	// Token: 0x06001BF2 RID: 7154 RVA: 0x001456E4 File Offset: 0x001438E4
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

	// Token: 0x040030FD RID: 12541
	public float affection;

	// Token: 0x040030FE RID: 12542
	public float affectionLevel;

	// Token: 0x040030FF RID: 12543
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x04003100 RID: 12544
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x04003101 RID: 12545
	public int suitorProgress;

	// Token: 0x04003102 RID: 12546
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x04003103 RID: 12547
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x04003104 RID: 12548
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
