using System;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class BarrelScript : MonoBehaviour
{
	// Token: 0x06000A0F RID: 2575 RVA: 0x0005709C File Offset: 0x0005529C
	private void Update()
	{
		if (this.Fall)
		{
			this.Corpse.GetComponent<StudentScript>().CharacterAnimation.Stop();
			this.Corpse.GetComponent<StudentScript>().CharacterAnimation.enabled = false;
			this.Corpse.GetComponent<RagdollScript>().enabled = true;
			this.Fall = false;
			this.Frame = 0;
		}
		if (this.Prompt.Yandere.Carrying)
		{
			this.Prompt.enabled = true;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Corpse = this.Prompt.Yandere.Ragdoll;
				this.Prompt.Yandere.EmptyHands();
				this.Corpse.transform.position = base.transform.position + Vector3.up * 2.5833333f;
				this.Corpse.transform.eulerAngles = new Vector3(0f, 135f, 180f);
				this.Corpse.GetComponent<RagdollScript>().enabled = false;
				this.Corpse.GetComponent<StudentScript>().CharacterAnimation.enabled = true;
				this.Corpse.GetComponent<StudentScript>().CharacterAnimation.Play("f02_idleShort_00");
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Fall = true;
				return;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x04000ADA RID: 2778
	public GameObject Corpse;

	// Token: 0x04000ADB RID: 2779
	public PromptScript Prompt;

	// Token: 0x04000ADC RID: 2780
	public bool Fall;

	// Token: 0x04000ADD RID: 2781
	public int Frame;
}
