using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013BD RID: 5053 RVA: 0x000BADA4 File Offset: 0x000B8FA4
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

	// Token: 0x04001D55 RID: 7509
	public bool Pan;

	// Token: 0x04001D56 RID: 7510
	public float Height;

	// Token: 0x04001D57 RID: 7511
	public float Power;
}
