using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x001582DD File Offset: 0x001564DD
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001CFD RID: 7421 RVA: 0x001582F4 File Offset: 0x001564F4
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

	// Token: 0x06001CFE RID: 7422 RVA: 0x001583FC File Offset: 0x001565FC
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x0400348C RID: 13452
	public CharacterController MyController;

	// Token: 0x0400348D RID: 13453
	public Animation MyAnimation;

	// Token: 0x0400348E RID: 13454
	public AIPath Pathfinding;

	// Token: 0x0400348F RID: 13455
	public Transform[] Destinations;

	// Token: 0x04003490 RID: 13456
	public float Timer;

	// Token: 0x04003491 RID: 13457
	public int ID;
}
