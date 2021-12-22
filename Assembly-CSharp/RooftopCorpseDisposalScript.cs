using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class RooftopCorpseDisposalScript : MonoBehaviour
{
	// Token: 0x06001BBB RID: 7099 RVA: 0x001424CF File Offset: 0x001406CF
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001BBC RID: 7100 RVA: 0x001424E4 File Offset: 0x001406E4
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

	// Token: 0x040030AB RID: 12459
	public YandereScript Yandere;

	// Token: 0x040030AC RID: 12460
	public PromptScript Prompt;

	// Token: 0x040030AD RID: 12461
	public Collider MyCollider;

	// Token: 0x040030AE RID: 12462
	public Transform DropSpot;
}
