using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D1C RID: 7452 RVA: 0x0015BA4D File Offset: 0x00159C4D
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D1D RID: 7453 RVA: 0x0015BA64 File Offset: 0x00159C64
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

	// Token: 0x06001D1E RID: 7454 RVA: 0x0015BB6C File Offset: 0x00159D6C
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x040034E8 RID: 13544
	public CharacterController MyController;

	// Token: 0x040034E9 RID: 13545
	public Animation MyAnimation;

	// Token: 0x040034EA RID: 13546
	public AIPath Pathfinding;

	// Token: 0x040034EB RID: 13547
	public Transform[] Destinations;

	// Token: 0x040034EC RID: 13548
	public float Timer;

	// Token: 0x040034ED RID: 13549
	public int ID;
}
