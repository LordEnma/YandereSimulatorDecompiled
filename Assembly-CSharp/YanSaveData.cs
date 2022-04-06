using System;

// Token: 0x02000512 RID: 1298
[Serializable]
public struct YanSaveData
{
	// Token: 0x0400499B RID: 18843
	public string LoadedLevelName;

	// Token: 0x0400499C RID: 18844
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x0400499D RID: 18845
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x0400499E RID: 18846
	public ValueDict SerializedPlayerPrefs;
}
