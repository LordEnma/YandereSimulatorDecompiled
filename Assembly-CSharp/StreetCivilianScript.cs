using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D51 RID: 7505 RVA: 0x0015F89D File Offset: 0x0015DA9D
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D52 RID: 7506 RVA: 0x0015F8B4 File Offset: 0x0015DAB4
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

	// Token: 0x06001D53 RID: 7507 RVA: 0x0015F9BC File Offset: 0x0015DBBC
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x04003584 RID: 13700
	public CharacterController MyController;

	// Token: 0x04003585 RID: 13701
	public Animation MyAnimation;

	// Token: 0x04003586 RID: 13702
	public AIPath Pathfinding;

	// Token: 0x04003587 RID: 13703
	public Transform[] Destinations;

	// Token: 0x04003588 RID: 13704
	public float Timer;

	// Token: 0x04003589 RID: 13705
	public int ID;
}
