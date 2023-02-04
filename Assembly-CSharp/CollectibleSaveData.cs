using System;

[Serializable]
public class CollectibleSaveData
{
	public IntHashSet basementTapeCollected = new IntHashSet();

	public IntHashSet basementTapeListened = new IntHashSet();

	public IntHashSet mangaCollected = new IntHashSet();

	public IntHashSet tapeCollected = new IntHashSet();

	public IntHashSet tapeListened = new IntHashSet();

	public static CollectibleSaveData ReadFromGlobals()
	{
		CollectibleSaveData collectibleSaveData = new CollectibleSaveData();
		int[] array = CollectibleGlobals.KeysOfBasementTapeCollected();
		foreach (int num in array)
		{
			if (CollectibleGlobals.GetBasementTapeCollected(num))
			{
				collectibleSaveData.basementTapeCollected.Add(num);
			}
		}
		array = CollectibleGlobals.KeysOfBasementTapeListened();
		foreach (int num2 in array)
		{
			if (CollectibleGlobals.GetBasementTapeListened(num2))
			{
				collectibleSaveData.basementTapeListened.Add(num2);
			}
		}
		array = CollectibleGlobals.KeysOfMangaCollected();
		foreach (int num3 in array)
		{
			if (CollectibleGlobals.GetMangaCollected(num3))
			{
				collectibleSaveData.mangaCollected.Add(num3);
			}
		}
		array = CollectibleGlobals.KeysOfTapeCollected();
		foreach (int num4 in array)
		{
			if (CollectibleGlobals.GetTapeCollected(num4))
			{
				collectibleSaveData.tapeCollected.Add(num4);
			}
		}
		array = CollectibleGlobals.KeysOfTapeListened();
		foreach (int num5 in array)
		{
			if (CollectibleGlobals.GetTapeListened(num5))
			{
				collectibleSaveData.tapeListened.Add(num5);
			}
		}
		return collectibleSaveData;
	}

	public static void WriteToGlobals(CollectibleSaveData data)
	{
		foreach (int item in data.basementTapeCollected)
		{
			CollectibleGlobals.SetBasementTapeCollected(item, value: true);
		}
		foreach (int item2 in data.basementTapeListened)
		{
			CollectibleGlobals.SetBasementTapeListened(item2, value: true);
		}
		foreach (int item3 in data.mangaCollected)
		{
			CollectibleGlobals.SetMangaCollected(item3, value: true);
		}
		foreach (int item4 in data.tapeCollected)
		{
			CollectibleGlobals.SetTapeCollected(item4, value: true);
		}
		foreach (int item5 in data.tapeListened)
		{
			CollectibleGlobals.SetTapeListened(item5, value: true);
		}
	}
}
