using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001AA2 RID: 6818 RVA: 0x0011ECE0 File Offset: 0x0011CEE0
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001AA3 RID: 6819 RVA: 0x0011ED30 File Offset: 0x0011CF30
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

	// Token: 0x04002C44 RID: 11332
	public UIPanel Panel;

	// Token: 0x04002C45 RID: 11333
	public bool Show;

	// Token: 0x04002C46 RID: 11334
	public UILabel Label;
}
