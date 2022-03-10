using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013BD RID: 5053 RVA: 0x000BAF0C File Offset: 0x000B910C
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

	// Token: 0x04001D5E RID: 7518
	public bool Pan;

	// Token: 0x04001D5F RID: 7519
	public float Height;

	// Token: 0x04001D60 RID: 7520
	public float Power;
}
