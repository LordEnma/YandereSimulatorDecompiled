using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DemonScript : MonoBehaviour
{
	// Token: 0x06001385 RID: 4997 RVA: 0x000B3F64 File Offset: 0x000B2164
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			this.Communing = true;
		}
		if (this.DemonID == 1)
		{
			if ((double)Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 2.5)
			{
				if (!this.Open)
				{
					AudioSource.PlayClipAtPoint(this.MouthOpen, base.transform.position);
				}
				this.Open = true;
			}
			else
			{
				if (this.Open)
				{
					AudioSource.PlayClipAtPoint(this.MouthClose, base.transform.position);
				}
				this.Open = false;
			}
			if (this.Open)
			{
				this.Value = Mathf.Lerp(this.Value, 100f, Time.deltaTime * 10f);
			}
			else
			{
				this.Value = Mathf.Lerp(this.Value, 0f, Time.deltaTime * 10f);
			}
			this.Face.SetBlendShapeWeight(0, this.Value);
		}
		if (this.Communing)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.Phase == 1)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					this.DemonSubtitle.transform.localPosition = Vector3.zero;
					this.DemonSubtitle.text = this.Lines[this.ID];
					this.DemonSubtitle.color = this.MyColor;
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Phase++;
					if (this.Clips[this.ID] != null)
					{
						component.clip = this.Clips[this.ID];
						component.Play();
						return;
					}
				}
			}
			else if (this.Phase == 2)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a > 0.9f && Input.GetButtonDown("A"))
				{
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
				{
					this.ID++;
					if (this.ID >= this.Lines.Length)
					{
						this.Phase++;
						return;
					}
					this.Phase--;
					this.DemonSubtitle.text = this.Lines[this.ID];
					if (this.Clips[this.ID] != null)
					{
						component.clip = this.Clips[this.ID];
						component.Play();
						return;
					}
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.CanMove = true;
					this.Communing = false;
					this.Phase = 1;
					this.ID = 0;
					SchoolGlobals.SetDemonActive(this.DemonID, true);
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					GameGlobals.Paranormal = true;
				}
			}
		}
	}

	// Token: 0x04001CD8 RID: 7384
	public SkinnedMeshRenderer Face;

	// Token: 0x04001CD9 RID: 7385
	public YandereScript Yandere;

	// Token: 0x04001CDA RID: 7386
	public PromptScript Prompt;

	// Token: 0x04001CDB RID: 7387
	public UILabel DemonSubtitle;

	// Token: 0x04001CDC RID: 7388
	public UISprite Darkness;

	// Token: 0x04001CDD RID: 7389
	public UISprite Button;

	// Token: 0x04001CDE RID: 7390
	public AudioClip MouthOpen;

	// Token: 0x04001CDF RID: 7391
	public AudioClip MouthClose;

	// Token: 0x04001CE0 RID: 7392
	public AudioClip[] Clips;

	// Token: 0x04001CE1 RID: 7393
	public string[] Lines;

	// Token: 0x04001CE2 RID: 7394
	public bool Communing;

	// Token: 0x04001CE3 RID: 7395
	public bool Open;

	// Token: 0x04001CE4 RID: 7396
	public float Intensity = 1f;

	// Token: 0x04001CE5 RID: 7397
	public float Value;

	// Token: 0x04001CE6 RID: 7398
	public Color MyColor;

	// Token: 0x04001CE7 RID: 7399
	public int DemonID;

	// Token: 0x04001CE8 RID: 7400
	public int Phase = 1;

	// Token: 0x04001CE9 RID: 7401
	public int ID;
}
