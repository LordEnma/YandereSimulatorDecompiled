using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A73 RID: 6771 RVA: 0x0011BF54 File Offset: 0x0011A154
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A74 RID: 6772 RVA: 0x0011BFA4 File Offset: 0x0011A1A4
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

	// Token: 0x04002BC5 RID: 11205
	public UIPanel Panel;

	// Token: 0x04002BC6 RID: 11206
	public bool Show;

	// Token: 0x04002BC7 RID: 11207
	public UILabel Label;
}
