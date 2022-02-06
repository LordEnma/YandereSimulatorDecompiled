using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A22 RID: 6690 RVA: 0x00114334 File Offset: 0x00112534
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

	// Token: 0x04002AA7 RID: 10919
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002AA8 RID: 10920
	public GameObject Rivals;

	// Token: 0x04002AA9 RID: 10921
	public int Phase = 1;
}
