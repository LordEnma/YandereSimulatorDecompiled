using System;
using Pathfinding;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D35 RID: 7477 RVA: 0x0015DC2D File Offset: 0x0015BE2D
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D36 RID: 7478 RVA: 0x0015DC44 File Offset: 0x0015BE44
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

	// Token: 0x06001D37 RID: 7479 RVA: 0x0015DD4C File Offset: 0x0015BF4C
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x04003549 RID: 13641
	public CharacterController MyController;

	// Token: 0x0400354A RID: 13642
	public Animation MyAnimation;

	// Token: 0x0400354B RID: 13643
	public AIPath Pathfinding;

	// Token: 0x0400354C RID: 13644
	public Transform[] Destinations;

	// Token: 0x0400354D RID: 13645
	public float Timer;

	// Token: 0x0400354E RID: 13646
	public int ID;
}
