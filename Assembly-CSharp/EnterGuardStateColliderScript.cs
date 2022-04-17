using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x06001436 RID: 5174 RVA: 0x000C67D0 File Offset: 0x000C49D0
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001437 RID: 5175 RVA: 0x000C67F4 File Offset: 0x000C49F4
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

	// Token: 0x04001EF6 RID: 7926
	public int Frame;
}
