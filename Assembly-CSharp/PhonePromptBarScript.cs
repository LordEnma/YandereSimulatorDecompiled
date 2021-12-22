using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A6A RID: 6762 RVA: 0x0011B7C8 File Offset: 0x001199C8
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A6B RID: 6763 RVA: 0x0011B818 File Offset: 0x00119A18
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

	// Token: 0x04002BB8 RID: 11192
	public UIPanel Panel;

	// Token: 0x04002BB9 RID: 11193
	public bool Show;

	// Token: 0x04002BBA RID: 11194
	public UILabel Label;
}
