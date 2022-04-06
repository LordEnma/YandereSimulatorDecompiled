using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013C7 RID: 5063 RVA: 0x000BB538 File Offset: 0x000B9738
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

	// Token: 0x04001D72 RID: 7538
	public bool Pan;

	// Token: 0x04001D73 RID: 7539
	public float Height;

	// Token: 0x04001D74 RID: 7540
	public float Power;
}
