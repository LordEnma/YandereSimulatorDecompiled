using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class CollectibleSaveData
{
	// Token: 0x06001BE6 RID: 7142 RVA: 0x00143AAC File Offset: 0x00141CAC
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

	// Token: 0x06001BE7 RID: 7143 RVA: 0x00143BB0 File Offset: 0x00141DB0
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

	// Token: 0x040030EF RID: 12527
	public IntHashSet basementTapeCollected = new IntHashSet();

	// Token: 0x040030F0 RID: 12528
	public IntHashSet basementTapeListened = new IntHashSet();

	// Token: 0x040030F1 RID: 12529
	public IntHashSet mangaCollected = new IntHashSet();

	// Token: 0x040030F2 RID: 12530
	public IntHashSet tapeCollected = new IntHashSet();

	// Token: 0x040030F3 RID: 12531
	public IntHashSet tapeListened = new IntHashSet();
}
