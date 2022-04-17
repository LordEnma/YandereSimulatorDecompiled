using System;
using Pathfinding;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D4A RID: 7498 RVA: 0x0015F00D File Offset: 0x0015D20D
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D4B RID: 7499 RVA: 0x0015F024 File Offset: 0x0015D224
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

	// Token: 0x06001D4C RID: 7500 RVA: 0x0015F12C File Offset: 0x0015D32C
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x04003575 RID: 13685
	public CharacterController MyController;

	// Token: 0x04003576 RID: 13686
	public Animation MyAnimation;

	// Token: 0x04003577 RID: 13687
	public AIPath Pathfinding;

	// Token: 0x04003578 RID: 13688
	public Transform[] Destinations;

	// Token: 0x04003579 RID: 13689
	public float Timer;

	// Token: 0x0400357A RID: 13690
	public int ID;
}
