using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A91 RID: 6801 RVA: 0x0011E1CC File Offset: 0x0011C3CC
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A92 RID: 6802 RVA: 0x0011E21C File Offset: 0x0011C41C
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

	// Token: 0x04002C24 RID: 11300
	public UIPanel Panel;

	// Token: 0x04002C25 RID: 11301
	public bool Show;

	// Token: 0x04002C26 RID: 11302
	public UILabel Label;
}
