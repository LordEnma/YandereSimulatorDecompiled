using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GridScript : MonoBehaviour
{
	// Token: 0x06001831 RID: 6193 RVA: 0x000E58A8 File Offset: 0x000E3AA8
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

	// Token: 0x0400232D RID: 9005
	public GameObject Tile;

	// Token: 0x0400232E RID: 9006
	public int Row;

	// Token: 0x0400232F RID: 9007
	public int Column;

	// Token: 0x04002330 RID: 9008
	public int Rows = 25;

	// Token: 0x04002331 RID: 9009
	public int Columns = 25;

	// Token: 0x04002332 RID: 9010
	public int ID;
}
