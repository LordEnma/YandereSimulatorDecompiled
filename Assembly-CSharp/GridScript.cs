using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GridScript : MonoBehaviour
{
	// Token: 0x06001836 RID: 6198 RVA: 0x000E5D54 File Offset: 0x000E3F54
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

	// Token: 0x0400233E RID: 9022
	public GameObject Tile;

	// Token: 0x0400233F RID: 9023
	public int Row;

	// Token: 0x04002340 RID: 9024
	public int Column;

	// Token: 0x04002341 RID: 9025
	public int Rows = 25;

	// Token: 0x04002342 RID: 9026
	public int Columns = 25;

	// Token: 0x04002343 RID: 9027
	public int ID;
}
