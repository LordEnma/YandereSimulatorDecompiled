using System;
using UnityEngine;

// Token: 0x020002A8 RID: 680
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x06001430 RID: 5168 RVA: 0x000C651C File Offset: 0x000C471C
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001431 RID: 5169 RVA: 0x000C6540 File Offset: 0x000C4740
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.Teacher)
			{
				component.CharacterAnimation.CrossFade(component.GuardAnim);
				component.IgnoringPettyActions = true;
				component.Pathfinding.canSearch = false;
				component.Pathfinding.canMove = false;
				component.ReportPhase = 6;
				component.Guarding = true;
				component.Routine = false;
			}
		}
	}

	// Token: 0x04001EF2 RID: 7922
	public int Frame;
}
