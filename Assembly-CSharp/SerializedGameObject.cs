using System;

// Token: 0x02000516 RID: 1302
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x04004A01 RID: 18945
	public bool ActiveInHierarchy;

	// Token: 0x04004A02 RID: 18946
	public bool ActiveSelf;

	// Token: 0x04004A03 RID: 18947
	public bool IsStatic;

	// Token: 0x04004A04 RID: 18948
	public int Layer;

	// Token: 0x04004A05 RID: 18949
	public string Tag;

	// Token: 0x04004A06 RID: 18950
	public string Name;

	// Token: 0x04004A07 RID: 18951
	public string ObjectID;

	// Token: 0x04004A08 RID: 18952
	public SerializedComponent[] SerializedComponents;
}
