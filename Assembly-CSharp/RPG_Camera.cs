// Decompiled with JetBrains decompiler
// Type: RPG_Camera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RPG_Camera : MonoBehaviour
{
  public static RPG_Camera instance;
  public static Camera MainCamera;
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

  private void Awake() => RPG_Camera.instance = this;

  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    this.invertAxisX = OptionGlobals.InvertAxisX;
    this.invertAxisY = OptionGlobals.InvertAxisY;
    this.sensitivity = (float) OptionGlobals.Sensitivity;
    RPG_Camera.MainCamera = this.GetComponent<Camera>();
    this.distance = Mathf.Clamp(this.distance, 0.05f, this.distanceMax);
    this.desiredDistance = this.distance;
    RPG_Camera.halfFieldOfView = (float) ((double) RPG_Camera.MainCamera.fieldOfView / 2.0 * (Math.PI / 180.0));
    RPG_Camera.planeAspect = RPG_Camera.MainCamera.aspect;
    RPG_Camera.halfPlaneHeight = RPG_Camera.MainCamera.nearClipPlane * Mathf.Tan(RPG_Camera.halfFieldOfView);
    RPG_Camera.halfPlaneWidth = RPG_Camera.halfPlaneHeight * RPG_Camera.planeAspect;
    this.UpdateRotation();
  }

  public void UpdateRotation()
  {
    this.mouseX = this.cameraPivot.transform.parent.eulerAngles.y;
    this.mouseY = 15f;
  }

  public static void CameraSetup()
  {
    GameObject gameObject;
    if ((UnityEngine.Object) RPG_Camera.MainCamera != (UnityEngine.Object) null)
    {
      gameObject = RPG_Camera.MainCamera.gameObject;
    }
    else
    {
      gameObject = new GameObject("Main Camera");
      gameObject.AddComponent<Camera>();
      gameObject.tag = "MainCamera";
    }
    if (!(bool) (UnityEngine.Object) gameObject.GetComponent(nameof (RPG_Camera)))
      gameObject.AddComponent<RPG_Camera>();
    (gameObject.GetComponent(nameof (RPG_Camera)) as RPG_Camera).cameraPivot = GameObject.Find("cameraPivot").transform;
  }

  private void LateUpdate()
  {
    if ((double) Time.deltaTime <= 0.0)
      return;
    if ((UnityEngine.Object) this.cameraPivot == (UnityEngine.Object) null)
    {
      this.cameraPivot = GameObject.Find("CameraPivot").transform;
    }
    else
    {
      this.GetInput();
      this.GetDesiredPosition();
      this.PositionUpdate();
      this.CharacterFade();
    }
  }

  public void GetInput()
  {
    if ((double) this.distance > 0.1)
      this.camBottom = Physics.Linecast(this.transform.position, this.transform.position - Vector3.up * this.camBottomDistance);
    int num = !this.camBottom ? 0 : ((double) this.transform.position.y - (double) this.cameraPivot.transform.position.y <= 0.0 ? 1 : 0);
    if (!this.invertAxisX)
      this.mouseX += (float) ((double) Input.GetAxis("Mouse X") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
    else
      this.mouseX -= (float) ((double) Input.GetAxis("Mouse X") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
    if (num != 0)
    {
      if ((double) Input.GetAxis("Mouse Y") < 0.0)
      {
        if (!this.invertAxisY)
          this.mouseY -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
        else
          this.mouseY += (float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
      }
      else if (!this.invertAxisY)
        this.mouseY -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
      else
        this.mouseY += (float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
    }
    else if (!this.invertAxisY)
      this.mouseY -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
    else
      this.mouseY += (float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSpeed * ((double) Time.deltaTime / (double) Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (double) this.sensitivity * 10.0);
    this.mouseY = this.ClampAngle(this.mouseY, -89.5f, 89.5f);
    this.mouseXSmooth = Mathf.SmoothDamp(this.mouseXSmooth, this.mouseX, ref this.mouseXVel, this.mouseSmoothingFactor);
    this.mouseYSmooth = Mathf.SmoothDamp(this.mouseYSmooth, this.mouseY, ref this.mouseYVel, this.mouseSmoothingFactor);
    this.mouseYMin = num == 0 ? -89.5f : this.mouseY;
    this.mouseYSmooth = this.ClampAngle(this.mouseYSmooth, this.mouseYMin, this.mouseYMax);
    this.desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * this.mouseScroll;
    if ((double) this.desiredDistance > (double) this.distanceMax)
      this.desiredDistance = this.distanceMax;
    if ((double) this.desiredDistance >= (double) this.distanceMin)
      return;
    this.desiredDistance = this.distanceMin;
  }

  public void GetDesiredPosition()
  {
    this.distance = this.desiredDistance;
    this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
    this.constraint = false;
    float num = this.CheckCameraClipPlane(this.cameraPivot.position, this.desiredPosition);
    if ((double) num != -1.0)
    {
      this.distance = num;
      this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
      this.constraint = true;
    }
    if ((UnityEngine.Object) RPG_Camera.MainCamera == (UnityEngine.Object) null)
      RPG_Camera.MainCamera = this.GetComponent<Camera>();
    this.distance -= RPG_Camera.MainCamera.nearClipPlane;
    if ((double) this.lastDistance < (double) this.distance || !this.constraint)
      this.distance = Mathf.SmoothDamp(this.lastDistance, this.distance, ref this.distanceVel, this.camDistanceSpeed);
    if ((double) this.distance < 0.05)
      this.distance = 0.05f;
    this.lastDistance = this.distance;
    this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
  }

  public void PositionUpdate()
  {
    this.transform.position = this.desiredPosition;
    if ((double) this.distance <= 0.05)
      return;
    this.transform.LookAt(this.cameraPivot);
  }

  private void CharacterFade()
  {
    if ((UnityEngine.Object) RPG_Animation.instance == (UnityEngine.Object) null)
      return;
    if ((double) this.distance < (double) this.firstPersonThreshold)
      RPG_Animation.instance.GetComponent<Renderer>().enabled = false;
    else if ((double) this.distance < (double) this.characterFadeThreshold)
    {
      RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
      float a = (float) (1.0 - ((double) this.characterFadeThreshold - (double) this.distance) / ((double) this.characterFadeThreshold - (double) this.firstPersonThreshold));
      if ((double) RPG_Animation.instance.GetComponent<Renderer>().material.color.a == (double) a)
        return;
      RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, a);
    }
    else
    {
      RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
      if ((double) RPG_Animation.instance.GetComponent<Renderer>().material.color.a == 1.0)
        return;
      RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, 1f);
    }
  }

  private Vector3 GetCameraPosition(float xAxis, float yAxis, float distance)
  {
    Vector3 vector3 = new Vector3(0.0f, 0.0f, -distance);
    return this.cameraPivot.position + Quaternion.Euler(xAxis, yAxis, 0.0f) * vector3;
  }

  private float CheckCameraClipPlane(Vector3 from, Vector3 to)
  {
    float num = -1f;
    RPG_Camera.ClipPlaneVertexes clipPlaneAt = RPG_Camera.GetClipPlaneAt(to);
    int layerMask = 257;
    if ((UnityEngine.Object) RPG_Camera.MainCamera != (UnityEngine.Object) null)
    {
      RaycastHit hitInfo;
      if (Physics.Linecast(from, to, out hitInfo, layerMask))
        num = hitInfo.distance - RPG_Camera.MainCamera.nearClipPlane;
      if (Physics.Linecast(from - this.transform.right * RPG_Camera.halfPlaneWidth + this.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.UpperLeft, out hitInfo, layerMask) && ((double) hitInfo.distance < (double) num || (double) num == -1.0))
        num = Vector3.Distance(hitInfo.point + this.transform.right * RPG_Camera.halfPlaneWidth - this.transform.up * RPG_Camera.halfPlaneHeight, from);
      if (Physics.Linecast(from + this.transform.right * RPG_Camera.halfPlaneWidth + this.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.UpperRight, out hitInfo, layerMask) && ((double) hitInfo.distance < (double) num || (double) num == -1.0))
        num = Vector3.Distance(hitInfo.point - this.transform.right * RPG_Camera.halfPlaneWidth - this.transform.up * RPG_Camera.halfPlaneHeight, from);
      if (Physics.Linecast(from - this.transform.right * RPG_Camera.halfPlaneWidth - this.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.LowerLeft, out hitInfo, layerMask) && ((double) hitInfo.distance < (double) num || (double) num == -1.0))
        num = Vector3.Distance(hitInfo.point + this.transform.right * RPG_Camera.halfPlaneWidth + this.transform.up * RPG_Camera.halfPlaneHeight, from);
      if (Physics.Linecast(from + this.transform.right * RPG_Camera.halfPlaneWidth - this.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.LowerRight, out hitInfo, layerMask) && ((double) hitInfo.distance < (double) num || (double) num == -1.0))
        num = Vector3.Distance(hitInfo.point - this.transform.right * RPG_Camera.halfPlaneWidth + this.transform.up * RPG_Camera.halfPlaneHeight, from);
    }
    return num;
  }

  private float ClampAngle(float angle, float min, float max)
  {
    while ((double) angle < -360.0 || (double) angle > 360.0)
    {
      if ((double) angle < -360.0)
        angle += 360f;
      if ((double) angle > 360.0)
        angle -= 360f;
    }
    return Mathf.Clamp(angle, min, max);
  }

  public static RPG_Camera.ClipPlaneVertexes GetClipPlaneAt(Vector3 pos)
  {
    RPG_Camera.ClipPlaneVertexes clipPlaneAt = new RPG_Camera.ClipPlaneVertexes();
    if ((UnityEngine.Object) RPG_Camera.MainCamera == (UnityEngine.Object) null)
      return clipPlaneAt;
    Transform transform = RPG_Camera.MainCamera.transform;
    float nearClipPlane = RPG_Camera.MainCamera.nearClipPlane;
    clipPlaneAt.UpperLeft = pos - transform.right * RPG_Camera.halfPlaneWidth;
    clipPlaneAt.UpperLeft += transform.up * RPG_Camera.halfPlaneHeight;
    clipPlaneAt.UpperLeft += transform.forward * nearClipPlane;
    clipPlaneAt.UpperRight = pos + transform.right * RPG_Camera.halfPlaneWidth;
    clipPlaneAt.UpperRight += transform.up * RPG_Camera.halfPlaneHeight;
    clipPlaneAt.UpperRight += transform.forward * nearClipPlane;
    clipPlaneAt.LowerLeft = pos - transform.right * RPG_Camera.halfPlaneWidth;
    clipPlaneAt.LowerLeft -= transform.up * RPG_Camera.halfPlaneHeight;
    clipPlaneAt.LowerLeft += transform.forward * nearClipPlane;
    clipPlaneAt.LowerRight = pos + transform.right * RPG_Camera.halfPlaneWidth;
    clipPlaneAt.LowerRight -= transform.up * RPG_Camera.halfPlaneHeight;
    clipPlaneAt.LowerRight += transform.forward * nearClipPlane;
    return clipPlaneAt;
  }

  public void RotateWithCharacter() => this.mouseX += Input.GetAxis("Horizontal") * RPG_Controller.instance.turnSpeed;

  public struct ClipPlaneVertexes
  {
    public Vector3 UpperLeft;
    public Vector3 UpperRight;
    public Vector3 LowerLeft;
    public Vector3 LowerRight;
  }
}
