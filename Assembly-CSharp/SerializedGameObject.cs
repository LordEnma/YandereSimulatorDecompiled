using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040049A9 RID: 18857
	public bool ActiveInHierarchy;

	// Token: 0x040049AA RID: 18858
	public bool ActiveSelf;

	// Token: 0x040049AB RID: 18859
	public bool IsStatic;

	// Token: 0x040049AC RID: 18860
	public int Layer;

	// Token: 0x040049AD RID: 18861
	public string Tag;

	// Token: 0x040049AE RID: 18862
	public string Name;

	// Token: 0x040049AF RID: 18863
	public string ObjectID;

	// Token: 0x040049B0 RID: 18864
	public SerializedComponent[] SerializedComponents;
}
