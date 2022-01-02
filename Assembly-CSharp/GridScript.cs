using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GridScript : MonoBehaviour
{
	// Token: 0x0600181A RID: 6170 RVA: 0x000E414C File Offset: 0x000E234C
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

	// Token: 0x040022F4 RID: 8948
	public GameObject Tile;

	// Token: 0x040022F5 RID: 8949
	public int Row;

	// Token: 0x040022F6 RID: 8950
	public int Column;

	// Token: 0x040022F7 RID: 8951
	public int Rows = 25;

	// Token: 0x040022F8 RID: 8952
	public int Columns = 25;

	// Token: 0x040022F9 RID: 8953
	public int ID;
}
