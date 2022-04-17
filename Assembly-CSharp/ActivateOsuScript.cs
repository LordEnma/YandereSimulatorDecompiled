using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A5C RID: 6748 RVA: 0x0011871C File Offset: 0x0011691C
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A5D RID: 6749 RVA: 0x0011875C File Offset: 0x0011695C
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

	// Token: 0x06001A5E RID: 6750 RVA: 0x00118894 File Offset: 0x00116A94
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A5F RID: 6751 RVA: 0x00118904 File Offset: 0x00116B04
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

	// Token: 0x04002B44 RID: 11076
	public StudentManagerScript StudentManager;

	// Token: 0x04002B45 RID: 11077
	public OsuScript[] OsuScripts;

	// Token: 0x04002B46 RID: 11078
	public StudentScript Student;

	// Token: 0x04002B47 RID: 11079
	public ClockScript Clock;

	// Token: 0x04002B48 RID: 11080
	public GameObject Music;

	// Token: 0x04002B49 RID: 11081
	public Transform Mouse;

	// Token: 0x04002B4A RID: 11082
	public GameObject Osu;

	// Token: 0x04002B4B RID: 11083
	public int PlayerID;

	// Token: 0x04002B4C RID: 11084
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B4D RID: 11085
	public Vector3 OriginalMouseRotation;
}
