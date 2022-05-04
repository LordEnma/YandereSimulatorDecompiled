using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001AA6 RID: 6822 RVA: 0x0011F248 File Offset: 0x0011D448
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001AA7 RID: 6823 RVA: 0x0011F298 File Offset: 0x0011D498
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 631f, t), base.transform.localPosition.z);
				if (base.transform.localPosition.y < 630f)
				{
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, 631f, base.transform.localPosition.z);
					this.Panel.enabled = false;
					return;
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 530f, t), base.transform.localPosition.z);
		}
	}

	// Token: 0x04002C4D RID: 11341
	public UIPanel Panel;

	// Token: 0x04002C4E RID: 11342
	public bool Show;

	// Token: 0x04002C4F RID: 11343
	public UILabel Label;
}
