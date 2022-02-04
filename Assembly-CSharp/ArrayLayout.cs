using System;

// Token: 0x020000D5 RID: 213
[Serializable]
public class ArrayLayout
{
	// Token: 0x04000A86 RID: 2694
	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

	// Token: 0x02000648 RID: 1608
	[Serializable]
	public struct rowData
	{
		// Token: 0x04004E98 RID: 20120
		public bool[] row;
	}
}
