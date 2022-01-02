using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class RooftopCorpseDisposalScript : MonoBehaviour
{
	// Token: 0x06001BBD RID: 7101 RVA: 0x001428CB File Offset: 0x00140ACB
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001BBE RID: 7102 RVA: 0x001428E0 File Offset: 0x00140AE0
	private void Update()
	{
		if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
		{
			if (!(this.Yandere.Ragdoll != null))
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
			if (!this.Yandere.Dropping)
			{
				this.Prompt.enabled = true;
				this.Prompt.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1.66666f, this.Yandere.transform.position.z);
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.DropSpot.position = new Vector3(this.DropSpot.position.x, this.DropSpot.position.y, this.Yandere.transform.position.z);
					this.Yandere.CharacterAnimation.CrossFade(this.Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
					this.Yandere.DropSpot = this.DropSpot;
					this.Yandere.Dropping = true;
					this.Yandere.CanMove = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Yandere.Ragdoll.GetComponent<RagdollScript>().BloodPoolSpawner.Falling = true;
					return;
				}
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x040030B2 RID: 12466
	public YandereScript Yandere;

	// Token: 0x040030B3 RID: 12467
	public PromptScript Prompt;

	// Token: 0x040030B4 RID: 12468
	public Collider MyCollider;

	// Token: 0x040030B5 RID: 12469
	public Transform DropSpot;
}
