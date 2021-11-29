using System;
using UnityEngine;

// Token: 0x020004B2 RID: 1202
public class WashingMachineScript : MonoBehaviour
{
	// Token: 0x06001F72 RID: 8050 RVA: 0x001B8B29 File Offset: 0x001B6D29
	private void Start()
	{
		this.Panel.SetActive(false);
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x001B8B38 File Offset: 0x001B6D38
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
							FoldedUniformScript component = this.ClothingList[i].GetComponent<FoldedUniformScript>();
							string str = "FoldedUniform is: ";
							FoldedUniformScript foldedUniformScript = component;
							Debug.Log(str + ((foldedUniformScript != null) ? foldedUniformScript.ToString() : null));
							if ((component != null && component.Type == 2) || (component != null && component.Type == 3))
							{
								Debug.Log("Yep, that was a gym uniform.");
								this.ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
								this.ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
								this.ClothingList[i].Evidence = false;
								component.CleanUp();
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

	// Token: 0x04004184 RID: 16772
	public GameObject CleanUniform;

	// Token: 0x04004185 RID: 16773
	public GameObject Colliders;

	// Token: 0x04004186 RID: 16774
	public GameObject Panel;

	// Token: 0x04004187 RID: 16775
	public AudioSource MyAudio;

	// Token: 0x04004188 RID: 16776
	public AudioClip OpenSFX;

	// Token: 0x04004189 RID: 16777
	public AudioClip ShutSFX;

	// Token: 0x0400418A RID: 16778
	public AudioClip WashSFX;

	// Token: 0x0400418B RID: 16779
	public PromptScript Prompt;

	// Token: 0x0400418C RID: 16780
	public Transform Tumbler;

	// Token: 0x0400418D RID: 16781
	public Transform Door;

	// Token: 0x0400418E RID: 16782
	public UILabel TimeLabel;

	// Token: 0x0400418F RID: 16783
	public UISprite Circle;

	// Token: 0x04004190 RID: 16784
	public float AnimationTimer;

	// Token: 0x04004191 RID: 16785
	public float WashTimer;

	// Token: 0x04004192 RID: 16786
	public float Rotation;

	// Token: 0x04004193 RID: 16787
	public float Speed;

	// Token: 0x04004194 RID: 16788
	public bool Washing;

	// Token: 0x04004195 RID: 16789
	public bool Open;

	// Token: 0x04004196 RID: 16790
	public PickUpScript[] ClothingList;

	// Token: 0x04004197 RID: 16791
	public int ClothingInMachine;
}
