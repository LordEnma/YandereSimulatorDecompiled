using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MatchboxScript : MonoBehaviour
{
	// Token: 0x06001996 RID: 6550 RVA: 0x00104FEC File Offset: 0x001031EC
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

	// Token: 0x040028F7 RID: 10487
	public YandereScript Yandere;

	// Token: 0x040028F8 RID: 10488
	public PromptScript Prompt;

	// Token: 0x040028F9 RID: 10489
	public PickUpScript PickUp;

	// Token: 0x040028FA RID: 10490
	public GameObject Match;

	// Token: 0x040028FB RID: 10491
	public AudioSource MyAudio;

	// Token: 0x040028FC RID: 10492
	public int Ammo;
}
