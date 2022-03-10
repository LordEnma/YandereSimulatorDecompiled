using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct YanSaveData
{
	// Token: 0x04004906 RID: 18694
	public string LoadedLevelName;

	// Token: 0x04004907 RID: 18695
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x04004908 RID: 18696
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x04004909 RID: 18697
	public ValueDict SerializedPlayerPrefs;
}
