using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040049AD RID: 18861
	public string TypePath;

	// Token: 0x040049AE RID: 18862
	public ValueDict PropertyValues;

	// Token: 0x040049AF RID: 18863
	public ValueDict FieldValues;

	// Token: 0x040049B0 RID: 18864
	public ReferenceDict PropertyReferences;

	// Token: 0x040049B1 RID: 18865
	public ReferenceDict FieldReferences;

	// Token: 0x040049B2 RID: 18866
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049B3 RID: 18867
	public ReferenceArrayDict FieldReferenceArrays;
}
