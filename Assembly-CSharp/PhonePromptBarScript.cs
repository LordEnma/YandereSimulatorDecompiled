using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001AAC RID: 6828 RVA: 0x0011FBAC File Offset: 0x0011DDAC
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001AAD RID: 6829 RVA: 0x0011FBFC File Offset: 0x0011DDFC
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

	// Token: 0x04002C5F RID: 11359
	public UIPanel Panel;

	// Token: 0x04002C60 RID: 11360
	public bool Show;

	// Token: 0x04002C61 RID: 11361
	public UILabel Label;
}
