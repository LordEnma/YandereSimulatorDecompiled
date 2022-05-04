using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014C8 RID: 5320 RVA: 0x000CCAF0 File Offset: 0x000CACF0
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

	// Token: 0x060014C9 RID: 5321 RVA: 0x000CCBB4 File Offset: 0x000CADB4
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
				if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || (this.Yandere.ClubAttire && this.Yandere.Club == ClubType.MartialArts))
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

	// Token: 0x04002093 RID: 8339
	public YandereScript Yandere;

	// Token: 0x04002094 RID: 8340
	public GameObject BloodyFootprint;

	// Token: 0x04002095 RID: 8341
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002096 RID: 8342
	public AudioClip[] RunFootsteps;

	// Token: 0x04002097 RID: 8343
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x04002098 RID: 8344
	public AudioClip[] RunBareFootsteps;

	// Token: 0x04002099 RID: 8345
	public AudioSource MyAudio;

	// Token: 0x0400209A RID: 8346
	public Transform BloodParent;

	// Token: 0x0400209B RID: 8347
	public Collider MyCollider;

	// Token: 0x0400209C RID: 8348
	public Collider GardenArea;

	// Token: 0x0400209D RID: 8349
	public Collider PoolStairs;

	// Token: 0x0400209E RID: 8350
	public Collider TreeArea;

	// Token: 0x0400209F RID: 8351
	public Collider NEStairs;

	// Token: 0x040020A0 RID: 8352
	public Collider NWStairs;

	// Token: 0x040020A1 RID: 8353
	public Collider SEStairs;

	// Token: 0x040020A2 RID: 8354
	public Collider SWStairs;

	// Token: 0x040020A3 RID: 8355
	public bool Debugging;

	// Token: 0x040020A4 RID: 8356
	public bool CanSpawn;

	// Token: 0x040020A5 RID: 8357
	public bool FootUp;

	// Token: 0x040020A6 RID: 8358
	public float DownThreshold;

	// Token: 0x040020A7 RID: 8359
	public float UpThreshold;

	// Token: 0x040020A8 RID: 8360
	public float Height;

	// Token: 0x040020A9 RID: 8361
	public int Bloodiness;

	// Token: 0x040020AA RID: 8362
	public int Collisions;
}
