using UnityEngine;

public class PlayerControllrFP : MonoBehaviour
{
	public float speedMove;

	public float speedRot;

	public float jump;

	public float airGravity;

	public float groundGravity;

	public Vector2 clampAngle;

	private Transform _transform;

	private Vector2 _angle;

	private Vector3 _dir;

	private float _mouseX;

	private float _mouseY;

	private float _horizontal;

	private float _vertical;

	private CharacterController _controller;

	private float _gravity;

	private void Start()
	{
		_controller = GetComponent<CharacterController>();
		_transform = base.transform;
	}

	private void Update()
	{
		Cursor.visible = false;
		if (_controller.isGrounded)
		{
			_horizontal = Input.GetAxis("Horizontal");
			_vertical = Input.GetAxis("Vertical");
			_gravity = groundGravity;
			_dir = base.transform.TransformDirection(_horizontal, 0f, _vertical) * speedMove;
			if (Input.GetButtonUp("Jump"))
			{
				_dir.y = jump;
			}
		}
		else
		{
			_gravity = airGravity;
		}
		_dir.y -= _gravity * Time.deltaTime;
		_controller.Move(_dir * Time.deltaTime);
	}

	private void LateUpdate()
	{
		_mouseX = Input.GetAxis("Mouse X");
		_mouseY = Input.GetAxis("Mouse Y");
		_angle.x -= _mouseY * speedRot;
		_angle.y += _mouseX * speedRot;
		_angle.x = Mathf.Clamp(_angle.x, 0f - clampAngle.x, clampAngle.y);
		Quaternion rotation = Quaternion.Euler(_angle.x, _angle.y, 0f);
		_transform.rotation = rotation;
	}
}
