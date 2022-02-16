using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A7D RID: 6781 RVA: 0x0011C8D0 File Offset: 0x0011AAD0
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A7E RID: 6782 RVA: 0x0011C920 File Offset: 0x0011AB20
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

	// Token: 0x04002BD5 RID: 11221
	public UIPanel Panel;

	// Token: 0x04002BD6 RID: 11222
	public bool Show;

	// Token: 0x04002BD7 RID: 11223
	public UILabel Label;
}
