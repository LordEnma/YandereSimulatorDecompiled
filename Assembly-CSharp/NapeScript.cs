using System;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019CF RID: 6607 RVA: 0x0010885A File Offset: 0x00106A5A
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019D0 RID: 6608 RVA: 0x00108880 File Offset: 0x00106A80
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

	// Token: 0x04002964 RID: 10596
	public StudentScript MyStudent;

	// Token: 0x04002965 RID: 10597
	public GameObject BloodEffect;

	// Token: 0x04002966 RID: 10598
	public string Prefix;

	// Token: 0x04002967 RID: 10599
	public Collider Nape;
}
