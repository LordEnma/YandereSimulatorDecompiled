using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021F5 RID: 8693 RVA: 0x001EC095 File Offset: 0x001EA295
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001EC0B5 File Offset: 0x001EA2B5
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

		// Token: 0x060021F7 RID: 8695 RVA: 0x001EC0D4 File Offset: 0x001EA2D4
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001EC0E1 File Offset: 0x001EA2E1
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001EC0EE File Offset: 0x001EA2EE
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001EC0FB File Offset: 0x001EA2FB
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001EC108 File Offset: 0x001EA308
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001EC123 File Offset: 0x001EA323
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001EC130 File Offset: 0x001EA330
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001EC13D File Offset: 0x001EA33D
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001EC146 File Offset: 0x001EA346
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001EC14F File Offset: 0x001EA34F
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001EC15D File Offset: 0x001EA35D
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EC16A File Offset: 0x001EA36A
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001EC177 File Offset: 0x001EA377
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EC184 File Offset: 0x001EA384
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001EC191 File Offset: 0x001EA391
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001EC19E File Offset: 0x001EA39E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001EC1AB File Offset: 0x001EA3AB
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001EC1B8 File Offset: 0x001EA3B8
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001EC1C5 File Offset: 0x001EA3C5
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600220A RID: 8714 RVA: 0x001EC1D3 File Offset: 0x001EA3D3
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001EC1DF File Offset: 0x001EA3DF
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001EC1EC File Offset: 0x001EA3EC
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001EC1F9 File Offset: 0x001EA3F9
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A08 RID: 18952
		private static VirtualInput activeInput;

		// Token: 0x04004A09 RID: 18953
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A0A RID: 18954
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000688 RID: 1672
		public enum ActiveInputMethod
		{
			// Token: 0x04004FEC RID: 20460
			Hardware,
			// Token: 0x04004FED RID: 20461
			Touch
		}

		// Token: 0x02000689 RID: 1673
		public class VirtualAxis
		{
			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026EC RID: 9964 RVA: 0x001FFB97 File Offset: 0x001FDD97
			// (set) Token: 0x060026ED RID: 9965 RVA: 0x001FFB9F File Offset: 0x001FDD9F
			public string name { get; private set; }

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026EE RID: 9966 RVA: 0x001FFBA8 File Offset: 0x001FDDA8
			// (set) Token: 0x060026EF RID: 9967 RVA: 0x001FFBB0 File Offset: 0x001FDDB0
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026F0 RID: 9968 RVA: 0x001FFBB9 File Offset: 0x001FDDB9
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026F1 RID: 9969 RVA: 0x001FFBC3 File Offset: 0x001FDDC3
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026F2 RID: 9970 RVA: 0x001FFBD9 File Offset: 0x001FDDD9
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026F3 RID: 9971 RVA: 0x001FFBE6 File Offset: 0x001FDDE6
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026F4 RID: 9972 RVA: 0x001FFBEF File Offset: 0x001FDDEF
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026F5 RID: 9973 RVA: 0x001FFBF7 File Offset: 0x001FDDF7
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FEF RID: 20463
			private float m_Value;
		}

		// Token: 0x0200068A RID: 1674
		public class VirtualButton
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026F6 RID: 9974 RVA: 0x001FFBFF File Offset: 0x001FDDFF
			// (set) Token: 0x060026F7 RID: 9975 RVA: 0x001FFC07 File Offset: 0x001FDE07
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026F8 RID: 9976 RVA: 0x001FFC10 File Offset: 0x001FDE10
			// (set) Token: 0x060026F9 RID: 9977 RVA: 0x001FFC18 File Offset: 0x001FDE18
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026FA RID: 9978 RVA: 0x001FFC21 File Offset: 0x001FDE21
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026FB RID: 9979 RVA: 0x001FFC2B File Offset: 0x001FDE2B
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026FC RID: 9980 RVA: 0x001FFC51 File Offset: 0x001FDE51
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026FD RID: 9981 RVA: 0x001FFC6E File Offset: 0x001FDE6E
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026FE RID: 9982 RVA: 0x001FFC82 File Offset: 0x001FDE82
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026FF RID: 9983 RVA: 0x001FFC8F File Offset: 0x001FDE8F
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06002700 RID: 9984 RVA: 0x001FFC97 File Offset: 0x001FDE97
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x06002701 RID: 9985 RVA: 0x001FFCA8 File Offset: 0x001FDEA8
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FF3 RID: 20467
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FF4 RID: 20468
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FF5 RID: 20469
			private bool m_Pressed;
		}
	}
}
