using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x06001436 RID: 5174 RVA: 0x000C6624 File Offset: 0x000C4824
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001437 RID: 5175 RVA: 0x000C6648 File Offset: 0x000C4848
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

	// Token: 0x04001EF4 RID: 7924
	public int Frame;
}
