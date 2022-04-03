using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013C1 RID: 5057 RVA: 0x000BB430 File Offset: 0x000B9630
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

	// Token: 0x04001D70 RID: 7536
	public bool Pan;

	// Token: 0x04001D71 RID: 7537
	public float Height;

	// Token: 0x04001D72 RID: 7538
	public float Power;
}
