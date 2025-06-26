using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 상수
 */
public static partial class KDefine
{
	#region 컴파일 상수
	// 단위 {
	public const int G_MAX_NUM_SOUNDS_DUPLICATE_SFX = 10;

	public const float G_UNIT_SCALE = 0.01f;
	public const float G_UNIT_REF_PIXELS_PER = 1.0f;

	public const float G_ANGLE_FIELD_OF_VIEW = 45.0f;

	public const float G_WIDTH_DESIGN_SCREEN = 1920.0f;
	public const float G_HEIGHT_DESIGN_SCREEN = 1080.0f;

	public const float G_DISTANEC_NEAR_PLANE = 1.0f * KDefine.G_UNIT_SCALE;
	public const float G_DISTANCE_FAR_PLANE = 25000.0f * KDefine.G_UNIT_SCALE;
	// 단위 }

	// 시간
	public const float G_INTERVAL_INFINITE = float.MaxValue;
	public const float G_INTERVAL_INTERMEDIATE = float.Epsilon;

	// 팝업
	public const float G_UI_POPUP_DURATION_ANIM = 0.15f;
	#endregion // 컴파일 상수

	#region 런타임 상수
	// 단위
	public static readonly Vector3 G_SIZE_DESIGN_SCREEN = new Vector3(KDefine.G_WIDTH_DESIGN_SCREEN,
		KDefine.G_HEIGHT_DESIGN_SCREEN, 0.0f);

	// 앵커 {
	public static readonly Vector3 G_ANCHOR_UP_LEFT = new Vector3(0.0f, 1.0f, 0.0f);
	public static readonly Vector3 G_ANCHOR_UP_RIGHT = new Vector3(1.0f, 1.0f, 0.0f);
	public static readonly Vector3 G_ANCHOR_UP_CENTER = new Vector3(0.5f, 1.0f, 0.0f);

	public static readonly Vector3 G_ANCHOR_DOWN_LEFT = new Vector3(0.0f, 0.0f, 0.0f);
	public static readonly Vector3 G_ANCHOR_DOWN_RIGHT = new Vector3(1.0f, 0.0f, 0.0f);
	public static readonly Vector3 G_ANCHOR_DOWN_CENTER = new Vector3(0.5f, 0.0f, 0.0f);

	public static readonly Vector3 G_ANCHOR_MID_LEFT = new Vector3(0.0f, 0.5f, 0.0f);
	public static readonly Vector3 G_ANCHOR_MID_RIGHT = new Vector3(1.0f, 0.5f, 0.0f);
	public static readonly Vector3 G_ANCHOR_MID_CENTER = new Vector3(0.5f, 0.5f, 0.0f);
	// 앵커 }

	// 색상
	public static readonly Color G_COLOR_UI_POPUP_BLIND = new Color(0.0f, 0.0f, 0.0f, 0.95f);
	#endregion // 런타임 상수
}
