using System;

// Token: 0x02000513 RID: 1299
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040049A5 RID: 18853
	public bool ActiveInHierarchy;

	// Token: 0x040049A6 RID: 18854
	public bool ActiveSelf;

	// Token: 0x040049A7 RID: 18855
	public bool IsStatic;

	// Token: 0x040049A8 RID: 18856
	public int Layer;

	// Token: 0x040049A9 RID: 18857
	public string Tag;

	// Token: 0x040049AA RID: 18858
	public string Name;

	// Token: 0x040049AB RID: 18859
	public string ObjectID;

	// Token: 0x040049AC RID: 18860
	public SerializedComponent[] SerializedComponents;
}
