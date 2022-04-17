using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040049BB RID: 18875
	public bool ActiveInHierarchy;

	// Token: 0x040049BC RID: 18876
	public bool ActiveSelf;

	// Token: 0x040049BD RID: 18877
	public bool IsStatic;

	// Token: 0x040049BE RID: 18878
	public int Layer;

	// Token: 0x040049BF RID: 18879
	public string Tag;

	// Token: 0x040049C0 RID: 18880
	public string Name;

	// Token: 0x040049C1 RID: 18881
	public string ObjectID;

	// Token: 0x040049C2 RID: 18882
	public SerializedComponent[] SerializedComponents;
}
