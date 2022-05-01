using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x0600143A RID: 5178 RVA: 0x000C6C98 File Offset: 0x000C4E98
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600143B RID: 5179 RVA: 0x000C6CBC File Offset: 0x000C4EBC
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

	// Token: 0x04001EFF RID: 7935
	public int Frame;
}
