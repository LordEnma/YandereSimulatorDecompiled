using UnityEngine;

public class ZoomScript : MonoBehaviour
{
	public CardboardBoxScript CardboardBox;

	public RPG_Camera CameraScript;

	public YandereScript Yandere;

	public float TargetZoom;

	public float Zoom;

	public float ShakeStrength;

	public float midOffset = 0.25f;

	public float Slender;

	public float Height;

	public float Timer;

	public Vector3 Target;

	public bool OverShoulder;

	public bool MoveCamera;

	public GameObject TallHat;

	private void Update()
	{
		if (Yandere.Stance.Current == StanceType.Crawling)
		{
			Height = 0.2f;
			if (TargetZoom > 0.3f)
			{
				TargetZoom = 0.3f;
			}
		}
		else
		{
			if (Yandere.Stance.Current == StanceType.Crouching)
			{
				Height = 0.6f;
			}
			else
			{
				Height = 1f;
			}
			if (TargetZoom > 0.4f)
			{
				TargetZoom = 0.4f;
			}
		}
		if (Yandere.FollowHips)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, Yandere.Hips.position.z, Time.deltaTime));
			if (!Yandere.SithLord)
			{
				base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, Yandere.Hips.position.y + Zoom, Time.deltaTime), base.transform.position.z);
			}
			else
			{
				base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, Yandere.Hips.position.y, Time.deltaTime), base.transform.position.z);
			}
		}
		else if (Yandere.FlameDemonic)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, Height + Zoom + 0.4f, Time.deltaTime), base.transform.localPosition.z);
		}
		else if (Yandere.Slender)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, Height + Zoom + Slender, Time.deltaTime), base.transform.localPosition.z);
		}
		else if (Yandere.Stand.Stand.activeInHierarchy)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, Height - Zoom * 0.5f + Slender * 0.5f, Time.deltaTime), base.transform.localPosition.z);
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, Height + Zoom, Time.deltaTime * 5f), base.transform.localPosition.z);
		}
		if (!Yandere.Aiming && Yandere.CanMove && !Yandere.PauseScreen.Show && !Yandere.PreparingThrow && !Yandere.Throwing)
		{
			TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		}
		if (Yandere.SithLord || Yandere.Riding)
		{
			Slender = Mathf.Lerp(Slender, 2.5f, Time.deltaTime);
		}
		else if (Yandere.Slender || Yandere.Stand.Stand.activeInHierarchy || Yandere.Blasting || Yandere.PK || Yandere.Shipgirl || TallHat.activeInHierarchy || Yandere.Man.activeInHierarchy || (Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Scythe) || Yandere.Pod.activeInHierarchy || Yandere.LucyHelmet.activeInHierarchy || Yandere.Kagune[0].activeInHierarchy || Yandere.Demonic || Yandere.FloppyHat.activeInHierarchy || Yandere.TitanSword[0].activeInHierarchy || Yandere.FlameDemonic)
		{
			Slender = Mathf.Lerp(Slender, 0.5f, Time.deltaTime);
		}
		else if (Slender > 0f)
		{
			Slender = Mathf.Lerp(Slender, 0f, Time.deltaTime);
		}
		if (TargetZoom < 0f)
		{
			TargetZoom = 0f;
		}
		if (Zoom != TargetZoom)
		{
			Zoom = Mathf.MoveTowards(Zoom, TargetZoom, Time.deltaTime);
			UpdateDOF();
		}
		if (!Yandere.Possessed)
		{
			CameraScript.distance = 2f - Zoom * 3.33333f + Slender;
			CameraScript.distanceMax = 2f - Zoom * 3.33333f + Slender;
			CameraScript.distanceMin = 2f - Zoom * 3.33333f + Slender;
			if (Yandere.TornadoHair.activeInHierarchy || (CardboardBox != null && CardboardBox.transform.parent == Yandere.Hips))
			{
				CameraScript.distanceMax += 3f;
			}
		}
		else
		{
			CameraScript.distance = 5f;
			CameraScript.distanceMax = 5f;
		}
		if (!Yandere.TimeSkipping)
		{
			Timer += Time.deltaTime;
			ShakeStrength = Mathf.Lerp(ShakeStrength, 1f - Yandere.Sanity * 0.01f, Time.deltaTime);
			if (Timer > 0.1f + Yandere.Sanity * 0.01f)
			{
				Target.x = Random.Range(0f - ShakeStrength, ShakeStrength);
				Target.y = base.transform.localPosition.y;
				Target.z = Random.Range(0f - ShakeStrength, ShakeStrength);
				Timer = 0f;
			}
		}
		else
		{
			Target = new Vector3(0f, base.transform.localPosition.y, 0f);
		}
		if (Yandere.RoofPush)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, Yandere.Hips.position.x, Time.deltaTime * 10f), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, Yandere.Hips.position.z, Time.deltaTime * 10f));
		}
		else if (base.transform.localPosition != Target)
		{
			base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, Target, Time.deltaTime * ShakeStrength * 0.1f);
		}
	}

	public void LateUpdate()
	{
		base.transform.eulerAngles = Vector3.zero;
		if (OverShoulder)
		{
			Vector3 lhs = Yandere.MainCamera.transform.TransformDirection(Vector3.forward);
			base.transform.position = new Vector3(Yandere.transform.position.x + midOffset * Vector3.Dot(lhs, Vector3.forward), base.transform.position.y, Yandere.transform.position.z + midOffset * Vector3.Dot(lhs, -Vector3.right));
		}
		else if (Yandere.FollowHips)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, Yandere.Hips.position.z, Time.deltaTime));
		}
		else
		{
			base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y, 0f);
		}
	}

	public void UpdateDOF()
	{
		Yandere.CameraEffects.UpdateDOF(2f - Zoom * 3.75f);
	}
}
