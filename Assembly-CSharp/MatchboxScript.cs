using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MatchboxScript : MonoBehaviour
{
	// Token: 0x06001983 RID: 6531 RVA: 0x00103BB0 File Offset: 0x00101DB0
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

	// Token: 0x040028C2 RID: 10434
	public YandereScript Yandere;

	// Token: 0x040028C3 RID: 10435
	public PromptScript Prompt;

	// Token: 0x040028C4 RID: 10436
	public PickUpScript PickUp;

	// Token: 0x040028C5 RID: 10437
	public GameObject Match;

	// Token: 0x040028C6 RID: 10438
	public AudioSource MyAudio;

	// Token: 0x040028C7 RID: 10439
	public int Ammo;
}
