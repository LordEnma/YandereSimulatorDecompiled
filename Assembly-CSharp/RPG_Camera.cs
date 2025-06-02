using System;
using UnityEngine;

public class RPG_Camera : MonoBehaviour
{
	public struct ClipPlaneVertexes
	{
		public Vector3 UpperLeft;

		public Vector3 UpperRight;

		public Vector3 LowerLeft;

		public Vector3 LowerRight;
	}

	public InputDeviceScript InputDevice;

	public static RPG_Camera instance;

	public static Camera MainCamera;

	public Collider MyCollider;

	public Transform cameraPivot;

	public float distance = 5f;

	public float distanceMax = 30f;

	public float distanceMin = 2f;

	public float mouseSpeed = 8f;

	public float mouseScroll = 15f;

	public float mouseSmoothingFactor = 0.08f;

	public float camDistanceSpeed = 0.7f;

	public float camBottomDistance = 1f;

	public float firstPersonThreshold = 0.8f;

	public float characterFadeThreshold = 1.8f;

	public Vector3 desiredPosition;

	public float desiredDistance;

	private float lastDistance;

	public float mouseX;

	public float mouseXSmooth;

	private float mouseXVel;

	public float mouseY;

	public float mouseYSmooth;

	private float mouseYVel;

	private float mouseYMin = -89.5f;

	private float mouseYMax = 89.5f;

	private float distanceVel;

	private bool camBottom;

	private bool constraint;

	public bool invertAxisX;

	public bool invertAxisY;

	public float sensitivity;

	private static float halfFieldOfView;

	private static float planeAspect;

	private static float halfPlaneHeight;

	private static float halfPlaneWidth;

	public float Timer;

	public bool Talking;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		invertAxisX = OptionGlobals.InvertAxisX;
		invertAxisY = OptionGlobals.InvertAxisY;
		sensitivity = OptionGlobals.Sensitivity;
		MainCamera = GetComponent<Camera>();
		distance = Mathf.Clamp(distance, 0.05f, distanceMax);
		desiredDistance = distance;
		halfFieldOfView = MainCamera.fieldOfView / 2f * (MathF.PI / 180f);
		planeAspect = MainCamera.aspect;
		halfPlaneHeight = MainCamera.nearClipPlane * Mathf.Tan(halfFieldOfView);
		halfPlaneWidth = halfPlaneHeight * planeAspect;
		UpdateRotation();
	}

	public void UpdateRotation()
	{
		if (Timer > -1f)
		{
			mouseX = cameraPivot.transform.parent.eulerAngles.y;
		}
		mouseY = 15f;
	}

	public static void CameraSetup()
	{
		GameObject gameObject;
		if (MainCamera != null)
		{
			gameObject = MainCamera.gameObject;
		}
		else
		{
			gameObject = new GameObject("Main Camera");
			gameObject.AddComponent<Camera>();
			gameObject.tag = "MainCamera";
		}
		if (!gameObject.GetComponent("RPG_Camera"))
		{
			gameObject.AddComponent<RPG_Camera>();
		}
		RPG_Camera obj = gameObject.GetComponent("RPG_Camera") as RPG_Camera;
		GameObject gameObject2 = GameObject.Find("cameraPivot");
		obj.cameraPivot = gameObject2.transform;
	}

	private void LateUpdate()
	{
		if (Time.timeScale > 0.0001f)
		{
			if (cameraPivot == null)
			{
				cameraPivot = GameObject.Find("CameraPivot").transform;
				return;
			}
			Timer += 1f;
			GetInput();
			GetDesiredPosition();
			PositionUpdate();
			CharacterFade();
		}
	}

	public void GetInput()
	{
		if ((double)distance > 0.1)
		{
			camBottom = Physics.Linecast(base.transform.position, base.transform.position - Vector3.up * camBottomDistance);
		}
		bool num = camBottom && base.transform.position.y - cameraPivot.transform.position.y <= 0f;
		string axisName = "Mouse X";
		string axisName2 = "Mouse Y";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyX;
			axisName2 = InputNames.Xbox_JoyY;
		}
		if (!invertAxisX)
		{
			mouseX += Input.GetAxis(axisName) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
		}
		else
		{
			mouseX -= Input.GetAxis(axisName) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
		}
		if (num)
		{
			if (Input.GetAxis(axisName2) < 0f)
			{
				if (!invertAxisY)
				{
					mouseY -= Input.GetAxis(axisName2) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
				}
				else
				{
					mouseY += Input.GetAxis(axisName2) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
				}
			}
			else if (!invertAxisY)
			{
				mouseY -= Input.GetAxis(axisName2) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
			}
			else
			{
				mouseY += Input.GetAxis(axisName2) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
			}
		}
		else if (!invertAxisY)
		{
			mouseY -= Input.GetAxis(axisName2) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
		}
		else
		{
			mouseY += Input.GetAxis(axisName2) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f;
		}
		mouseY = ClampAngle(mouseY, -89.5f, 89.5f);
		mouseXSmooth = Mathf.SmoothDamp(mouseXSmooth, mouseX, ref mouseXVel, mouseSmoothingFactor);
		mouseYSmooth = Mathf.SmoothDamp(mouseYSmooth, mouseY, ref mouseYVel, mouseSmoothingFactor);
		if (num)
		{
			mouseYMin = mouseY;
		}
		else
		{
			mouseYMin = -89.5f;
		}
		mouseYSmooth = ClampAngle(mouseYSmooth, mouseYMin, mouseYMax);
		desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * mouseScroll;
		if (desiredDistance > distanceMax)
		{
			desiredDistance = distanceMax;
		}
		if (desiredDistance < distanceMin)
		{
			desiredDistance = distanceMin;
		}
	}

	public void GetDesiredPosition()
	{
		distance = desiredDistance;
		desiredPosition = GetCameraPosition(mouseYSmooth, mouseXSmooth, distance);
		constraint = false;
		float num = CheckCameraClipPlane(cameraPivot.position, desiredPosition);
		if (num != -1f)
		{
			distance = num;
			desiredPosition = GetCameraPosition(mouseYSmooth, mouseXSmooth, distance);
			constraint = true;
		}
		if (MainCamera == null)
		{
			MainCamera = GetComponent<Camera>();
		}
		distance -= MainCamera.nearClipPlane;
		if (lastDistance < distance || !constraint)
		{
			distance = Mathf.SmoothDamp(lastDistance, distance, ref distanceVel, camDistanceSpeed);
		}
		if ((double)distance < 0.05)
		{
			distance = 0.05f;
		}
		lastDistance = distance;
		desiredPosition = GetCameraPosition(mouseYSmooth, mouseXSmooth, distance);
	}

	public void PositionUpdate()
	{
		base.transform.position = desiredPosition;
		if ((double)distance > 0.05)
		{
			base.transform.LookAt(cameraPivot);
		}
	}

	private void CharacterFade()
	{
		if (RPG_Animation.instance == null)
		{
			return;
		}
		if (distance < firstPersonThreshold)
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = false;
		}
		else if (distance < characterFadeThreshold)
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
			float num = 1f - (characterFadeThreshold - distance) / (characterFadeThreshold - firstPersonThreshold);
			if (RPG_Animation.instance.GetComponent<Renderer>().material.color.a != num)
			{
				RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, num);
			}
		}
		else
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
			if (RPG_Animation.instance.GetComponent<Renderer>().material.color.a != 1f)
			{
				RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, 1f);
			}
		}
	}

	private Vector3 GetCameraPosition(float xAxis, float yAxis, float distance)
	{
		Vector3 vector = new Vector3(0f, 0f, 0f - distance);
		Quaternion quaternion = Quaternion.Euler(xAxis, yAxis, 0f);
		return cameraPivot.position + quaternion * vector;
	}

	public float CheckCameraClipPlane(Vector3 from, Vector3 to)
	{
		float num = -1f;
		ClipPlaneVertexes clipPlaneAt = GetClipPlaneAt(to);
		int layerMask = 257;
		if (MainCamera != null)
		{
			if (Physics.Linecast(from, to, out var hitInfo, layerMask))
			{
				num = hitInfo.distance - MainCamera.nearClipPlane;
			}
			if (Physics.Linecast(from - base.transform.right * halfPlaneWidth + base.transform.up * halfPlaneHeight, clipPlaneAt.UpperLeft, out hitInfo, layerMask) && (hitInfo.distance < num || num == -1f))
			{
				num = Vector3.Distance(hitInfo.point + base.transform.right * halfPlaneWidth - base.transform.up * halfPlaneHeight, from);
			}
			if (Physics.Linecast(from + base.transform.right * halfPlaneWidth + base.transform.up * halfPlaneHeight, clipPlaneAt.UpperRight, out hitInfo, layerMask) && (hitInfo.distance < num || num == -1f))
			{
				num = Vector3.Distance(hitInfo.point - base.transform.right * halfPlaneWidth - base.transform.up * halfPlaneHeight, from);
			}
			if (Physics.Linecast(from - base.transform.right * halfPlaneWidth - base.transform.up * halfPlaneHeight, clipPlaneAt.LowerLeft, out hitInfo, layerMask) && (hitInfo.distance < num || num == -1f))
			{
				num = Vector3.Distance(hitInfo.point + base.transform.right * halfPlaneWidth + base.transform.up * halfPlaneHeight, from);
			}
			if (Physics.Linecast(from + base.transform.right * halfPlaneWidth - base.transform.up * halfPlaneHeight, clipPlaneAt.LowerRight, out hitInfo, layerMask) && (hitInfo.distance < num || num == -1f))
			{
				num = Vector3.Distance(hitInfo.point - base.transform.right * halfPlaneWidth + base.transform.up * halfPlaneHeight, from);
			}
		}
		return num;
	}

	private float ClampAngle(float angle, float min, float max)
	{
		while (angle < -360f || angle > 360f)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
		}
		return Mathf.Clamp(angle, min, max);
	}

	public static ClipPlaneVertexes GetClipPlaneAt(Vector3 pos)
	{
		ClipPlaneVertexes result = default(ClipPlaneVertexes);
		if (MainCamera == null)
		{
			return result;
		}
		Transform transform = MainCamera.transform;
		float nearClipPlane = MainCamera.nearClipPlane;
		result.UpperLeft = pos - transform.right * halfPlaneWidth;
		result.UpperLeft += transform.up * halfPlaneHeight;
		result.UpperLeft += transform.forward * nearClipPlane;
		result.UpperRight = pos + transform.right * halfPlaneWidth;
		result.UpperRight += transform.up * halfPlaneHeight;
		result.UpperRight += transform.forward * nearClipPlane;
		result.LowerLeft = pos - transform.right * halfPlaneWidth;
		result.LowerLeft -= transform.up * halfPlaneHeight;
		result.LowerLeft += transform.forward * nearClipPlane;
		result.LowerRight = pos + transform.right * halfPlaneWidth;
		result.LowerRight -= transform.up * halfPlaneHeight;
		result.LowerRight += transform.forward * nearClipPlane;
		return result;
	}

	public void RotateWithCharacter()
	{
		Debug.Log("The RotateWithCharacter() function was just called.");
		float num = Input.GetAxis("Horizontal") * RPG_Controller.instance.turnSpeed;
		mouseX += num;
	}

	public void ZeroEverything()
	{
		Debug.Log("The ZeroEverything() function was just called.");
		mouseX = 0f;
		mouseXSmooth = 0f;
		mouseY = 0f;
		mouseYSmooth = 0f;
	}

	public void ResetStreetCamera()
	{
		Debug.Log("The ZeroEverything() function was just called.");
		mouseX = 90f;
		mouseXSmooth = 90f;
		mouseY = 15f;
		mouseYSmooth = 15f;
	}
}
