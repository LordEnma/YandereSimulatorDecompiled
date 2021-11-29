using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A62 RID: 6754 RVA: 0x0011AF88 File Offset: 0x00119188
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A63 RID: 6755 RVA: 0x0011AFD8 File Offset: 0x001191D8
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

	// Token: 0x04002B8E RID: 11150
	public UIPanel Panel;

	// Token: 0x04002B8F RID: 11151
	public bool Show;

	// Token: 0x04002B90 RID: 11152
	public UILabel Label;
}
