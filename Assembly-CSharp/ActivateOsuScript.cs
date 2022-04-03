using System;
using UnityEngine;

// Token: 0x0200038D RID: 909
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A52 RID: 6738 RVA: 0x001182A8 File Offset: 0x001164A8
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A53 RID: 6739 RVA: 0x001182E8 File Offset: 0x001164E8
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

	// Token: 0x06001A54 RID: 6740 RVA: 0x00118420 File Offset: 0x00116620
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A55 RID: 6741 RVA: 0x00118490 File Offset: 0x00116690
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

	// Token: 0x04002B39 RID: 11065
	public StudentManagerScript StudentManager;

	// Token: 0x04002B3A RID: 11066
	public OsuScript[] OsuScripts;

	// Token: 0x04002B3B RID: 11067
	public StudentScript Student;

	// Token: 0x04002B3C RID: 11068
	public ClockScript Clock;

	// Token: 0x04002B3D RID: 11069
	public GameObject Music;

	// Token: 0x04002B3E RID: 11070
	public Transform Mouse;

	// Token: 0x04002B3F RID: 11071
	public GameObject Osu;

	// Token: 0x04002B40 RID: 11072
	public int PlayerID;

	// Token: 0x04002B41 RID: 11073
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B42 RID: 11074
	public Vector3 OriginalMouseRotation;
}
