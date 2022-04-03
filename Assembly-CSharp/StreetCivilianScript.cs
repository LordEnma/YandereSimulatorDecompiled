using System;
using Pathfinding;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D3F RID: 7487 RVA: 0x0015E875 File Offset: 0x0015CA75
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D40 RID: 7488 RVA: 0x0015E88C File Offset: 0x0015CA8C
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

	// Token: 0x06001D41 RID: 7489 RVA: 0x0015E994 File Offset: 0x0015CB94
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x04003566 RID: 13670
	public CharacterController MyController;

	// Token: 0x04003567 RID: 13671
	public Animation MyAnimation;

	// Token: 0x04003568 RID: 13672
	public AIPath Pathfinding;

	// Token: 0x04003569 RID: 13673
	public Transform[] Destinations;

	// Token: 0x0400356A RID: 13674
	public float Timer;

	// Token: 0x0400356B RID: 13675
	public int ID;
}
