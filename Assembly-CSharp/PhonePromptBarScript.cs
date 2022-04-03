using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A98 RID: 6808 RVA: 0x0011E82C File Offset: 0x0011CA2C
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A99 RID: 6809 RVA: 0x0011E87C File Offset: 0x0011CA7C
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

	// Token: 0x04002C39 RID: 11321
	public UIPanel Panel;

	// Token: 0x04002C3A RID: 11322
	public bool Show;

	// Token: 0x04002C3B RID: 11323
	public UILabel Label;
}
