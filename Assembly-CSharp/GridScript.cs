using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GridScript : MonoBehaviour
{
	// Token: 0x06001828 RID: 6184 RVA: 0x000E4C94 File Offset: 0x000E2E94
	private void Start()
	{
		while (this.ID < this.Rows * this.Columns)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Tile, new Vector3((float)this.Row, 0f, (float)this.Column), Quaternion.identity).transform.parent = base.transform;
			this.Row++;
			if (this.Row > this.Rows)
			{
				this.Row = 1;
				this.Column++;
			}
			this.ID++;
		}
		base.transform.localScale = new Vector3(4f, 4f, 4f);
		base.transform.position = new Vector3(-52f, 0f, -52f);
	}

	// Token: 0x0400230A RID: 8970
	public GameObject Tile;

	// Token: 0x0400230B RID: 8971
	public int Row;

	// Token: 0x0400230C RID: 8972
	public int Column;

	// Token: 0x0400230D RID: 8973
	public int Rows = 25;

	// Token: 0x0400230E RID: 8974
	public int Columns = 25;

	// Token: 0x0400230F RID: 8975
	public int ID;
}
