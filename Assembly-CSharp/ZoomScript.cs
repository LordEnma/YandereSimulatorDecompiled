using System;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class ZoomScript : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001EACE4 File Offset: 0x001E8EE4
	private void Update()
	{
		if (this.Yandere.FollowHips)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
		}
		if (this.Yandere.Stance.Current == StanceType.Crawling)
		{
			this.Height = 0.05f;
		}
		else if (this.Yandere.Stance.Current == StanceType.Crouching)
		{
			this.Height = 0.4f;
		}
		else
		{
			this.Height = 1f;
		}
		if (!this.Yandere.FollowHips)
		{
			if (this.Yandere.FlameDemonic)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height + this.Zoom + 0.4f, Time.deltaTime), base.transform.localPosition.z);
			}
			else if (this.Yandere.Slender)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height + this.Zoom + this.Slender, Time.deltaTime), base.transform.localPosition.z);
			}
			else if (this.Yandere.Stand.Stand.activeInHierarchy)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height - this.Zoom * 0.5f + this.Slender * 0.5f, Time.deltaTime), base.transform.localPosition.z);
			}
			else
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height + this.Zoom, Time.deltaTime), base.transform.localPosition.z);
			}
		}
		else if (!this.Yandere.SithLord)
		{
			base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, this.Yandere.Hips.position.y + this.Zoom, Time.deltaTime), base.transform.position.z);
		}
		else
		{
			base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, this.Yandere.Hips.position.y, Time.deltaTime), base.transform.position.z);
		}
		if (!this.Yandere.Aiming && this.Yandere.CanMove && !this.Yandere.PauseScreen.Show)
		{
			this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		}
		if (this.Yandere.SithLord || this.Yandere.Riding)
		{
			this.Slender = Mathf.Lerp(this.Slender, 2.5f, Time.deltaTime);
		}
		else if (this.Yandere.Slender || this.Yandere.Stand.Stand.activeInHierarchy || this.Yandere.Blasting || this.Yandere.PK || this.Yandere.Shipgirl || this.TallHat.activeInHierarchy || this.Yandere.Man.activeInHierarchy || this.Yandere.Pod.activeInHierarchy || this.Yandere.LucyHelmet.activeInHierarchy || this.Yandere.Kagune[0].activeInHierarchy || this.Yandere.Demonic || this.Yandere.FloppyHat.activeInHierarchy)
		{
			this.Slender = Mathf.Lerp(this.Slender, 0.5f, Time.deltaTime);
		}
		else
		{
			this.Slender = Mathf.Lerp(this.Slender, 0f, Time.deltaTime);
		}
		if (this.TargetZoom < 0f)
		{
			this.TargetZoom = 0f;
		}
		if (this.Yandere.Stance.Current == StanceType.Crawling)
		{
			if (this.TargetZoom > 0.3f)
			{
				this.TargetZoom = 0.3f;
			}
		}
		else if (this.TargetZoom > 0.4f)
		{
			this.TargetZoom = 0.4f;
		}
		if (this.Zoom != this.TargetZoom)
		{
			this.Zoom = Mathf.MoveTowards(this.Zoom, this.TargetZoom, Time.deltaTime);
			this.Yandere.CameraEffects.UpdateDOF(2f - this.Zoom * 3.75f);
		}
		if (!this.Yandere.Possessed)
		{
			this.CameraScript.distance = 2f - this.Zoom * 3.33333f + this.Slender;
			this.CameraScript.distanceMax = 2f - this.Zoom * 3.33333f + this.Slender;
			this.CameraScript.distanceMin = 2f - this.Zoom * 3.33333f + this.Slender;
			if (this.Yandere.TornadoHair.activeInHierarchy || (this.CardboardBox != null && this.CardboardBox.transform.parent == this.Yandere.Hips))
			{
				this.CameraScript.distanceMax += 3f;
			}
		}
		else
		{
			this.CameraScript.distance = 5f;
			this.CameraScript.distanceMax = 5f;
		}
		if (!this.Yandere.TimeSkipping)
		{
			this.Timer += Time.deltaTime;
			this.ShakeStrength = Mathf.Lerp(this.ShakeStrength, 1f - this.Yandere.Sanity * 0.01f, Time.deltaTime);
			if (this.Timer > 0.1f + this.Yandere.Sanity * 0.01f)
			{
				this.Target.x = UnityEngine.Random.Range(-this.ShakeStrength, this.ShakeStrength);
				this.Target.y = base.transform.localPosition.y;
				this.Target.z = UnityEngine.Random.Range(-this.ShakeStrength, this.ShakeStrength);
				this.Timer = 0f;
			}
		}
		else
		{
			this.Target = new Vector3(0f, base.transform.localPosition.y, 0f);
		}
		if (this.Yandere.RoofPush)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime * 10f), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime * 10f));
			return;
		}
		base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, this.Target, Time.deltaTime * this.ShakeStrength * 0.1f);
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x001EB554 File Offset: 0x001E9754
	public void LateUpdate()
	{
		base.transform.eulerAngles = Vector3.zero;
		if (this.OverShoulder)
		{
			Vector3 lhs = this.Yandere.MainCamera.transform.TransformDirection(Vector3.forward);
			base.transform.position = new Vector3(this.Yandere.transform.position.x + this.midOffset * Vector3.Dot(lhs, Vector3.forward), base.transform.position.y, this.Yandere.transform.position.z + this.midOffset * Vector3.Dot(lhs, -Vector3.right));
			return;
		}
		if (this.Yandere.FollowHips)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
			return;
		}
		base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y, 0f);
	}

	// Token: 0x04004940 RID: 18752
	public CardboardBoxScript CardboardBox;

	// Token: 0x04004941 RID: 18753
	public RPG_Camera CameraScript;

	// Token: 0x04004942 RID: 18754
	public YandereScript Yandere;

	// Token: 0x04004943 RID: 18755
	public float TargetZoom;

	// Token: 0x04004944 RID: 18756
	public float Zoom;

	// Token: 0x04004945 RID: 18757
	public float ShakeStrength;

	// Token: 0x04004946 RID: 18758
	public float midOffset = 0.25f;

	// Token: 0x04004947 RID: 18759
	public float Slender;

	// Token: 0x04004948 RID: 18760
	public float Height;

	// Token: 0x04004949 RID: 18761
	public float Timer;

	// Token: 0x0400494A RID: 18762
	public Vector3 Target;

	// Token: 0x0400494B RID: 18763
	public bool OverShoulder;

	// Token: 0x0400494C RID: 18764
	public bool MoveCamera;

	// Token: 0x0400494D RID: 18765
	public GameObject TallHat;
}
