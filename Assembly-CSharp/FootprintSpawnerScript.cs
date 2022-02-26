using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014B6 RID: 5302 RVA: 0x000CBB64 File Offset: 0x000C9D64
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

	// Token: 0x060014B7 RID: 5303 RVA: 0x000CBC28 File Offset: 0x000C9E28
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

	// Token: 0x04002067 RID: 8295
	public YandereScript Yandere;

	// Token: 0x04002068 RID: 8296
	public GameObject BloodyFootprint;

	// Token: 0x04002069 RID: 8297
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400206A RID: 8298
	public AudioClip[] RunFootsteps;

	// Token: 0x0400206B RID: 8299
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x0400206C RID: 8300
	public AudioClip[] RunBareFootsteps;

	// Token: 0x0400206D RID: 8301
	public AudioSource MyAudio;

	// Token: 0x0400206E RID: 8302
	public Transform BloodParent;

	// Token: 0x0400206F RID: 8303
	public Collider MyCollider;

	// Token: 0x04002070 RID: 8304
	public Collider GardenArea;

	// Token: 0x04002071 RID: 8305
	public Collider PoolStairs;

	// Token: 0x04002072 RID: 8306
	public Collider TreeArea;

	// Token: 0x04002073 RID: 8307
	public Collider NEStairs;

	// Token: 0x04002074 RID: 8308
	public Collider NWStairs;

	// Token: 0x04002075 RID: 8309
	public Collider SEStairs;

	// Token: 0x04002076 RID: 8310
	public Collider SWStairs;

	// Token: 0x04002077 RID: 8311
	public bool Debugging;

	// Token: 0x04002078 RID: 8312
	public bool CanSpawn;

	// Token: 0x04002079 RID: 8313
	public bool FootUp;

	// Token: 0x0400207A RID: 8314
	public float DownThreshold;

	// Token: 0x0400207B RID: 8315
	public float UpThreshold;

	// Token: 0x0400207C RID: 8316
	public float Height;

	// Token: 0x0400207D RID: 8317
	public int Bloodiness;

	// Token: 0x0400207E RID: 8318
	public int Collisions;
}
