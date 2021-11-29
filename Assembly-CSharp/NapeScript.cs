using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019B8 RID: 6584 RVA: 0x00106EAA File Offset: 0x001050AA
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019B9 RID: 6585 RVA: 0x00106ED0 File Offset: 0x001050D0
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

	// Token: 0x04002922 RID: 10530
	public StudentScript MyStudent;

	// Token: 0x04002923 RID: 10531
	public GameObject BloodEffect;

	// Token: 0x04002924 RID: 10532
	public string Prefix;

	// Token: 0x04002925 RID: 10533
	public Collider Nape;
}
