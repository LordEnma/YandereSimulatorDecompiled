using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019C6 RID: 6598 RVA: 0x0010842A File Offset: 0x0010662A
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019C7 RID: 6599 RVA: 0x00108450 File Offset: 0x00106650
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "0")
		{
			this.MyStudent.CharacterAnimation[this.Prefix + "down_22"].speed = 0.1f;
			this.MyStudent.CharacterAnimation.CrossFade(this.Prefix + "down_22", 1f);
			this.MyStudent.Pathfinding.canSearch = false;
			this.MyStudent.Pathfinding.canMove = false;
			this.MyStudent.Routine = false;
			this.MyStudent.DeathType = DeathType.Weapon;
			this.MyStudent.Yandere.Bloodiness += 20f;
			this.BloodEffect.SetActive(true);
			this.Nape.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x0400295B RID: 10587
	public StudentScript MyStudent;

	// Token: 0x0400295C RID: 10588
	public GameObject BloodEffect;

	// Token: 0x0400295D RID: 10589
	public string Prefix;

	// Token: 0x0400295E RID: 10590
	public Collider Nape;
}
