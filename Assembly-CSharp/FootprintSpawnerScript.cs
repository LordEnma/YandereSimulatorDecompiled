using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014A7 RID: 5287 RVA: 0x000CAC2C File Offset: 0x000C8E2C
	private void Start()
	{
		if (this.MyAudio == null)
		{
			this.MyAudio = base.GetComponent<AudioSource>();
		}
		this.GardenArea = this.Yandere.StudentManager.GardenArea;
		this.PoolStairs = this.Yandere.StudentManager.PoolStairs;
		this.TreeArea = this.Yandere.StudentManager.TreeArea;
		this.NEStairs = this.Yandere.StudentManager.NEStairs;
		this.NWStairs = this.Yandere.StudentManager.NWStairs;
		this.SEStairs = this.Yandere.StudentManager.SEStairs;
		this.SWStairs = this.Yandere.StudentManager.SWStairs;
	}

	// Token: 0x060014A8 RID: 5288 RVA: 0x000CACF0 File Offset: 0x000C8EF0
	private void Update()
	{
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
				return;
			}
		}
		else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold)
		{
			if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && !this.Yandere.NearSenpai && this.FootUp)
			{
				if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2)
				{
					if (this.Yandere.Running)
					{
						this.MyAudio.clip = this.RunBareFootsteps[UnityEngine.Random.Range(0, this.RunBareFootsteps.Length)];
						this.MyAudio.volume = 0.3f;
					}
					else
					{
						this.MyAudio.clip = this.WalkBareFootsteps[UnityEngine.Random.Range(0, this.WalkBareFootsteps.Length)];
						this.MyAudio.volume = 0.2f;
					}
				}
				else if (this.Yandere.Running)
				{
					this.MyAudio.clip = this.RunFootsteps[UnityEngine.Random.Range(0, this.RunFootsteps.Length)];
					this.MyAudio.volume = 0.15f;
				}
				else
				{
					this.MyAudio.clip = this.WalkFootsteps[UnityEngine.Random.Range(0, this.WalkFootsteps.Length)];
					this.MyAudio.volume = 0.1f;
				}
				this.MyAudio.Play();
			}
			this.FootUp = false;
			if (this.Bloodiness > 0)
			{
				this.CanSpawn = (!this.GardenArea.bounds.Contains(base.transform.position) && !this.PoolStairs.bounds.Contains(base.transform.position) && !this.TreeArea.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position));
				if (this.CanSpawn)
				{
					if (base.transform.position.y > -1f && base.transform.position.y < 1f)
					{
						this.Height = 0f;
					}
					else if (base.transform.position.y > 3f && base.transform.position.y < 5f)
					{
						this.Height = 4f;
					}
					else if (base.transform.position.y > 7f && base.transform.position.y < 9f)
					{
						this.Height = 8f;
					}
					else if (base.transform.position.y > 11f && base.transform.position.y < 13f)
					{
						this.Height = 12f;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(base.transform.position.x, this.Height + 0.012f, base.transform.position.z), Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
					gameObject.transform.parent = this.BloodParent;
					this.Bloodiness--;
				}
			}
		}
	}

	// Token: 0x0400204B RID: 8267
	public YandereScript Yandere;

	// Token: 0x0400204C RID: 8268
	public GameObject BloodyFootprint;

	// Token: 0x0400204D RID: 8269
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400204E RID: 8270
	public AudioClip[] RunFootsteps;

	// Token: 0x0400204F RID: 8271
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x04002050 RID: 8272
	public AudioClip[] RunBareFootsteps;

	// Token: 0x04002051 RID: 8273
	public AudioSource MyAudio;

	// Token: 0x04002052 RID: 8274
	public Transform BloodParent;

	// Token: 0x04002053 RID: 8275
	public Collider MyCollider;

	// Token: 0x04002054 RID: 8276
	public Collider GardenArea;

	// Token: 0x04002055 RID: 8277
	public Collider PoolStairs;

	// Token: 0x04002056 RID: 8278
	public Collider TreeArea;

	// Token: 0x04002057 RID: 8279
	public Collider NEStairs;

	// Token: 0x04002058 RID: 8280
	public Collider NWStairs;

	// Token: 0x04002059 RID: 8281
	public Collider SEStairs;

	// Token: 0x0400205A RID: 8282
	public Collider SWStairs;

	// Token: 0x0400205B RID: 8283
	public bool Debugging;

	// Token: 0x0400205C RID: 8284
	public bool CanSpawn;

	// Token: 0x0400205D RID: 8285
	public bool FootUp;

	// Token: 0x0400205E RID: 8286
	public float DownThreshold;

	// Token: 0x0400205F RID: 8287
	public float UpThreshold;

	// Token: 0x04002060 RID: 8288
	public float Height;

	// Token: 0x04002061 RID: 8289
	public int Bloodiness;

	// Token: 0x04002062 RID: 8290
	public int Collisions;
}
