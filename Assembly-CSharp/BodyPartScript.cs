using System;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class BodyPartScript : MonoBehaviour
{
	// Token: 0x06000A50 RID: 2640 RVA: 0x0005BF84 File Offset: 0x0005A184
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

	// Token: 0x04000BDF RID: 3039
	public bool Sacrifice;

	// Token: 0x04000BE0 RID: 3040
	public int StudentID;

	// Token: 0x04000BE1 RID: 3041
	public int Type;

	// Token: 0x04000BE2 RID: 3042
	public GameObject GarbageBag;

	// Token: 0x04000BE3 RID: 3043
	public PromptScript Prompt;

	// Token: 0x04000BE4 RID: 3044
	public AudioClip WrapSFX;
}
