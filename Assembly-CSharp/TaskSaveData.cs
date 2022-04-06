using System;
using System.Collections.Generic;

// Token: 0x0200040C RID: 1036
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C4A RID: 7242 RVA: 0x0014A7E4 File Offset: 0x001489E4
	public static TaskSaveData ReadFromGlobals()
	{
		TaskSaveData taskSaveData = new TaskSaveData();
		foreach (int num in TaskGlobals.KeysOfGuitarPhoto())
		{
			if (TaskGlobals.GetGuitarPhoto(num))
			{
				taskSaveData.guitarPhoto.Add(num);
			}
		}
		foreach (int num2 in TaskGlobals.KeysOfKittenPhoto())
		{
			if (TaskGlobals.GetKittenPhoto(num2))
			{
				taskSaveData.kittenPhoto.Add(num2);
			}
		}
		foreach (int num3 in TaskGlobals.KeysOfHorudaPhoto())
		{
			if (TaskGlobals.GetHorudaPhoto(num3))
			{
				taskSaveData.horudaPhoto.Add(num3);
			}
		}
		foreach (int num4 in TaskGlobals.KeysOfTaskStatus())
		{
			taskSaveData.taskStatus.Add(num4, TaskGlobals.GetTaskStatus(num4));
		}
		return taskSaveData;
	}

	// Token: 0x06001C4B RID: 7243 RVA: 0x0014A8B4 File Offset: 0x00148AB4
	public static void WriteToGlobals(TaskSaveData data)
	{
		foreach (int photoID in data.kittenPhoto)
		{
			TaskGlobals.SetKittenPhoto(photoID, true);
		}
		foreach (int photoID2 in data.guitarPhoto)
		{
			TaskGlobals.SetGuitarPhoto(photoID2, true);
		}
		foreach (KeyValuePair<int, int> keyValuePair in data.taskStatus)
		{
			TaskGlobals.SetTaskStatus(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x040031FA RID: 12794
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x040031FB RID: 12795
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x040031FC RID: 12796
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x040031FD RID: 12797
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
