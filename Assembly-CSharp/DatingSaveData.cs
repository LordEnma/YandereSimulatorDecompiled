using System;
using System.Collections.Generic;

// Token: 0x020003FA RID: 1018
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x00146F5C File Offset: 0x0014515C
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

	// Token: 0x06001C07 RID: 7175 RVA: 0x00147078 File Offset: 0x00145278
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

	// Token: 0x04003133 RID: 12595
	public float affection;

	// Token: 0x04003134 RID: 12596
	public float affectionLevel;

	// Token: 0x04003135 RID: 12597
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x04003136 RID: 12598
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x04003137 RID: 12599
	public int suitorProgress;

	// Token: 0x04003138 RID: 12600
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x04003139 RID: 12601
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x0400313A RID: 12602
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
