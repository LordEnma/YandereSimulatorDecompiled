using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019C1 RID: 6593 RVA: 0x00107A26 File Offset: 0x00105C26
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019C2 RID: 6594 RVA: 0x00107A4C File Offset: 0x00105C4C
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

	// Token: 0x0400294B RID: 10571
	public StudentScript MyStudent;

	// Token: 0x0400294C RID: 10572
	public GameObject BloodEffect;

	// Token: 0x0400294D RID: 10573
	public string Prefix;

	// Token: 0x0400294E RID: 10574
	public Collider Nape;
}
