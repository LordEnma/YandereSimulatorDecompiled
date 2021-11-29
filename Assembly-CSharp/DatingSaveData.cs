using System;
using System.Collections.Generic;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001BDE RID: 7134 RVA: 0x00142E90 File Offset: 0x00141090
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

	// Token: 0x06001BDF RID: 7135 RVA: 0x00142FAC File Offset: 0x001411AC
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

	// Token: 0x040030C1 RID: 12481
	public float affection;

	// Token: 0x040030C2 RID: 12482
	public float affectionLevel;

	// Token: 0x040030C3 RID: 12483
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x040030C4 RID: 12484
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x040030C5 RID: 12485
	public int suitorProgress;

	// Token: 0x040030C6 RID: 12486
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x040030C7 RID: 12487
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x040030C8 RID: 12488
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
