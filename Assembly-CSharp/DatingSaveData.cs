using System;
using System.Collections.Generic;

// Token: 0x02000401 RID: 1025
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001C34 RID: 7220 RVA: 0x0014A46C File Offset: 0x0014866C
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

	// Token: 0x06001C35 RID: 7221 RVA: 0x0014A588 File Offset: 0x00148788
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

	// Token: 0x040031B2 RID: 12722
	public float affection;

	// Token: 0x040031B3 RID: 12723
	public float affectionLevel;

	// Token: 0x040031B4 RID: 12724
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x040031B5 RID: 12725
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x040031B6 RID: 12726
	public int suitorProgress;

	// Token: 0x040031B7 RID: 12727
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x040031B8 RID: 12728
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x040031B9 RID: 12729
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
