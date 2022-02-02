using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A74 RID: 6772 RVA: 0x0011C398 File Offset: 0x0011A598
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A75 RID: 6773 RVA: 0x0011C3E8 File Offset: 0x0011A5E8
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

	// Token: 0x04002BCB RID: 11211
	public UIPanel Panel;

	// Token: 0x04002BCC RID: 11212
	public bool Show;

	// Token: 0x04002BCD RID: 11213
	public UILabel Label;
}
