using System;
using UnityEngine;

// Token: 0x020000EF RID: 239
public class BodyHidingLockerScript : MonoBehaviour
{
	// Token: 0x06000A4E RID: 2638 RVA: 0x0005BC31 File Offset: 0x00059E31
	private void Start()
	{
		this.Outline = base.GetComponentInChildren<OutlineScript>();
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x0005BC40 File Offset: 0x00059E40
	private void Update()
	{
		if (this.Rotation != 0f)
		{
			this.Speed += Time.deltaTime * 100f;
			this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, this.Speed * Time.deltaTime);
			if (this.Rotation > -1f)
			{
				AudioSource.PlayClipAtPoint(this.LockerClose, this.Prompt.Yandere.MainCamera.transform.position);
				if (this.Corpse != null)
				{
					this.Corpse.gameObject.SetActive(false);
				}
				this.Prompt.enabled = true;
				this.Rotation = 0f;
				this.Speed = 0f;
				if (this.ABC)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
				}
			}
			this.Door.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
		if (this.Corpse == null)
		{
			if (this.Prompt.Yandere.Carrying || this.Prompt.Yandere.Dragging)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
					if (this.Prompt.Yandere.Carrying)
					{
						this.Corpse = this.Prompt.Yandere.CurrentRagdoll;
					}
					else
					{
						this.Corpse = this.Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
					}
					this.Prompt.Label[0].text = "     Remove Corpse";
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Yandere.EmptyHands();
					if (this.Corpse.AddingToCount)
					{
						this.Prompt.Yandere.NearBodies--;
						this.Corpse.AddingToCount = false;
					}
					this.Prompt.Yandere.NearestCorpseID = 0;
					this.Prompt.Yandere.CorpseWarning = false;
					this.Prompt.Yandere.StudentManager.UpdateStudents(0);
					this.Corpse.transform.parent = base.transform;
					this.Corpse.transform.position = base.transform.position + new Vector3(0f, 0.1f, 0f);
					this.Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					if (!this.Corpse.Concealed)
					{
						this.Corpse.Police.HiddenCorpses++;
					}
					this.Corpse.enabled = false;
					this.Corpse.Hidden = true;
					this.StudentID = this.Corpse.StudentID;
					if (this.ABC)
					{
						this.Corpse.DestroyRigidbodies();
					}
					else
					{
						this.Corpse.BloodSpawnerCollider.enabled = false;
						this.Corpse.Prompt.MyCollider.enabled = false;
						this.Corpse.BloodPoolSpawner.enabled = false;
						this.Corpse.DisableRigidbodies();
					}
					this.Corpse.Student.CharacterAnimation.enabled = true;
					this.Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
					this.Rotation = -180f;
					this.Outline.color = new Color(1f, 0.5f, 0f, 1f);
					return;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
		}
		else if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.Label[0].text = "     Hide Corpse";
			AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
			this.Corpse.enabled = true;
			this.Corpse.gameObject.SetActive(true);
			this.Corpse.CharacterAnimation.enabled = false;
			this.Corpse.transform.localPosition = new Vector3(0f, 0f, 0.5f);
			this.Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0.5f);
			this.Corpse.transform.parent = null;
			this.Corpse.BloodSpawnerCollider.enabled = true;
			this.Corpse.Prompt.MyCollider.enabled = true;
			this.Corpse.BloodPoolSpawner.NearbyBlood = 0;
			this.Corpse.AddingToCount = false;
			this.Corpse.EnableRigidbodies();
			if (!this.Corpse.Cauterized && !this.Corpse.Concealed)
			{
				this.Corpse.BloodPoolSpawner.enabled = true;
			}
			for (int i = 0; i < this.Corpse.Student.FireEmitters.Length; i++)
			{
				this.Corpse.Student.FireEmitters[i].gameObject.SetActive(false);
			}
			this.Corpse = null;
			this.Rotation = -180f;
			this.Outline.color = new Color(0f, 1f, 1f, 1f);
		}
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x0005C260 File Offset: 0x0005A460
	public void UpdateCorpse()
	{
		this.Corpse = this.StudentManager.Students[this.StudentID].Ragdoll;
		this.Corpse.transform.parent = base.transform;
		this.Prompt.Label[0].text = "     Remove Corpse";
		this.Prompt.enabled = true;
	}

	// Token: 0x04000BD2 RID: 3026
	public StudentManagerScript StudentManager;

	// Token: 0x04000BD3 RID: 3027
	public OutlineScript Outline;

	// Token: 0x04000BD4 RID: 3028
	public RagdollScript Corpse;

	// Token: 0x04000BD5 RID: 3029
	public PromptScript Prompt;

	// Token: 0x04000BD6 RID: 3030
	public AudioClip LockerClose;

	// Token: 0x04000BD7 RID: 3031
	public AudioClip LockerOpen;

	// Token: 0x04000BD8 RID: 3032
	public float Rotation;

	// Token: 0x04000BD9 RID: 3033
	public float Speed;

	// Token: 0x04000BDA RID: 3034
	public Transform Door;

	// Token: 0x04000BDB RID: 3035
	public int StudentID;

	// Token: 0x04000BDC RID: 3036
	public bool ABC;
}
