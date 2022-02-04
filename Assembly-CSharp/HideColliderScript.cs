using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001843 RID: 6211 RVA: 0x000EA118 File Offset: 0x000E8318
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			GameObject gameObject = other.gameObject.transform.root.gameObject;
			if (!gameObject.GetComponent<StudentScript>().Alive)
			{
				this.Corpse = gameObject.GetComponent<RagdollScript>();
				if (!this.Corpse.Hidden && !this.Corpse.Concealed)
				{
					this.Corpse.HideCollider = this.MyCollider;
					this.Corpse.Police.HiddenCorpses++;
					this.Corpse.Hidden = true;
				}
			}
		}
	}

	// Token: 0x040023F2 RID: 9202
	public RagdollScript Corpse;

	// Token: 0x040023F3 RID: 9203
	public Collider MyCollider;
}
