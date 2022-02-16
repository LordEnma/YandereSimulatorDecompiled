using System;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A29 RID: 6697 RVA: 0x00114658 File Offset: 0x00112858
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

	// Token: 0x04002AAD RID: 10925
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002AAE RID: 10926
	public GameObject Rivals;

	// Token: 0x04002AAF RID: 10927
	public int Phase = 1;
}
