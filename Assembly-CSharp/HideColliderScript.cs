using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001842 RID: 6210 RVA: 0x000E9C44 File Offset: 0x000E7E44
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

	// Token: 0x040023EC RID: 9196
	public RagdollScript Corpse;

	// Token: 0x040023ED RID: 9197
	public Collider MyCollider;
}
