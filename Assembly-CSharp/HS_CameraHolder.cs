using System.Collections.Generic;
using UnityEngine;

public class HS_CameraHolder : MonoBehaviour
{
	public struct SVA
	{
		public float S;

		public float V;

		public float A;
	}

	public Transform Holder;

	public Vector3 cameraPos = new Vector3(0f, 0f, 0f);

	public float currDistance = 5f;

	public float xRotate = 250f;

	public float yRotate = 120f;

	public float yMinLimit = -20f;

	public float yMaxLimit = 80f;

	public float prevDistance;

	private float x;

	private float y;

	[Header("GUI")]
	private float windowDpi;

	public GameObject[] Prefabs;

	private int Prefab;

	private GameObject Instance;

	private float StartColor;

	private float HueColor;

	public Texture HueTexture;

	public bool disableHue;

	private ParticleSystem[] particleSystems = new ParticleSystem[0];

	private List<SVA> svList = new List<SVA>();

	private float H;

	private void Start()
	{
		if (Screen.dpi < 1f)
		{
			windowDpi = 1f;
		}
		if (Screen.dpi < 200f)
		{
			windowDpi = 1f;
		}
		else
		{
			windowDpi = Screen.dpi / 200f;
		}
		Vector3 eulerAngles = base.transform.eulerAngles;
		x = eulerAngles.y;
		y = eulerAngles.x;
		Counter(0);
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(5f * windowDpi, 5f * windowDpi, 110f * windowDpi, 35f * windowDpi), "Previous effect"))
		{
			Counter(-1);
		}
		if (GUI.Button(new Rect(120f * windowDpi, 5f * windowDpi, 110f * windowDpi, 35f * windowDpi), "Play again"))
		{
			Counter(0);
		}
		if (GUI.Button(new Rect(235f * windowDpi, 5f * windowDpi, 110f * windowDpi, 35f * windowDpi), "Next effect"))
		{
			Counter(1);
		}
		if (disableHue)
		{
			return;
		}
		StartColor = HueColor;
		HueColor = GUI.HorizontalSlider(new Rect(5f * windowDpi, 45f * windowDpi, 340f * windowDpi, 35f * windowDpi), HueColor, 0f, 1f);
		GUI.DrawTexture(new Rect(5f * windowDpi, 65f * windowDpi, 340f * windowDpi, 15f * windowDpi), HueTexture, ScaleMode.StretchToFill, alphaBlend: false, 0f);
		if (HueColor != StartColor)
		{
			int num = 0;
			ParticleSystem[] array = particleSystems;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem.MainModule main = array[i].main;
				Color color = Color.HSVToRGB(HueColor + H * 0f, svList[num].S, svList[num].V);
				main.startColor = new Color(color.r, color.g, color.b, svList[num].A);
				num++;
			}
		}
	}

	private void Counter(int count)
	{
		Prefab += count;
		if (Prefab > Prefabs.Length - 1)
		{
			Prefab = 0;
		}
		else if (Prefab < 0)
		{
			Prefab = Prefabs.Length - 1;
		}
		if (Instance != null)
		{
			Object.Destroy(Instance);
		}
		Instance = Object.Instantiate(Prefabs[Prefab]);
		particleSystems = Instance.GetComponentsInChildren<ParticleSystem>();
		svList.Clear();
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			Color color = array[i].main.startColor.color;
			SVA item = default;
			Color.RGBToHSV(color, out H, out item.S, out item.V);
			item.A = color.a;
			svList.Add(item);
		}
	}

	private void LateUpdate()
	{
		if (currDistance < 2f)
		{
			currDistance = 2f;
		}
		currDistance -= Input.GetAxis("Mouse ScrollWheel") * 2f;
		if ((bool)Holder && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
		{
			Vector3 mousePosition = Input.mousePosition;
			float num = 1f;
			if (Screen.dpi < 1f)
			{
				num = 1f;
			}
			num = ((!(Screen.dpi < 200f)) ? (Screen.dpi / 200f) : 1f);
			if (mousePosition.x < 380f * num && (float)Screen.height - mousePosition.y < 250f * num)
			{
				return;
			}
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			x += (float)((double)(Input.GetAxis("Mouse X") * xRotate) * 0.02);
			y -= (float)((double)(Input.GetAxis("Mouse Y") * yRotate) * 0.02);
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			Quaternion quaternion = Quaternion.Euler(y, x, 0f);
			Vector3 position = quaternion * new Vector3(0f, 0f, 0f - currDistance) + Holder.position + cameraPos;
			base.transform.rotation = quaternion;
			base.transform.position = position;
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (prevDistance != currDistance)
		{
			prevDistance = currDistance;
			Quaternion quaternion2 = Quaternion.Euler(y, x, 0f);
			Vector3 position2 = quaternion2 * new Vector3(0f, 0f, 0f - currDistance) + Holder.position + cameraPos;
			base.transform.rotation = quaternion2;
			base.transform.position = position2;
		}
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
