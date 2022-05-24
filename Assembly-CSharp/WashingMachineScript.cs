using System;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
public class WashingMachineScript : MonoBehaviour
{
	// Token: 0x06001FE6 RID: 8166 RVA: 0x001C3C99 File Offset: 0x001C1E99
	private void Start()
	{
		this.Panel.SetActive(false);
	}

	// Token: 0x06001FE7 RID: 8167 RVA: 0x001C3CA8 File Offset: 0x001C1EA8
	private void Update()
	{
		if (!this.Washing)
		{
			if (this.Prompt != null && this.Prompt.Yandere != null)
			{
				if (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.Clothing && this.Prompt.Yandere.PickUp.Evidence)
				{
					this.Prompt.HideButton[3] = false;
				}
				else
				{
					this.Prompt.HideButton[3] = true;
				}
			}
		}
		else
		{
			this.Tumbler.Rotate(0f, 0f, 360f * Time.deltaTime, Space.Self);
			this.WashTimer -= Time.deltaTime;
			this.Circle.fillAmount = 1f - this.WashTimer / 60f;
			float num = (float)Mathf.CeilToInt(this.WashTimer * 60f);
			float num2 = Mathf.Floor(num / 60f);
			float num3 = (float)Mathf.RoundToInt(num % 60f);
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", num2, num3);
			if (this.WashTimer <= 0f)
			{
				for (int i = 0; i < this.ClothingList.Length; i++)
				{
					if (this.ClothingList[i] != null)
					{
						if (this.ClothingList[i].gameObject.name == "Raincoat" || this.ClothingList[i].gameObject.name == "SilkGloves")
						{
							this.ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
							this.ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
							this.ClothingList[i].Evidence = false;
							this.ClothingList[i].gameObject.GetComponent<GloveScript>().Blood.enabled = false;
							if (this.ClothingList[i].gameObject.name == "Raincoat")
							{
								this.Prompt.Yandere.CoatBloodiness = 0f;
							}
							else
							{
								this.Prompt.Yandere.GloveAttacher.newRenderer.material.mainTexture = this.Prompt.Yandere.GloveTexture;
							}
							OutlineScript component = this.ClothingList[i].GetComponent<OutlineScript>();
							if (component != null)
							{
								component.color = new Color(0f, 1f, 1f, 1f);
							}
						}
						else if (this.ClothingList[i].gameObject.name == "Mask")
						{
							this.ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
							this.ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
							this.ClothingList[i].Evidence = false;
							this.ClothingList[i].gameObject.GetComponent<MaskScript>().Blood.enabled = false;
						}
						else
						{
							if (this.ClothingList[i].RedPaint)
							{
								this.Prompt.Yandere.Police.RedPaintClothing--;
								this.ClothingList[i].RedPaint = false;
							}
							FoldedUniformScript component2 = this.ClothingList[i].GetComponent<FoldedUniformScript>();
							string str = "FoldedUniform is: ";
							FoldedUniformScript foldedUniformScript = component2;
							Debug.Log(str + ((foldedUniformScript != null) ? foldedUniformScript.ToString() : null));
							if ((component2 != null && component2.Type == 2) || (component2 != null && component2.Type == 3) || (component2 != null && component2.ClubAttire))
							{
								Debug.Log("The player put something into the washing machine that was not a regular school uniform.");
								this.ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
								this.ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
								this.ClothingList[i].Evidence = false;
								component2.CleanUp();
							}
							else
							{
								UnityEngine.Object.Instantiate<GameObject>(this.CleanUniform, base.transform.position + new Vector3(0f, 0.6f, -0.66666f), Quaternion.identity);
								UnityEngine.Object.Destroy(this.ClothingList[i].gameObject);
							}
						}
						this.Prompt.Yandere.Police.BloodyClothing--;
						this.ClothingList[i] = null;
					}
				}
				this.Prompt.Yandere.StudentManager.OriginalUniforms += this.ClothingInMachine;
				this.ClothingInMachine = 0;
				this.Colliders.SetActive(false);
				this.Panel.SetActive(false);
				this.Washing = false;
				this.MyAudio.clip = this.OpenSFX;
				this.MyAudio.loop = false;
				this.MyAudio.Play();
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			this.ClothingList[this.ClothingInMachine] = this.Prompt.Yandere.PickUp;
			this.Prompt.Yandere.EmptyHands();
			if (this.ClothingList[this.ClothingInMachine].gameObject.name == "Raincoat")
			{
				this.ClothingList[this.ClothingInMachine].transform.position = base.transform.position + new Vector3(0f, 0.475f, 0.11f);
				this.ClothingList[this.ClothingInMachine].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			}
			else
			{
				this.ClothingList[this.ClothingInMachine].transform.position = base.transform.position + new Vector3(0f, 0.6f, 0.1f);
			}
			this.ClothingList[this.ClothingInMachine].MyRigidbody.isKinematic = false;
			this.ClothingList[this.ClothingInMachine].MyRigidbody.useGravity = true;
			this.ClothingList[this.ClothingInMachine].KeepGravity = true;
			this.ClothingInMachine++;
			this.Colliders.SetActive(true);
			this.AnimationTimer = 2f;
			this.Speed = 0f;
			this.Open = true;
			this.Prompt.HideButton[0] = false;
			this.MyAudio.clip = this.OpenSFX;
			this.MyAudio.loop = false;
			this.MyAudio.Play();
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.AnimationTimer <= 0f)
			{
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = true;
				this.Panel.SetActive(true);
				this.WashTimer = 60f;
				this.Washing = true;
				this.MyAudio.clip = this.WashSFX;
				this.MyAudio.loop = true;
				this.MyAudio.Play();
			}
		}
		if (this.AnimationTimer > 0f)
		{
			this.AnimationTimer -= Time.deltaTime;
			if (this.AnimationTimer < 1f)
			{
				this.Open = false;
			}
			if (this.Open)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 125f, Time.deltaTime * 10f);
			}
			else
			{
				this.Speed += Time.deltaTime * 360f;
				this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, Time.deltaTime * this.Speed);
				if (this.Rotation == 0f && this.MyAudio.clip != this.ShutSFX)
				{
					this.MyAudio.clip = this.ShutSFX;
					this.MyAudio.loop = false;
					this.MyAudio.Play();
				}
			}
			this.Door.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
	}

	// Token: 0x040042E1 RID: 17121
	public GameObject CleanUniform;

	// Token: 0x040042E2 RID: 17122
	public GameObject Colliders;

	// Token: 0x040042E3 RID: 17123
	public GameObject Panel;

	// Token: 0x040042E4 RID: 17124
	public AudioSource MyAudio;

	// Token: 0x040042E5 RID: 17125
	public AudioClip OpenSFX;

	// Token: 0x040042E6 RID: 17126
	public AudioClip ShutSFX;

	// Token: 0x040042E7 RID: 17127
	public AudioClip WashSFX;

	// Token: 0x040042E8 RID: 17128
	public PromptScript Prompt;

	// Token: 0x040042E9 RID: 17129
	public Transform Tumbler;

	// Token: 0x040042EA RID: 17130
	public Transform Door;

	// Token: 0x040042EB RID: 17131
	public UILabel TimeLabel;

	// Token: 0x040042EC RID: 17132
	public UISprite Circle;

	// Token: 0x040042ED RID: 17133
	public float AnimationTimer;

	// Token: 0x040042EE RID: 17134
	public float WashTimer;

	// Token: 0x040042EF RID: 17135
	public float Rotation;

	// Token: 0x040042F0 RID: 17136
	public float Speed;

	// Token: 0x040042F1 RID: 17137
	public bool Washing;

	// Token: 0x040042F2 RID: 17138
	public bool Open;

	// Token: 0x040042F3 RID: 17139
	public PickUpScript[] ClothingList;

	// Token: 0x040042F4 RID: 17140
	public int ClothingInMachine;
}
