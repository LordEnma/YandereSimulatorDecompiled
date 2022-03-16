using System;
using UnityEngine;

// Token: 0x020002A8 RID: 680
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x0600142F RID: 5167 RVA: 0x000C63E8 File Offset: 0x000C45E8
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001430 RID: 5168 RVA: 0x000C640C File Offset: 0x000C460C
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

	// Token: 0x04001EEF RID: 7919
	public int Frame;
}
