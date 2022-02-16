using System;
using UnityEngine;

// Token: 0x020002A7 RID: 679
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x06001423 RID: 5155 RVA: 0x000C5548 File Offset: 0x000C3748
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001424 RID: 5156 RVA: 0x000C556C File Offset: 0x000C376C
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

	// Token: 0x04001EC7 RID: 7879
	public int Frame;
}
