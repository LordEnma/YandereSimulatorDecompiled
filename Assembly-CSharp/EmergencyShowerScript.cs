using System;
using UnityEngine;

// Token: 0x0200029F RID: 671
public class EmergencyShowerScript : MonoBehaviour
{
	// Token: 0x06001406 RID: 5126 RVA: 0x000BE9F8 File Offset: 0x000BCBF8
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
					this.CleanUniform.transform.position = new Vector3(26.25f, 5f, -8f);
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
						component = UnityEngine.Object.Instantiate<GameObject>(this.TallLocker.BloodyClubUniform[(int)this.Yandere.Club], new Vector3(25.75f, 5f, -8f), Quaternion.identity).GetComponent<PickUpScript>();
						this.Yandere.StudentManager.ChangingBooths[(int)this.Yandere.Club].CannotChange = true;
						this.Yandere.StudentManager.ChangingBooths[(int)this.Yandere.Club].CheckYandereClub();
					}
					else
					{
						component = UnityEngine.Object.Instantiate<GameObject>(this.TallLocker.BloodyUniform[this.Yandere.Schoolwear], new Vector3(25.75f, 5f, -8f), Quaternion.identity).GetComponent<PickUpScript>();
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

	// Token: 0x04001DF5 RID: 7669
	public FoldedUniformScript CleanUniform;

	// Token: 0x04001DF6 RID: 7670
	public SkinnedMeshRenderer Curtain;

	// Token: 0x04001DF7 RID: 7671
	public TallLockerScript TallLocker;

	// Token: 0x04001DF8 RID: 7672
	public GameObject CensorSteam;

	// Token: 0x04001DF9 RID: 7673
	public YandereScript Yandere;

	// Token: 0x04001DFA RID: 7674
	public PromptScript Prompt;

	// Token: 0x04001DFB RID: 7675
	public Transform BatheSpot;

	// Token: 0x04001DFC RID: 7676
	public float OpenValue;

	// Token: 0x04001DFD RID: 7677
	public float Timer;

	// Token: 0x04001DFE RID: 7678
	public int Phase = 1;

	// Token: 0x04001DFF RID: 7679
	public bool Bathing;

	// Token: 0x04001E00 RID: 7680
	public AudioSource MyAudio;

	// Token: 0x04001E01 RID: 7681
	public AudioClip CurtainClose;

	// Token: 0x04001E02 RID: 7682
	public AudioClip CurtainOpen;

	// Token: 0x04001E03 RID: 7683
	public AudioClip ClothRustle;
}
