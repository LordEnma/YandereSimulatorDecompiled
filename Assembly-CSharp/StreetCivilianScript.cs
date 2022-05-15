using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000451 RID: 1105
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D57 RID: 7511 RVA: 0x0016051D File Offset: 0x0015E71D
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D58 RID: 7512 RVA: 0x00160534 File Offset: 0x0015E734
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

	// Token: 0x06001D59 RID: 7513 RVA: 0x0016063C File Offset: 0x0015E83C
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x04003599 RID: 13721
	public CharacterController MyController;

	// Token: 0x0400359A RID: 13722
	public Animation MyAnimation;

	// Token: 0x0400359B RID: 13723
	public AIPath Pathfinding;

	// Token: 0x0400359C RID: 13724
	public Transform[] Destinations;

	// Token: 0x0400359D RID: 13725
	public float Timer;

	// Token: 0x0400359E RID: 13726
	public int ID;
}
