using System;
using System.Collections.Generic;

// Token: 0x02000400 RID: 1024
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001C2E RID: 7214 RVA: 0x001497EC File Offset: 0x001479EC
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

	// Token: 0x06001C2F RID: 7215 RVA: 0x00149908 File Offset: 0x00147B08
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

	// Token: 0x0400319D RID: 12701
	public float affection;

	// Token: 0x0400319E RID: 12702
	public float affectionLevel;

	// Token: 0x0400319F RID: 12703
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x040031A0 RID: 12704
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x040031A1 RID: 12705
	public int suitorProgress;

	// Token: 0x040031A2 RID: 12706
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x040031A3 RID: 12707
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x040031A4 RID: 12708
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
