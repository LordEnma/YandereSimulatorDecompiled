using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A33 RID: 6707 RVA: 0x00115444 File Offset: 0x00113644
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

	// Token: 0x04002AD3 RID: 10963
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002AD4 RID: 10964
	public GameObject Rivals;

	// Token: 0x04002AD5 RID: 10965
	public int Phase = 1;
}
