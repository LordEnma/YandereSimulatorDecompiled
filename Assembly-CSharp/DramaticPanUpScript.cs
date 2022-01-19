using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013AF RID: 5039 RVA: 0x000BA288 File Offset: 0x000B8488
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Pan = true;
		}
		if (this.Pan)
		{
			this.Power += Time.deltaTime * 0.5f;
			this.Height = Mathf.Lerp(this.Height, 1.4f, this.Power * Time.deltaTime);
			base.transform.localPosition = new Vector3(0f, this.Height, 1f);
		}
	}

	// Token: 0x04001D3C RID: 7484
	public bool Pan;

	// Token: 0x04001D3D RID: 7485
	public float Height;

	// Token: 0x04001D3E RID: 7486
	public float Power;
}
