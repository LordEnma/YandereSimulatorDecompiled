using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RooftopCorpseDisposalScript : MonoBehaviour
{
	// Token: 0x06001BC6 RID: 7110 RVA: 0x00144347 File Offset: 0x00142547
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x0014435C File Offset: 0x0014255C
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

	// Token: 0x040030BD RID: 12477
	public YandereScript Yandere;

	// Token: 0x040030BE RID: 12478
	public PromptScript Prompt;

	// Token: 0x040030BF RID: 12479
	public Collider MyCollider;

	// Token: 0x040030C0 RID: 12480
	public Transform DropSpot;
}
