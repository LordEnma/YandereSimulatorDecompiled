using System;
using Pathfinding;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D27 RID: 7463 RVA: 0x0015CA7D File Offset: 0x0015AC7D
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D28 RID: 7464 RVA: 0x0015CA94 File Offset: 0x0015AC94
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Destinations[this.ID].position) < 0.55f)
		{
			this.MoveTowardsTarget(this.Destinations[this.ID].position);
			this.MyAnimation.CrossFade("f02_idle_00");
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Timer += Time.deltaTime;
			if (this.Timer > 13.5f)
			{
				this.MyAnimation.CrossFade("f02_newWalk_00");
				this.ID++;
				if (this.ID == this.Destinations.Length)
				{
					this.ID = 0;
				}
				this.Pathfinding.target = this.Destinations[this.ID];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x06001D29 RID: 7465 RVA: 0x0015CB9C File Offset: 0x0015AD9C
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x0400350E RID: 13582
	public CharacterController MyController;

	// Token: 0x0400350F RID: 13583
	public Animation MyAnimation;

	// Token: 0x04003510 RID: 13584
	public AIPath Pathfinding;

	// Token: 0x04003511 RID: 13585
	public Transform[] Destinations;

	// Token: 0x04003512 RID: 13586
	public float Timer;

	// Token: 0x04003513 RID: 13587
	public int ID;
}
