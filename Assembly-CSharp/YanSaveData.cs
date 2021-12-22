using System;

// Token: 0x02000502 RID: 1282
[Serializable]
public struct YanSaveData
{
	// Token: 0x04004898 RID: 18584
	public string LoadedLevelName;

	// Token: 0x04004899 RID: 18585
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x0400489A RID: 18586
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x0400489B RID: 18587
	public ValueDict SerializedPlayerPrefs;
}
