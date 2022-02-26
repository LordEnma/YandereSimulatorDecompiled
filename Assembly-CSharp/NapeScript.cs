using System;
using UnityEngine;

// Token: 0x02000375 RID: 885
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019D8 RID: 6616 RVA: 0x0010918A File Offset: 0x0010738A
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019D9 RID: 6617 RVA: 0x001091B0 File Offset: 0x001073B0
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

	// Token: 0x04002973 RID: 10611
	public StudentScript MyStudent;

	// Token: 0x04002974 RID: 10612
	public GameObject BloodEffect;

	// Token: 0x04002975 RID: 10613
	public string Prefix;

	// Token: 0x04002976 RID: 10614
	public Collider Nape;
}
