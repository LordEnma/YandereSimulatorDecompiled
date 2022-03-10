using System;
using UnityEngine;

// Token: 0x02000311 RID: 785
public class HenshinScript : MonoBehaviour
{
	// Token: 0x06001851 RID: 6225 RVA: 0x000EA120 File Offset: 0x000E8320
	public void TransformYandere()
	{
		this.TransformingYandere = true;
		this.Cameras[1].SetActive(false);
		this.Cameras[2].SetActive(false);
		this.Cameras[3].SetActive(false);
		this.Cameras[4].SetActive(false);
		this.Cameras[5].SetActive(false);
		this.Cameras[6].SetActive(false);
		this.MiyukiCamera.targetTexture = null;
		this.MiyukiCamera.enabled = true;
		this.Listener.enabled = true;
		this.OriginalPosition = this.Yandere.transform.position;
		this.OriginalRotation = this.Yandere.transform.rotation;
		this.Yandere.CharacterAnimation.Play("f02_henshin_00");
		this.Yandere.transform.parent = this.Miyuki;
		this.Yandere.enabled = false;
		this.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
		this.Yandere.Accessories[this.Yandere.AccessoryID].SetActive(false);
		Physics.SyncTransforms();
		AudioSource.PlayClipAtPoint(this.Catchphrase, base.transform.position);
		this.MyAudio.Play();
		this.Start();
	}

	// Token: 0x06001852 RID: 6226 RVA: 0x000EA2A4 File Offset: 0x000E84A4
	private void Start()
	{
		if (this.OriginalMesh == null)
		{
			this.OriginalMesh = this.MiyukiRenderer.sharedMesh;
			this.OriginalFace = this.MiyukiRenderer.materials[0].mainTexture;
			this.OriginalBody = this.MiyukiRenderer.materials[1].mainTexture;
		}
		this.MiyukiRenderer.sharedMesh = this.OriginalMesh;
		this.MiyukiRenderer.materials[0].mainTexture = this.OriginalFace;
		this.MiyukiRenderer.materials[1].mainTexture = this.OriginalBody;
		this.MiyukiRenderer.materials[2].mainTexture = this.OriginalBody;
		this.MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, 0f);
		this.WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, 0f);
		this.WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
		this.WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, 0f);
		this.Wand.gameObject.SetActive(true);
		this.Wand.transform.parent = base.transform.parent;
		this.Wand.localPosition = new Vector3(0f, -0.6538f, 0.04405f);
		this.White.material.color = new Color(1f, 1f, 1f, 1f);
		this.Miyuki.gameObject.SetActive(false);
		if (this.MiyukiCostume.newRenderer != null)
		{
			this.MiyukiCostume.newRenderer.enabled = false;
		}
		this.HenshinSparkleBlast.SetActive(false);
		this.HenshinSparkles.emissionRate = 1f;
		this.HenshinSparkles.Clear();
		this.HenshinSparkles.Stop();
		this.SpinSparkles.Clear();
		this.SpinSparkles.Stop();
		this.Sparkles.emissionRate = 1f;
		this.Sparkles.startSize = 0.1f;
		this.Sparkles.Clear();
		this.Sparkles.Stop();
		this.Rotation = 3600f;
		this.Timer = 0f;
		this.Phase = 1;
		if (this.Debugging)
		{
			Time.timeScale = 1f;
		}
	}

	// Token: 0x06001853 RID: 6227 RVA: 0x000EA55C File Offset: 0x000E875C
	private void Update()
	{
		if (this.TransformingYandere && Input.GetKeyDown("="))
		{
			AudioSource myAudio = this.MyAudio;
			float pitch = myAudio.pitch;
			myAudio.pitch = pitch + 1f;
			Time.timeScale += 1f;
		}
		if (this.TransformingYandere || Vector3.Distance(this.Yandere.transform.position, this.TV.position) < 15f)
		{
			this.MiyukiCamera.enabled = true;
			if (this.Phase < 3)
			{
				this.Wand.localPosition = Vector3.Lerp(this.Wand.localPosition, new Vector3(0f, -0.2833333f, 1f), Time.deltaTime);
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 2f);
				this.Wand.localEulerAngles = new Vector3(-90f, 0f, this.Rotation);
			}
			if (this.Phase == 1)
			{
				this.White.material.color -= new Color(0f, 0f, 0f, Time.deltaTime);
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					this.White.material.color = new Color(1f, 1f, 1f, 0f);
					this.Timer = 0f;
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 2)
			{
				if (!this.Sparkles.isPlaying)
				{
					this.Sparkles.Play();
				}
				this.Sparkles.startSize += Time.deltaTime * 0.25f;
				this.Sparkles.emissionRate += Time.deltaTime * 5f;
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					this.White.material.color += new Color(1f, 1f, 1f, Time.deltaTime);
					if (this.White.material.color.a >= 1f)
					{
						this.Miyuki.localEulerAngles = new Vector3(0f, 180f, 45f);
						this.Miyuki.localPosition = new Vector3(0f, 0f, 0.5f);
						this.Miyuki.gameObject.SetActive(true);
						this.Wand.gameObject.SetActive(false);
						if (this.TransformingYandere)
						{
							this.MiyukiHairRenderer.enabled = false;
							this.MiyukiRenderer.enabled = false;
							this.MiyukiHair.SetActive(false);
							this.Yandere.CharacterAnimation.Play("f02_henshin_00");
						}
						this.Sparkles.emissionRate = 1f;
						this.Sparkles.startSize = 0.1f;
						this.Sparkles.Clear();
						this.Sparkles.Stop();
						this.Timer = 0f;
						this.Phase++;
						return;
					}
				}
			}
			else if (this.Phase == 3)
			{
				this.White.material.color -= new Color(0f, 0f, 0f, Time.deltaTime);
				this.Miyuki.localPosition -= new Vector3(Time.deltaTime * 0.1f, Time.deltaTime * 0.1f, 0f);
				this.Rotation += Time.deltaTime;
				this.Miyuki.Rotate(0f, this.Rotation * 360f * Time.deltaTime, 0f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 2f)
				{
					if (!this.TransformingYandere)
					{
						float a = this.Timer - 2f;
						this.MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, a);
						this.WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, a);
						this.WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, a);
						this.WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, a);
					}
					if (this.Timer > 5f)
					{
						this.Miyuki.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Miyuki.localPosition = new Vector3(0f, -0.795f, 2f);
						this.Timer = 0f;
						this.Phase++;
						return;
					}
				}
			}
			else if (this.Phase == 4)
			{
				this.Miyuki.Rotate(0f, this.Rotation * 360f * Time.deltaTime, 0f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					if (!this.HenshinSparkles.isPlaying)
					{
						this.HenshinSparkles.Play();
					}
					this.HenshinSparkles.emissionRate += Time.deltaTime * 100f;
					if (this.Timer > 5f)
					{
						this.Wand.gameObject.SetActive(true);
						this.Wand.parent = this.RightHand;
						this.Wand.localEulerAngles = new Vector3(0f, 0f, 90f);
						this.Wand.localPosition = new Vector3(0f, 0f, 0f);
						if (this.TransformingYandere)
						{
							this.MiyukiRenderer.enabled = true;
							this.Yandere.gameObject.SetActive(false);
						}
						this.MiyukiCostume.gameObject.SetActive(true);
						this.MiyukiHair.SetActive(true);
						if (this.MiyukiCostume.newRenderer != null)
						{
							this.MiyukiCostume.newRenderer.enabled = true;
						}
						this.MiyukiRenderer.sharedMesh = this.NudeMesh;
						this.MiyukiRenderer.materials[0].mainTexture = this.MiyukiFace;
						this.MiyukiRenderer.materials[1].mainTexture = this.MiyukiSkin;
						this.MiyukiRenderer.materials[2].mainTexture = this.MiyukiSkin;
						this.MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, 0f);
						this.WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, 0f);
						this.WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
						this.WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, 0f);
						this.Miyuki.localEulerAngles = new Vector3(15f, -135f, 15f);
						this.WhiteMiyukiAnim.Play("f02_miyukiPose_00");
						this.MiyukiAnim.Play("f02_miyukiPose_00");
						this.HenshinSparkleBlast.SetActive(true);
						this.HenshinSparkles.emissionRate = 1f;
						this.HenshinSparkles.Clear();
						this.HenshinSparkles.Stop();
						this.SpinSparkles.Clear();
						this.SpinSparkles.Stop();
						this.Timer = 0f;
						this.Phase++;
						return;
					}
				}
			}
			else if (this.Phase == 5)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.White.material.color += new Color(0f, 0f, 0f, Time.deltaTime);
					if (this.White.material.color.a >= 1f)
					{
						if (this.TransformingYandere)
						{
							this.Cameras[1].SetActive(true);
							this.Cameras[2].SetActive(true);
							this.Cameras[3].SetActive(true);
							this.Cameras[4].SetActive(true);
							this.Cameras[5].SetActive(true);
							this.Cameras[6].SetActive(true);
							base.gameObject.SetActive(false);
							this.Yandere.transform.parent = null;
							this.Yandere.gameObject.SetActive(true);
							this.Yandere.transform.position = this.OriginalPosition;
							this.Yandere.transform.rotation = this.OriginalRotation;
							this.Yandere.Stance.Current = StanceType.Standing;
							this.Yandere.WeaponManager.Weapons[19].AnimID = 0;
							this.Yandere.SetAnimationLayers();
							this.Yandere.enabled = true;
							this.Yandere.CanMove = true;
							this.Yandere.Miyuki();
							base.transform.parent.gameObject.SetActive(false);
							Time.timeScale = 1f;
							return;
						}
						this.Start();
						return;
					}
				}
			}
		}
		else
		{
			this.MiyukiCamera.enabled = false;
		}
	}

	// Token: 0x040023FB RID: 9211
	public RiggedAccessoryAttacher MiyukiCostume;

	// Token: 0x040023FC RID: 9212
	public SkinnedMeshRenderer MiyukiRenderer;

	// Token: 0x040023FD RID: 9213
	public Renderer WhiteMiyukiRenderer;

	// Token: 0x040023FE RID: 9214
	public Renderer MiyukiHairRenderer;

	// Token: 0x040023FF RID: 9215
	public Renderer White;

	// Token: 0x04002400 RID: 9216
	public Animation WhiteMiyukiAnim;

	// Token: 0x04002401 RID: 9217
	public Animation MiyukiAnim;

	// Token: 0x04002402 RID: 9218
	public GameObject HenshinSparkleBlast;

	// Token: 0x04002403 RID: 9219
	public GameObject MiyukiHair;

	// Token: 0x04002404 RID: 9220
	public ParticleSystem HenshinSparkles;

	// Token: 0x04002405 RID: 9221
	public ParticleSystem SpinSparkles;

	// Token: 0x04002406 RID: 9222
	public ParticleSystem Sparkles;

	// Token: 0x04002407 RID: 9223
	public AudioListener Listener;

	// Token: 0x04002408 RID: 9224
	public YandereScript Yandere;

	// Token: 0x04002409 RID: 9225
	public GameObject[] Cameras;

	// Token: 0x0400240A RID: 9226
	public Camera MiyukiCamera;

	// Token: 0x0400240B RID: 9227
	public Transform RightHand;

	// Token: 0x0400240C RID: 9228
	public Transform Miyuki;

	// Token: 0x0400240D RID: 9229
	public Transform Wand;

	// Token: 0x0400240E RID: 9230
	public Transform TV;

	// Token: 0x0400240F RID: 9231
	public float Rotation;

	// Token: 0x04002410 RID: 9232
	public float Timer;

	// Token: 0x04002411 RID: 9233
	public int Phase;

	// Token: 0x04002412 RID: 9234
	public Texture MiyukiFace;

	// Token: 0x04002413 RID: 9235
	public Texture MiyukiSkin;

	// Token: 0x04002414 RID: 9236
	public Mesh NudeMesh;

	// Token: 0x04002415 RID: 9237
	public Texture OriginalBody;

	// Token: 0x04002416 RID: 9238
	public Texture OriginalFace;

	// Token: 0x04002417 RID: 9239
	public Mesh OriginalMesh;

	// Token: 0x04002418 RID: 9240
	public bool TransformingYandere;

	// Token: 0x04002419 RID: 9241
	public bool Debugging;

	// Token: 0x0400241A RID: 9242
	public Quaternion OriginalRotation;

	// Token: 0x0400241B RID: 9243
	public Vector3 OriginalPosition;

	// Token: 0x0400241C RID: 9244
	public AudioSource MyAudio;

	// Token: 0x0400241D RID: 9245
	public AudioClip Catchphrase;
}
