using System;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class BodyPartScript : MonoBehaviour
{
	// Token: 0x06000A4F RID: 2639 RVA: 0x0005BC38 File Offset: 0x00059E38
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

	// Token: 0x04000BD6 RID: 3030
	public bool Sacrifice;

	// Token: 0x04000BD7 RID: 3031
	public int StudentID;

	// Token: 0x04000BD8 RID: 3032
	public int Type;

	// Token: 0x04000BD9 RID: 3033
	public GameObject GarbageBag;

	// Token: 0x04000BDA RID: 3034
	public PromptScript Prompt;

	// Token: 0x04000BDB RID: 3035
	public AudioClip WrapSFX;
}
