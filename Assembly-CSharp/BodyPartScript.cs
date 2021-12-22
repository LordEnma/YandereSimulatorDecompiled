using System;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class BodyPartScript : MonoBehaviour
{
	// Token: 0x06000A4F RID: 2639 RVA: 0x0005BA8C File Offset: 0x00059C8C
	private void Update()
	{
		if (this.Prompt != null)
		{
			if (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.GarbageBagBox)
			{
				this.Prompt.HideButton[0] = false;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.GarbageBag, base.transform.position, Quaternion.identity);
					gameObject.GetComponent<BodyPartScript>().StudentID = this.StudentID;
					gameObject.transform.parent = this.Prompt.Yandere.Police.GarbageParent;
					this.Prompt.Yandere.StudentManager.GarbageBagList[this.Prompt.Yandere.StudentManager.GarbageBags] = gameObject;
					this.Prompt.Yandere.StudentManager.GarbageBags++;
					AudioSource.PlayClipAtPoint(this.WrapSFX, base.transform.position);
					UnityEngine.Object.Destroy(base.gameObject);
					return;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
	}

	// Token: 0x04000BCB RID: 3019
	public bool Sacrifice;

	// Token: 0x04000BCC RID: 3020
	public int StudentID;

	// Token: 0x04000BCD RID: 3021
	public int Type;

	// Token: 0x04000BCE RID: 3022
	public GameObject GarbageBag;

	// Token: 0x04000BCF RID: 3023
	public PromptScript Prompt;

	// Token: 0x04000BD0 RID: 3024
	public AudioClip WrapSFX;
}
