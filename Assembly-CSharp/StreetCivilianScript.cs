using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000445 RID: 1093
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D06 RID: 7430 RVA: 0x00159045 File Offset: 0x00157245
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x0015905C File Offset: 0x0015725C
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

	// Token: 0x06001D08 RID: 7432 RVA: 0x00159164 File Offset: 0x00157364
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x040034BE RID: 13502
	public CharacterController MyController;

	// Token: 0x040034BF RID: 13503
	public Animation MyAnimation;

	// Token: 0x040034C0 RID: 13504
	public AIPath Pathfinding;

	// Token: 0x040034C1 RID: 13505
	public Transform[] Destinations;

	// Token: 0x040034C2 RID: 13506
	public float Timer;

	// Token: 0x040034C3 RID: 13507
	public int ID;
}
