﻿using System;
using UnityEngine;

// Token: 0x020002A6 RID: 678
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x0600141E RID: 5150 RVA: 0x000C53C4 File Offset: 0x000C35C4
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600141F RID: 5151 RVA: 0x000C53E8 File Offset: 0x000C35E8
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

	// Token: 0x04001EC0 RID: 7872
	public int Frame;
}
