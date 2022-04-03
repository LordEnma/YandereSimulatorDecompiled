using System;
using System.Collections.Generic;

// Token: 0x0200040B RID: 1035
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C44 RID: 7236 RVA: 0x0014A500 File Offset: 0x00148700
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

	// Token: 0x06001C45 RID: 7237 RVA: 0x0014A5D0 File Offset: 0x001487D0
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

	// Token: 0x040031F7 RID: 12791
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x040031F8 RID: 12792
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x040031F9 RID: 12793
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x040031FA RID: 12794
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
