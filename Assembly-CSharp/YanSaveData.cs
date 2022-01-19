using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048BC RID: 18620
	public string LoadedLevelName;

	// Token: 0x040048BD RID: 18621
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048BE RID: 18622
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048BF RID: 18623
	public ValueDict SerializedPlayerPrefs;
}
