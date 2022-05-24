using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000451 RID: 1105
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D58 RID: 7512 RVA: 0x001607D9 File Offset: 0x0015E9D9
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D59 RID: 7513 RVA: 0x001607F0 File Offset: 0x0015E9F0
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

	// Token: 0x06001D5A RID: 7514 RVA: 0x001608F8 File Offset: 0x0015EAF8
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x040035A1 RID: 13729
	public CharacterController MyController;

	// Token: 0x040035A2 RID: 13730
	public Animation MyAnimation;

	// Token: 0x040035A3 RID: 13731
	public AIPath Pathfinding;

	// Token: 0x040035A4 RID: 13732
	public Transform[] Destinations;

	// Token: 0x040035A5 RID: 13733
	public float Timer;

	// Token: 0x040035A6 RID: 13734
	public int ID;
}
