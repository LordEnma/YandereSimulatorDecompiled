using System;

// Token: 0x020000D5 RID: 213
[Serializable]
public class ArrayLayout
{
	// Token: 0x04000A90 RID: 2704
	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

	// Token: 0x0200064B RID: 1611
	[Serializable]
	public struct rowData
	{
		// Token: 0x04004ED1 RID: 20177
		public bool[] row;
	}
}
