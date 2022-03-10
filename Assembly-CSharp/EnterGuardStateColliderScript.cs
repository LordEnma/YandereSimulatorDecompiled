using System;
using UnityEngine;

// Token: 0x020002A8 RID: 680
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x0600142C RID: 5164 RVA: 0x000C5F78 File Offset: 0x000C4178
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600142D RID: 5165 RVA: 0x000C5F9C File Offset: 0x000C419C
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

	// Token: 0x04001EDF RID: 7903
	public int Frame;
}
