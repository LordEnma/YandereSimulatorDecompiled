using System;
using UnityEngine;

// Token: 0x020002C6 RID: 710
public class FallCheckerScript : MonoBehaviour
{
	// Token: 0x06001493 RID: 5267 RVA: 0x000C9420 File Offset: 0x000C7620
	private void OnTriggerEnter(Collider other)
	{
		if (this.Ragdoll == null && other.gameObject.layer == 11)
		{
			this.Ragdoll = other.transform.root.gameObject.GetComponent<RagdollScript>();
			this.Ragdoll.Prompt.Hide();
			this.Ragdoll.Prompt.enabled = false;
			this.Ragdoll.Prompt.MyCollider.enabled = false;
			this.Ragdoll.BloodPoolSpawner.enabled = false;
			this.Ragdoll.HideCollider = this.MyCollider;
			if (!this.Ragdoll.Concealed)
			{
				this.Ragdoll.Police.HiddenCorpses++;
			}
			this.Ragdoll.Hidden = true;
			this.Dumpster.Corpse = this.Ragdoll.gameObject;
			this.Dumpster.Victim = this.Ragdoll.Student;
		}
	}

	// Token: 0x06001494 RID: 5268 RVA: 0x000C9524 File Offset: 0x000C7724
	private void Update()
	{
		if (this.Ragdoll != null)
		{
			if (this.Ragdoll.Prompt.transform.localPosition.y > -10.5f)
			{
				this.Ragdoll.Prompt.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
				this.Ragdoll.AllColliders[2].transform.localEulerAngles = Vector3.zero;
				this.Ragdoll.AllColliders[7].transform.localEulerAngles = new Vector3(0f, 0f, -80f);
				this.Ragdoll.Prompt.transform.position = new Vector3(this.Dumpster.transform.position.x, this.Ragdoll.Prompt.transform.position.y, this.Dumpster.transform.position.z);
				return;
			}
			base.GetComponent<AudioSource>().Play();
			this.Dumpster.Slide = true;
			this.Ragdoll = null;
		}
	}

	// Token: 0x04001FF8 RID: 8184
	public DumpsterLidScript Dumpster;

	// Token: 0x04001FF9 RID: 8185
	public RagdollScript Ragdoll;

	// Token: 0x04001FFA RID: 8186
	public Collider MyCollider;
}
