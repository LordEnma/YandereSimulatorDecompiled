using System;
using UnityEngine;

// Token: 0x020002AA RID: 682
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x0600143C RID: 5180 RVA: 0x000C6F54 File Offset: 0x000C5154
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600143D RID: 5181 RVA: 0x000C6F78 File Offset: 0x000C5178
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

	// Token: 0x04001F06 RID: 7942
	public int Frame;
}
