using System;
using System.Collections.Generic;

// Token: 0x020003FA RID: 1018
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001C04 RID: 7172 RVA: 0x00146A20 File Offset: 0x00144C20
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

	// Token: 0x06001C05 RID: 7173 RVA: 0x00146B3C File Offset: 0x00144D3C
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

	// Token: 0x0400311D RID: 12573
	public float affection;

	// Token: 0x0400311E RID: 12574
	public float affectionLevel;

	// Token: 0x0400311F RID: 12575
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x04003120 RID: 12576
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x04003121 RID: 12577
	public int suitorProgress;

	// Token: 0x04003122 RID: 12578
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x04003123 RID: 12579
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x04003124 RID: 12580
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
