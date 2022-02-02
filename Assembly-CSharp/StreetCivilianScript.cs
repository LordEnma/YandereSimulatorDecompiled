using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D13 RID: 7443 RVA: 0x0015B4A9 File Offset: 0x001596A9
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D14 RID: 7444 RVA: 0x0015B4C0 File Offset: 0x001596C0
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

	// Token: 0x06001D15 RID: 7445 RVA: 0x0015B5C8 File Offset: 0x001597C8
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x040034DE RID: 13534
	public CharacterController MyController;

	// Token: 0x040034DF RID: 13535
	public Animation MyAnimation;

	// Token: 0x040034E0 RID: 13536
	public AIPath Pathfinding;

	// Token: 0x040034E1 RID: 13537
	public Transform[] Destinations;

	// Token: 0x040034E2 RID: 13538
	public float Timer;

	// Token: 0x040034E3 RID: 13539
	public int ID;
}
