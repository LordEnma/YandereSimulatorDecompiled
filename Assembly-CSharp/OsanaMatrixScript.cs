using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A32 RID: 6706 RVA: 0x0011506C File Offset: 0x0011326C
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 1f, Time.deltaTime);
			return;
		}
		if (this.Phase == 3)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 0f, Time.deltaTime);
			return;
		}
		if (this.Phase == 4)
		{
			this.Rivals.SetActive(true);
		}
	}

	// Token: 0x04002ABD RID: 10941
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002ABE RID: 10942
	public GameObject Rivals;

	// Token: 0x04002ABF RID: 10943
	public int Phase = 1;
}
