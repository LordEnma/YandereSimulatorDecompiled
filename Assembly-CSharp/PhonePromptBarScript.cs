using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A86 RID: 6790 RVA: 0x0011D2E4 File Offset: 0x0011B4E4
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A87 RID: 6791 RVA: 0x0011D334 File Offset: 0x0011B534
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

	// Token: 0x04002BE5 RID: 11237
	public UIPanel Panel;

	// Token: 0x04002BE6 RID: 11238
	public bool Show;

	// Token: 0x04002BE7 RID: 11239
	public UILabel Label;
}
