using System;

[Serializable]
public struct YanSaveData
{
	public string LoadedLevelName;

	public SerializedGameObject[] SerializedGameObjects;

	public SerializedStaticClass[] SerializedStaticClasses;

	public ValueDict SerializedPlayerPrefs;
}
