using System;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A42 RID: 6722 RVA: 0x00117140 File Offset: 0x00115340
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A43 RID: 6723 RVA: 0x00117180 File Offset: 0x00115380
	private void Update()
	{
		if (this.Student == null)
		{
			this.Student = this.StudentManager.Students[this.PlayerID];
			return;
		}
		if (!this.Osu.activeInHierarchy)
		{
			if (Vector3.Distance(base.transform.position, this.Student.transform.position) < 0.1f && this.Student.Routine && this.Student.CurrentDestination == this.Student.Destinations[this.Student.Phase] && this.Student.Actions[this.Student.Phase] == StudentActionType.Gaming)
			{
				this.ActivateOsu();
				return;
			}
		}
		else
		{
			this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
			if (!this.Student.Routine || this.Student.CurrentDestination != this.Student.Destinations[this.Student.Phase] || this.Student.Actions[this.Student.Phase] != StudentActionType.Gaming)
			{
				this.DeactivateOsu();
			}
		}
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x001172B8 File Offset: 0x001154B8
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A45 RID: 6725 RVA: 0x00117328 File Offset: 0x00115528
	private void DeactivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(false);
		this.Music.SetActive(false);
		OsuScript[] osuScripts = this.OsuScripts;
		for (int i = 0; i < osuScripts.Length; i++)
		{
			osuScripts[i].Timer = 0f;
		}
		this.Mouse.parent = base.transform.parent;
		this.Mouse.transform.position = this.OriginalMousePosition;
	}

	// Token: 0x04002AFD RID: 11005
	public StudentManagerScript StudentManager;

	// Token: 0x04002AFE RID: 11006
	public OsuScript[] OsuScripts;

	// Token: 0x04002AFF RID: 11007
	public StudentScript Student;

	// Token: 0x04002B00 RID: 11008
	public ClockScript Clock;

	// Token: 0x04002B01 RID: 11009
	public GameObject Music;

	// Token: 0x04002B02 RID: 11010
	public Transform Mouse;

	// Token: 0x04002B03 RID: 11011
	public GameObject Osu;

	// Token: 0x04002B04 RID: 11012
	public int PlayerID;

	// Token: 0x04002B05 RID: 11013
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B06 RID: 11014
	public Vector3 OriginalMouseRotation;
}
