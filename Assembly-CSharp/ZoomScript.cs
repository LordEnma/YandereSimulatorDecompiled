using System;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class ZoomScript : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001E9858 File Offset: 0x001E7A58
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

	// Token: 0x06002117 RID: 8471 RVA: 0x001EA0C8 File Offset: 0x001E82C8
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

	// Token: 0x0400492A RID: 18730
	public CardboardBoxScript CardboardBox;

	// Token: 0x0400492B RID: 18731
	public RPG_Camera CameraScript;

	// Token: 0x0400492C RID: 18732
	public YandereScript Yandere;

	// Token: 0x0400492D RID: 18733
	public float TargetZoom;

	// Token: 0x0400492E RID: 18734
	public float Zoom;

	// Token: 0x0400492F RID: 18735
	public float ShakeStrength;

	// Token: 0x04004930 RID: 18736
	public float midOffset = 0.25f;

	// Token: 0x04004931 RID: 18737
	public float Slender;

	// Token: 0x04004932 RID: 18738
	public float Height;

	// Token: 0x04004933 RID: 18739
	public float Timer;

	// Token: 0x04004934 RID: 18740
	public Vector3 Target;

	// Token: 0x04004935 RID: 18741
	public bool OverShoulder;

	// Token: 0x04004936 RID: 18742
	public bool MoveCamera;

	// Token: 0x04004937 RID: 18743
	public GameObject TallHat;
}
