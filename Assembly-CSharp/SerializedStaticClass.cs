using System;

// Token: 0x02000515 RID: 1301
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040049B1 RID: 18865
	public string TypePath;

	// Token: 0x040049B2 RID: 18866
	public ValueDict PropertyValues;

	// Token: 0x040049B3 RID: 18867
	public ValueDict FieldValues;

	// Token: 0x040049B4 RID: 18868
	public ReferenceDict PropertyReferences;

	// Token: 0x040049B5 RID: 18869
	public ReferenceDict FieldReferences;

	// Token: 0x040049B6 RID: 18870
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049B7 RID: 18871
	public ReferenceArrayDict FieldReferenceArrays;
}
