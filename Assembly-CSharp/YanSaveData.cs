using System;

// Token: 0x02000504 RID: 1284
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048B5 RID: 18613
	public string LoadedLevelName;

	// Token: 0x040048B6 RID: 18614
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048B7 RID: 18615
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048B8 RID: 18616
	public ValueDict SerializedPlayerPrefs;
}
