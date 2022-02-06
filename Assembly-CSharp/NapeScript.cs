using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019C8 RID: 6600 RVA: 0x00108536 File Offset: 0x00106736
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x0010855C File Offset: 0x0010675C
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

	// Token: 0x0400295E RID: 10590
	public StudentScript MyStudent;

	// Token: 0x0400295F RID: 10591
	public GameObject BloodEffect;

	// Token: 0x04002960 RID: 10592
	public string Prefix;

	// Token: 0x04002961 RID: 10593
	public Collider Nape;
}
