using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x0600149C RID: 5276 RVA: 0x000C9E74 File Offset: 0x000C8074
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

	// Token: 0x0600149D RID: 5277 RVA: 0x000C9F38 File Offset: 0x000C8138
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

	// Token: 0x04002021 RID: 8225
	public YandereScript Yandere;

	// Token: 0x04002022 RID: 8226
	public GameObject BloodyFootprint;

	// Token: 0x04002023 RID: 8227
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002024 RID: 8228
	public AudioClip[] RunFootsteps;

	// Token: 0x04002025 RID: 8229
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x04002026 RID: 8230
	public AudioClip[] RunBareFootsteps;

	// Token: 0x04002027 RID: 8231
	public AudioSource MyAudio;

	// Token: 0x04002028 RID: 8232
	public Transform BloodParent;

	// Token: 0x04002029 RID: 8233
	public Collider MyCollider;

	// Token: 0x0400202A RID: 8234
	public Collider GardenArea;

	// Token: 0x0400202B RID: 8235
	public Collider PoolStairs;

	// Token: 0x0400202C RID: 8236
	public Collider TreeArea;

	// Token: 0x0400202D RID: 8237
	public Collider NEStairs;

	// Token: 0x0400202E RID: 8238
	public Collider NWStairs;

	// Token: 0x0400202F RID: 8239
	public Collider SEStairs;

	// Token: 0x04002030 RID: 8240
	public Collider SWStairs;

	// Token: 0x04002031 RID: 8241
	public bool Debugging;

	// Token: 0x04002032 RID: 8242
	public bool CanSpawn;

	// Token: 0x04002033 RID: 8243
	public bool FootUp;

	// Token: 0x04002034 RID: 8244
	public float DownThreshold;

	// Token: 0x04002035 RID: 8245
	public float UpThreshold;

	// Token: 0x04002036 RID: 8246
	public float Height;

	// Token: 0x04002037 RID: 8247
	public int Bloodiness;

	// Token: 0x04002038 RID: 8248
	public int Collisions;
}
