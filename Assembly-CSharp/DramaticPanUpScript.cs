using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013CD RID: 5069 RVA: 0x000BBE38 File Offset: 0x000BA038
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

	// Token: 0x04001D83 RID: 7555
	public bool Pan;

	// Token: 0x04001D84 RID: 7556
	public float Height;

	// Token: 0x04001D85 RID: 7557
	public float Power;
}
