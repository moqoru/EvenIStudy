using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 상수 - 이름
 */
public static partial class KDefine
{
	#region 컴파일 상수
	// 기타 {
	public const string G_N_OBJ_UI_CANVAS = "Canvas";
	public const string G_N_OBJ_UI_EVENT_SYSTEM = "EventSystem";

	public const string G_N_OBJ_UIS = "UIs";
	public const string G_N_OBJ_UIS_ROOT = "UIsRoot";
	public const string G_N_OBJ_UIS_POPUP = "UIsPopup";
	public const string G_N_OBJ_UIS_TOPMOST = "UIsTopmost";

	public const string G_N_OBJ_OBJECTS = "Objects";
	public const string G_N_OBJ_OBJECTS_ROOT = "Objects_Root";
	public const string G_N_OBJ_OBJECTS_STATIC = "Objects_Static";
	// 기타 }

	// 렌더링
	public const string G_N_OBJ_MAIN_LIGHT = "Light_Main";
	public const string G_N_OBJ_MAIN_CAMERA = "Camera_Main";

	// 레이어 {
	public const string G_N_LAYER_DEF = "Default";
	public const string G_N_LAYER_ABS = "Absolute";

	public const string G_N_LAYER_BACKGROUND = "Background";
	public const string G_N_LAYER_UNDERGROUND = "Underground";

	public const string G_N_LAYER_FOREGROUND = "Foreground";
	public const string G_N_LAYER_OVERGROUND = "Overground";
	// 레이어 }
	#endregion // 컴파일 상수
}
