using System;
using System.Collections.Generic;

[Serializable]
public class TaskSaveData
{
	public IntHashSet guitarPhoto = new IntHashSet();

	public IntHashSet kittenPhoto = new IntHashSet();

	public IntHashSet horudaPhoto = new IntHashSet();

	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();

	public static TaskSaveData ReadFromGlobals()
	{
		TaskSaveData taskSaveData = new TaskSaveData();
		int[] array = TaskGlobals.KeysOfGuitarPhoto();
		foreach (int num in array)
		{
			if (TaskGlobals.GetGuitarPhoto(num))
			{
				taskSaveData.guitarPhoto.Add(num);
			}
		}
		array = TaskGlobals.KeysOfKittenPhoto();
		foreach (int num2 in array)
		{
			if (TaskGlobals.GetKittenPhoto(num2))
			{
				taskSaveData.kittenPhoto.Add(num2);
			}
		}
		array = TaskGlobals.KeysOfHorudaPhoto();
		foreach (int num3 in array)
		{
			if (TaskGlobals.GetHorudaPhoto(num3))
			{
				taskSaveData.horudaPhoto.Add(num3);
			}
		}
		array = TaskGlobals.KeysOfTaskStatus();
		foreach (int num4 in array)
		{
			taskSaveData.taskStatus.Add(num4, TaskGlobals.GetTaskStatus(num4));
		}
		return taskSaveData;
	}

	public static void WriteToGlobals(TaskSaveData data)
	{
		foreach (int item in data.kittenPhoto)
		{
			TaskGlobals.SetKittenPhoto(item, value: true);
		}
		foreach (int item2 in data.guitarPhoto)
		{
			TaskGlobals.SetGuitarPhoto(item2, value: true);
		}
		foreach (KeyValuePair<int, int> item3 in data.taskStatus)
		{
			TaskGlobals.SetTaskStatus(item3.Key, item3.Value);
		}
	}
}
