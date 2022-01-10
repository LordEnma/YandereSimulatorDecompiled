using System;
using System.Collections.Generic;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class DatingSaveData
{
	// Token: 0x06001BEF RID: 7151 RVA: 0x00143EC0 File Offset: 0x001420C0
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

	// Token: 0x06001BF0 RID: 7152 RVA: 0x00143FDC File Offset: 0x001421DC
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

	// Token: 0x040030F8 RID: 12536
	public float affection;

	// Token: 0x040030F9 RID: 12537
	public float affectionLevel;

	// Token: 0x040030FA RID: 12538
	public IntHashSet complimentGiven = new IntHashSet();

	// Token: 0x040030FB RID: 12539
	public IntHashSet suitorCheck = new IntHashSet();

	// Token: 0x040030FC RID: 12540
	public int suitorProgress;

	// Token: 0x040030FD RID: 12541
	public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

	// Token: 0x040030FE RID: 12542
	public IntHashSet topicDiscussed = new IntHashSet();

	// Token: 0x040030FF RID: 12543
	public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}
