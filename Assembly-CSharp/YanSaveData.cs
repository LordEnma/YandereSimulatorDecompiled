using System;

// Token: 0x02000511 RID: 1297
[Serializable]
public struct YanSaveData
{
	// Token: 0x04004997 RID: 18839
	public string LoadedLevelName;

	// Token: 0x04004998 RID: 18840
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x04004999 RID: 18841
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x0400499A RID: 18842
	public ValueDict SerializedPlayerPrefs;
}
