using System;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class BodyPartScript : MonoBehaviour
{
	// Token: 0x06000A52 RID: 2642 RVA: 0x0005C2A4 File Offset: 0x0005A4A4
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

	// Token: 0x04000BE4 RID: 3044
	public bool Sacrifice;

	// Token: 0x04000BE5 RID: 3045
	public int StudentID;

	// Token: 0x04000BE6 RID: 3046
	public int Type;

	// Token: 0x04000BE7 RID: 3047
	public GameObject GarbageBag;

	// Token: 0x04000BE8 RID: 3048
	public PromptScript Prompt;

	// Token: 0x04000BE9 RID: 3049
	public AudioClip WrapSFX;
}
