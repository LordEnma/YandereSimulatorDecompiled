using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048E9 RID: 18665
	public string LoadedLevelName;

	// Token: 0x040048EA RID: 18666
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048EB RID: 18667
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048EC RID: 18668
	public ValueDict SerializedPlayerPrefs;
}
