using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class CollectibleSaveData
{
	// Token: 0x06001C25 RID: 7205 RVA: 0x001493D8 File Offset: 0x001475D8
	public static CollectibleSaveData ReadFromGlobals()
	{
		CollectibleSaveData collectibleSaveData = new CollectibleSaveData();
		foreach (int num in CollectibleGlobals.KeysOfBasementTapeCollected())
		{
			if (CollectibleGlobals.GetBasementTapeCollected(num))
			{
				collectibleSaveData.basementTapeCollected.Add(num);
			}
		}
		foreach (int num2 in CollectibleGlobals.KeysOfBasementTapeListened())
		{
			if (CollectibleGlobals.GetBasementTapeListened(num2))
			{
				collectibleSaveData.basementTapeListened.Add(num2);
			}
		}
		foreach (int num3 in CollectibleGlobals.KeysOfMangaCollected())
		{
			if (CollectibleGlobals.GetMangaCollected(num3))
			{
				collectibleSaveData.mangaCollected.Add(num3);
			}
		}
		foreach (int num4 in CollectibleGlobals.KeysOfTapeCollected())
		{
			if (CollectibleGlobals.GetTapeCollected(num4))
			{
				collectibleSaveData.tapeCollected.Add(num4);
			}
		}
		foreach (int num5 in CollectibleGlobals.KeysOfTapeListened())
		{
			if (CollectibleGlobals.GetTapeListened(num5))
			{
				collectibleSaveData.tapeListened.Add(num5);
			}
		}
		return collectibleSaveData;
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x001494DC File Offset: 0x001476DC
	public static void WriteToGlobals(CollectibleSaveData data)
	{
		foreach (int tapeID in data.basementTapeCollected)
		{
			CollectibleGlobals.SetBasementTapeCollected(tapeID, true);
		}
		foreach (int tapeID2 in data.basementTapeListened)
		{
			CollectibleGlobals.SetBasementTapeListened(tapeID2, true);
		}
		foreach (int mangaID in data.mangaCollected)
		{
			CollectibleGlobals.SetMangaCollected(mangaID, true);
		}
		foreach (int tapeID3 in data.tapeCollected)
		{
			CollectibleGlobals.SetTapeCollected(tapeID3, true);
		}
		foreach (int tapeID4 in data.tapeListened)
		{
			CollectibleGlobals.SetTapeListened(tapeID4, true);
		}
	}

	// Token: 0x04003194 RID: 12692
	public IntHashSet basementTapeCollected = new IntHashSet();

	// Token: 0x04003195 RID: 12693
	public IntHashSet basementTapeListened = new IntHashSet();

	// Token: 0x04003196 RID: 12694
	public IntHashSet mangaCollected = new IntHashSet();

	// Token: 0x04003197 RID: 12695
	public IntHashSet tapeCollected = new IntHashSet();

	// Token: 0x04003198 RID: 12696
	public IntHashSet tapeListened = new IntHashSet();
}
