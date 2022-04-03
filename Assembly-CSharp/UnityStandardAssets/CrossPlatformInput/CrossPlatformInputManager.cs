using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000542 RID: 1346
	public static class CrossPlatformInputManager
	{
		// Token: 0x0600223C RID: 8764 RVA: 0x001F2095 File Offset: 0x001F0295
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001F20B5 File Offset: 0x001F02B5
		public static void SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
		{
			if (activeInputMethod == CrossPlatformInputManager.ActiveInputMethod.Hardware)
			{
				CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
				return;
			}
			if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Touch)
			{
				return;
			}
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001F20D4 File Offset: 0x001F02D4
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001F20E1 File Offset: 0x001F02E1
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001F20EE File Offset: 0x001F02EE
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001F20FB File Offset: 0x001F02FB
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x001F2108 File Offset: 0x001F0308
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001F2123 File Offset: 0x001F0323
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x001F2130 File Offset: 0x001F0330
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001F213D File Offset: 0x001F033D
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x001F2146 File Offset: 0x001F0346
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001F214F File Offset: 0x001F034F
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001F215D File Offset: 0x001F035D
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001F216A File Offset: 0x001F036A
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001F2177 File Offset: 0x001F0377
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001F2184 File Offset: 0x001F0384
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001F2191 File Offset: 0x001F0391
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001F219E File Offset: 0x001F039E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001F21AB File Offset: 0x001F03AB
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F21B8 File Offset: 0x001F03B8
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001F21C5 File Offset: 0x001F03C5
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002251 RID: 8785 RVA: 0x001F21D3 File Offset: 0x001F03D3
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001F21DF File Offset: 0x001F03DF
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001F21EC File Offset: 0x001F03EC
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001F21F9 File Offset: 0x001F03F9
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004AE3 RID: 19171
		private static VirtualInput activeInput;

		// Token: 0x04004AE4 RID: 19172
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004AE5 RID: 19173
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000690 RID: 1680
		public enum ActiveInputMethod
		{
			// Token: 0x0400509E RID: 20638
			Hardware,
			// Token: 0x0400509F RID: 20639
			Touch
		}

		// Token: 0x02000691 RID: 1681
		public class VirtualAxis
		{
			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x06002728 RID: 10024 RVA: 0x002056CB File Offset: 0x002038CB
			// (set) Token: 0x06002729 RID: 10025 RVA: 0x002056D3 File Offset: 0x002038D3
			public string name { get; private set; }

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x0600272A RID: 10026 RVA: 0x002056DC File Offset: 0x002038DC
			// (set) Token: 0x0600272B RID: 10027 RVA: 0x002056E4 File Offset: 0x002038E4
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600272C RID: 10028 RVA: 0x002056ED File Offset: 0x002038ED
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x0600272D RID: 10029 RVA: 0x002056F7 File Offset: 0x002038F7
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x0600272E RID: 10030 RVA: 0x0020570D File Offset: 0x0020390D
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x0600272F RID: 10031 RVA: 0x0020571A File Offset: 0x0020391A
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002730 RID: 10032 RVA: 0x00205723 File Offset: 0x00203923
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06002731 RID: 10033 RVA: 0x0020572B File Offset: 0x0020392B
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x040050A1 RID: 20641
			private float m_Value;
		}

		// Token: 0x02000692 RID: 1682
		public class VirtualButton
		{
			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06002732 RID: 10034 RVA: 0x00205733 File Offset: 0x00203933
			// (set) Token: 0x06002733 RID: 10035 RVA: 0x0020573B File Offset: 0x0020393B
			public string name { get; private set; }

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x00205744 File Offset: 0x00203944
			// (set) Token: 0x06002735 RID: 10037 RVA: 0x0020574C File Offset: 0x0020394C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002736 RID: 10038 RVA: 0x00205755 File Offset: 0x00203955
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x06002737 RID: 10039 RVA: 0x0020575F File Offset: 0x0020395F
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002738 RID: 10040 RVA: 0x00205785 File Offset: 0x00203985
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06002739 RID: 10041 RVA: 0x002057A2 File Offset: 0x002039A2
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x0600273A RID: 10042 RVA: 0x002057B6 File Offset: 0x002039B6
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x0600273B RID: 10043 RVA: 0x002057C3 File Offset: 0x002039C3
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x0600273C RID: 10044 RVA: 0x002057CB File Offset: 0x002039CB
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600273D RID: 10045 RVA: 0x002057DC File Offset: 0x002039DC
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x040050A5 RID: 20645
			private int m_LastPressedFrame = -5;

			// Token: 0x040050A6 RID: 20646
			private int m_ReleasedFrame = -5;

			// Token: 0x040050A7 RID: 20647
			private bool m_Pressed;
		}
	}
}
