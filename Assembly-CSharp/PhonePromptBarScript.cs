using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001AAD RID: 6829 RVA: 0x0011FDDC File Offset: 0x0011DFDC
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001AAE RID: 6830 RVA: 0x0011FE2C File Offset: 0x0011E02C
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

	// Token: 0x04002C66 RID: 11366
	public UIPanel Panel;

	// Token: 0x04002C67 RID: 11367
	public bool Show;

	// Token: 0x04002C68 RID: 11368
	public UILabel Label;
}
