using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019BF RID: 6591 RVA: 0x0010774A File Offset: 0x0010594A
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x00107770 File Offset: 0x00105970
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

	// Token: 0x04002947 RID: 10567
	public StudentScript MyStudent;

	// Token: 0x04002948 RID: 10568
	public GameObject BloodEffect;

	// Token: 0x04002949 RID: 10569
	public string Prefix;

	// Token: 0x0400294A RID: 10570
	public Collider Nape;
}
