using System;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class MatchboxScript : MonoBehaviour
{
	// Token: 0x060019AE RID: 6574 RVA: 0x001063A4 File Offset: 0x001045A4
	private void Update()
	{
		if (!this.Prompt.PauseScreen.Show)
		{
			if (this.Prompt.Yandere.PickUp == this.PickUp)
			{
				if (this.Prompt.HideButton[0])
				{
					this.Prompt.Yandere.Arc.SetActive(true);
					this.Prompt.HideButton[0] = false;
					this.Prompt.HideButton[3] = true;
				}
				if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f)
				{
					this.Prompt.Circle[0].fillAmount = 0f;
					this.MyAudio.Play();
					Rigidbody component = UnityEngine.Object.Instantiate<GameObject>(this.Match, this.Prompt.Yandere.ItemParent.position, this.Prompt.Yandere.transform.rotation).GetComponent<Rigidbody>();
					component.isKinematic = false;
					component.useGravity = true;
					component.AddRelativeForce(Vector3.up * 250f);
					component.AddRelativeForce(Vector3.forward * 250f);
					this.Prompt.Yandere.SuspiciousActionTimer = 1f;
					this.Ammo--;
					if (this.Ammo < 1)
					{
						this.Prompt.Yandere.Arc.SetActive(false);
						this.Prompt.Yandere.PickUp.Drop();
						UnityEngine.Object.Destroy(base.gameObject);
						return;
					}
				}
			}
			else if (this.Prompt.Yandere.Arc.activeInHierarchy && !this.Prompt.HideButton[0])
			{
				this.Prompt.Yandere.Arc.SetActive(false);
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = false;
			}
		}
	}

	// Token: 0x04002937 RID: 10551
	public YandereScript Yandere;

	// Token: 0x04002938 RID: 10552
	public PromptScript Prompt;

	// Token: 0x04002939 RID: 10553
	public PickUpScript PickUp;

	// Token: 0x0400293A RID: 10554
	public GameObject Match;

	// Token: 0x0400293B RID: 10555
	public AudioSource MyAudio;

	// Token: 0x0400293C RID: 10556
	public int Ammo;
}
