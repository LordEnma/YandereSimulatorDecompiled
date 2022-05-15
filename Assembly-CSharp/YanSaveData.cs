using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public struct YanSaveData
{
	// Token: 0x040049EA RID: 18922
	public string LoadedLevelName;

	// Token: 0x040049EB RID: 18923
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040049EC RID: 18924
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040049ED RID: 18925
	public ValueDict SerializedPlayerPrefs;
}
