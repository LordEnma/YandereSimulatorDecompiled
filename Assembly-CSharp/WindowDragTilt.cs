using UnityEngine;

[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	public int updateOrder;

	public float degrees = 30f;

	private Vector3 mLastPos;

	private Transform mTrans;

	private float mAngle;

	private void OnEnable()
	{
		mTrans = base.transform;
		mLastPos = mTrans.position;
	}

	private void Update()
	{
		Vector3 vector = mTrans.position - mLastPos;
		mLastPos = mTrans.position;
		mAngle += vector.x * degrees;
		mAngle = NGUIMath.SpringLerp(mAngle, 0f, 20f, Time.deltaTime);
		mTrans.localRotation = Quaternion.Euler(0f, 0f, 0f - mAngle);
	}
}
