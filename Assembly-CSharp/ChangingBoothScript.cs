using System;
using UnityEngine;

// Token: 0x0200023D RID: 573
public class ChangingBoothScript : MonoBehaviour
{
	// Token: 0x06001239 RID: 4665 RVA: 0x0008BC3A File Offset: 0x00089E3A
	private void Start()
	{
		this.CheckYandereClub();
	}

	// Token: 0x0600123A RID: 4666 RVA: 0x0008BC44 File Offset: 0x00089E44
	private void Update()
	{
		if (!this.Occupied && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
			this.YandereChanging = true;
			this.Occupied = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Occupied)
		{
			if (this.OccupyTimer == 0f)
			{
				if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
				{
					this.MyAudioSource.clip = this.CurtainSound;
					this.MyAudioSource.Play();
				}
			}
			else if (this.OccupyTimer > 1f && this.Phase == 0)
			{
				if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
				{
					this.MyAudioSource.clip = this.ClothSound;
					this.MyAudioSource.Play();
				}
				this.Phase++;
			}
			this.OccupyTimer += Time.deltaTime;
			if (this.YandereChanging)
			{
				if (this.OccupyTimer < 2f)
				{
					this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
					this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					this.Yandere.MoveTowardsTarget(base.transform.position);
					return;
				}
				if (this.OccupyTimer < 3f)
				{
					this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					if (this.Phase < 2)
					{
						this.MyAudioSource.clip = this.CurtainSound;
						this.MyAudioSource.Play();
						if (!this.Yandere.ClubAttire)
						{
							this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
						}
						this.Yandere.ChangeClubwear();
						this.Phase++;
					}
					this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, base.transform.rotation, 10f * Time.deltaTime);
					this.Yandere.MoveTowardsTarget(this.ExitSpot.position);
					return;
				}
				this.YandereChanging = false;
				this.Yandere.CanMove = true;
				this.Prompt.enabled = true;
				this.Occupied = false;
				this.OccupyTimer = 0f;
				this.Phase = 0;
				return;
			}
			else
			{
				if (this.OccupyTimer < 2f)
				{
					this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					return;
				}
				if (this.OccupyTimer < 3f)
				{
					this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					if (this.Phase < 2)
					{
						if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
						{
							this.MyAudioSource.clip = this.CurtainSound;
							this.MyAudioSource.Play();
						}
						this.Student.ChangeClubwear();
						this.Phase++;
						return;
					}
				}
				else
				{
					this.Student.WalkAnim = this.Student.OriginalWalkAnim;
					this.Occupied = false;
					this.OccupyTimer = 0f;
					this.Student = null;
					this.Phase = 0;
					this.CheckYandereClub();
				}
			}
		}
	}

	// Token: 0x0600123B RID: 4667 RVA: 0x0008C104 File Offset: 0x0008A304
	public void CheckYandereClub()
	{
		if (this.Yandere.Club != this.ClubID)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			return;
		}
		if (this.Yandere.Bloodiness != 0f || this.CannotChange || this.Yandere.Schoolwear <= 0)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			return;
		}
		if (!this.Occupied)
		{
			this.Prompt.enabled = true;
			return;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x040016E6 RID: 5862
	public YandereScript Yandere;

	// Token: 0x040016E7 RID: 5863
	public StudentScript Student;

	// Token: 0x040016E8 RID: 5864
	public PromptScript Prompt;

	// Token: 0x040016E9 RID: 5865
	public SkinnedMeshRenderer Curtains;

	// Token: 0x040016EA RID: 5866
	public Transform ExitSpot;

	// Token: 0x040016EB RID: 5867
	public Transform[] WaitSpots;

	// Token: 0x040016EC RID: 5868
	public bool YandereChanging;

	// Token: 0x040016ED RID: 5869
	public bool CannotChange;

	// Token: 0x040016EE RID: 5870
	public bool Occupied;

	// Token: 0x040016EF RID: 5871
	public AudioSource MyAudioSource;

	// Token: 0x040016F0 RID: 5872
	public AudioClip CurtainSound;

	// Token: 0x040016F1 RID: 5873
	public AudioClip ClothSound;

	// Token: 0x040016F2 RID: 5874
	public float OccupyTimer;

	// Token: 0x040016F3 RID: 5875
	public float Weight;

	// Token: 0x040016F4 RID: 5876
	public ClubType ClubID;

	// Token: 0x040016F5 RID: 5877
	public int Phase;
}
