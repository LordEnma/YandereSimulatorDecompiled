using System;
using Pathfinding;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D25 RID: 7461 RVA: 0x0015C4F9 File Offset: 0x0015A6F9
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D26 RID: 7462 RVA: 0x0015C510 File Offset: 0x0015A710
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

	// Token: 0x06001D27 RID: 7463 RVA: 0x0015C618 File Offset: 0x0015A818
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x040034F8 RID: 13560
	public CharacterController MyController;

	// Token: 0x040034F9 RID: 13561
	public Animation MyAnimation;

	// Token: 0x040034FA RID: 13562
	public AIPath Pathfinding;

	// Token: 0x040034FB RID: 13563
	public Transform[] Destinations;

	// Token: 0x040034FC RID: 13564
	public float Timer;

	// Token: 0x040034FD RID: 13565
	public int ID;
}
