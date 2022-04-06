using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A9E RID: 6814 RVA: 0x0011E9D8 File Offset: 0x0011CBD8
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A9F RID: 6815 RVA: 0x0011EA28 File Offset: 0x0011CC28
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

	// Token: 0x04002C3C RID: 11324
	public UIPanel Panel;

	// Token: 0x04002C3D RID: 11325
	public bool Show;

	// Token: 0x04002C3E RID: 11326
	public UILabel Label;
}
