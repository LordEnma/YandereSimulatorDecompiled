using System;
using UnityEngine;

// Token: 0x020002A3 RID: 675
public class EmergencyShowerScript : MonoBehaviour
{
	// Token: 0x0600141E RID: 5150 RVA: 0x000BFFA0 File Offset: 0x000BE1A0
	private void Update()
	{
		if (this.Yandere.Bloodiness > 0f && this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && !this.Yandere.PickUp.Evidence && this.Yandere.PickUp.Gloves == null)
		{
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
					this.Yandere.CannotBeSprayed = true;
					this.Yandere.CanMove = false;
					this.CleanUniform = this.Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>();
					this.Yandere.EmptyHands();
					this.CleanUniform.transform.position = base.transform.position + base.transform.up + base.transform.forward * 1.5f;
					AudioSource.PlayClipAtPoint(this.CurtainClose, base.transform.position);
					this.Bathing = true;
					this.Phase = 1;
					this.Timer = 0f;
				}
			}
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
		if (this.Bathing)
		{
			this.Timer += Time.deltaTime;
			if (this.Phase == 1)
			{
				this.Yandere.MoveTowardsTarget(this.BatheSpot.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.BatheSpot.rotation, 10f * Time.deltaTime);
				this.OpenValue = Mathf.Lerp(this.OpenValue, 0f, Time.deltaTime * 10f);
				this.Curtain.SetBlendShapeWeight(1, this.OpenValue);
				if (this.Timer > 1f)
				{
					PickUpScript component;
					if (this.Yandere.ClubAttire)
					{
						component = UnityEngine.Object.Instantiate<GameObject>(this.TallLocker.BloodyClubUniform[(int)this.Yandere.Club], this.Yandere.transform.position + this.Yandere.transform.forward + this.Yandere.transform.right * -0.5f, Quaternion.identity).GetComponent<PickUpScript>();
						this.Yandere.StudentManager.ChangingBooths[(int)this.Yandere.Club].CannotChange = true;
						this.Yandere.StudentManager.ChangingBooths[(int)this.Yandere.Club].CheckYandereClub();
					}
					else
					{
						component = UnityEngine.Object.Instantiate<GameObject>(this.TallLocker.BloodyUniform[this.Yandere.Schoolwear], this.Yandere.transform.position + this.Yandere.transform.forward + this.Yandere.transform.right * -0.5f, Quaternion.identity).GetComponent<PickUpScript>();
					}
					AudioSource.PlayClipAtPoint(this.ClothRustle, base.transform.position);
					if (this.Yandere.RedPaint)
					{
						component.RedPaint = true;
					}
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Timer > 2f)
				{
					this.CensorSteam.SetActive(true);
					this.MyAudio.Play();
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Timer > 6.5f)
				{
					this.CleanUniform.Prompt.Hide();
					UnityEngine.Object.Destroy(this.CleanUniform.gameObject);
					this.Yandere.StudentManager.NewUniforms--;
					this.Yandere.ClubAttire = false;
					this.Yandere.Schoolwear = 1;
					this.Yandere.ChangeSchoolwear();
					this.Yandere.Bloodiness = 0f;
					AudioSource.PlayClipAtPoint(this.ClothRustle, base.transform.position);
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Timer > 7.5f)
				{
					AudioSource.PlayClipAtPoint(this.CurtainOpen, base.transform.position);
					this.Phase++;
					return;
				}
			}
			else
			{
				this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
				this.Curtain.SetBlendShapeWeight(1, this.OpenValue);
				if (this.Timer > 8.5f)
				{
					this.CensorSteam.SetActive(false);
					this.Yandere.CannotBeSprayed = false;
					this.Yandere.CanMove = true;
					this.Bathing = false;
				}
			}
		}
	}

	// Token: 0x04001E3D RID: 7741
	public FoldedUniformScript CleanUniform;

	// Token: 0x04001E3E RID: 7742
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04001E3F RID: 7743
	public TallLockerScript TallLocker;

	// Token: 0x04001E40 RID: 7744
	public GameObject CensorSteam;

	// Token: 0x04001E41 RID: 7745
	public YandereScript Yandere;

	// Token: 0x04001E42 RID: 7746
	public PromptScript Prompt;

	// Token: 0x04001E43 RID: 7747
	public Transform BatheSpot;

	// Token: 0x04001E44 RID: 7748
	public float OpenValue;

	// Token: 0x04001E45 RID: 7749
	public float Timer;

	// Token: 0x04001E46 RID: 7750
	public int Phase = 1;

	// Token: 0x04001E47 RID: 7751
	public bool Bathing;

	// Token: 0x04001E48 RID: 7752
	public AudioSource MyAudio;

	// Token: 0x04001E49 RID: 7753
	public AudioClip CurtainClose;

	// Token: 0x04001E4A RID: 7754
	public AudioClip CurtainOpen;

	// Token: 0x04001E4B RID: 7755
	public AudioClip ClothRustle;
}
