using System;
using System.Collections.Generic;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001BE6 RID: 7142 RVA: 0x00143750 File Offset: 0x00141950
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

	// Token: 0x06001BE7 RID: 7143 RVA: 0x0014386C File Offset: 0x00141A6C
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

	// Token: 0x040030EB RID: 12523
	public float affection;

	// Token: 0x040030EC RID: 12524
	public float affectionLevel;

	// Token: 0x040030ED RID: 12525
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x040030EE RID: 12526
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x040030EF RID: 12527
	public int suitorProgress;

	// Token: 0x040030F0 RID: 12528
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x040030F1 RID: 12529
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x040030F2 RID: 12530
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
