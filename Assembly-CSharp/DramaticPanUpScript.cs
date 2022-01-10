using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013AF RID: 5039 RVA: 0x000BA224 File Offset: 0x000B8424
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

	// Token: 0x04001D3A RID: 7482
	public bool Pan;

	// Token: 0x04001D3B RID: 7483
	public float Height;

	// Token: 0x04001D3C RID: 7484
	public float Power;
}
