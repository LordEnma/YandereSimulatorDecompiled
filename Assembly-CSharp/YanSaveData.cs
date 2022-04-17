using System;

// Token: 0x02000512 RID: 1298
[Serializable]
public struct YanSaveData
{
	// Token: 0x040049AD RID: 18861
	public string LoadedLevelName;

	// Token: 0x040049AE RID: 18862
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040049AF RID: 18863
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040049B0 RID: 18864
	public ValueDict SerializedPlayerPrefs;
}
