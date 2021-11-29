using System;
using UnityEngine;

// Token: 0x020000EF RID: 239
public class BodyPartScript : MonoBehaviour
{
	// Token: 0x06000A4C RID: 2636 RVA: 0x0005B918 File Offset: 0x00059B18
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

	// Token: 0x04000BC9 RID: 3017
	public bool Sacrifice;

	// Token: 0x04000BCA RID: 3018
	public int StudentID;

	// Token: 0x04000BCB RID: 3019
	public int Type;

	// Token: 0x04000BCC RID: 3020
	public GameObject GarbageBag;

	// Token: 0x04000BCD RID: 3021
	public PromptScript Prompt;

	// Token: 0x04000BCE RID: 3022
	public AudioClip WrapSFX;
}
