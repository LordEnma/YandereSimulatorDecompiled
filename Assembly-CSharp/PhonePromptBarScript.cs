using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A87 RID: 6791 RVA: 0x0011D6BC File Offset: 0x0011B8BC
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A88 RID: 6792 RVA: 0x0011D70C File Offset: 0x0011B90C
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

	// Token: 0x04002BFB RID: 11259
	public UIPanel Panel;

	// Token: 0x04002BFC RID: 11260
	public bool Show;

	// Token: 0x04002BFD RID: 11261
	public UILabel Label;
}
