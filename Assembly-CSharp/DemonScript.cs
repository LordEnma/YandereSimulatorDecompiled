using System;
using UnityEngine;

// Token: 0x0200027D RID: 637
public class DemonScript : MonoBehaviour
{
	// Token: 0x06001376 RID: 4982 RVA: 0x000B2CB8 File Offset: 0x000B0EB8
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

	// Token: 0x04001CA2 RID: 7330
	public SkinnedMeshRenderer Face;

	// Token: 0x04001CA3 RID: 7331
	public YandereScript Yandere;

	// Token: 0x04001CA4 RID: 7332
	public PromptScript Prompt;

	// Token: 0x04001CA5 RID: 7333
	public UILabel DemonSubtitle;

	// Token: 0x04001CA6 RID: 7334
	public UISprite Darkness;

	// Token: 0x04001CA7 RID: 7335
	public UISprite Button;

	// Token: 0x04001CA8 RID: 7336
	public AudioClip MouthOpen;

	// Token: 0x04001CA9 RID: 7337
	public AudioClip MouthClose;

	// Token: 0x04001CAA RID: 7338
	public AudioClip[] Clips;

	// Token: 0x04001CAB RID: 7339
	public string[] Lines;

	// Token: 0x04001CAC RID: 7340
	public bool Communing;

	// Token: 0x04001CAD RID: 7341
	public bool Open;

	// Token: 0x04001CAE RID: 7342
	public float Intensity = 1f;

	// Token: 0x04001CAF RID: 7343
	public float Value;

	// Token: 0x04001CB0 RID: 7344
	public Color MyColor;

	// Token: 0x04001CB1 RID: 7345
	public int DemonID;

	// Token: 0x04001CB2 RID: 7346
	public int Phase = 1;

	// Token: 0x04001CB3 RID: 7347
	public int ID;
}
