using System;

// Token: 0x02000506 RID: 1286
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048C3 RID: 18627
	public bool ActiveInHierarchy;

	// Token: 0x040048C4 RID: 18628
	public bool ActiveSelf;

	// Token: 0x040048C5 RID: 18629
	public bool IsStatic;

	// Token: 0x040048C6 RID: 18630
	public int Layer;

	// Token: 0x040048C7 RID: 18631
	public string Tag;

	// Token: 0x040048C8 RID: 18632
	public string Name;

	// Token: 0x040048C9 RID: 18633
	public string ObjectID;

	// Token: 0x040048CA RID: 18634
	public SerializedComponent[] SerializedComponents;
}
