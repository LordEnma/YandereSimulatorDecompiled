using System;

// Token: 0x02000513 RID: 1299
[Serializable]
public struct YanSaveData
{
	// Token: 0x040049C3 RID: 18883
	public string LoadedLevelName;

	// Token: 0x040049C4 RID: 18884
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040049C5 RID: 18885
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040049C6 RID: 18886
	public ValueDict SerializedPlayerPrefs;
}
