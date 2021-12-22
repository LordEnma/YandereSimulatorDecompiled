using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A19 RID: 6681 RVA: 0x0011359C File Offset: 0x0011179C
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

	// Token: 0x04002A90 RID: 10896
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002A91 RID: 10897
	public GameObject Rivals;

	// Token: 0x04002A92 RID: 10898
	public int Phase = 1;
}
