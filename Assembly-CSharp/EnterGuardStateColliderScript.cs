using System;
using UnityEngine;

// Token: 0x020002A4 RID: 676
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x06001412 RID: 5138 RVA: 0x000C442F File Offset: 0x000C262F
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001413 RID: 5139 RVA: 0x000C4454 File Offset: 0x000C2654
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

	// Token: 0x04001E94 RID: 7828
	public int Frame;
}
