using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 상수 - 경로
 */
public static partial class KDefine
{
	#region 컴파일 상수
	// 기타 {
	public const string G_P_OBJ_LIGHT_MAIN = "Lights/Light_Main";
	public const string G_P_OBJ_CAMERA_MAIN = "Cameras/Camera_Main";

	public const string G_P_OBJ_UIS = "Canvas/UIs";
	public const string G_P_OBJ_UIS_POPUP = "Canvas/UIsPopup";
	public const string G_P_OBJ_UIS_TOPMOST = "Canvas/UIsTopmost";

	public const string G_P_OBJ_OBJECTS = "Objects_Root/Objects";
	public const string G_P_OBJ_OBJECTS_STATIC = "Objects_Root/Objects_Static";
	// 기타 }

	// 사운드
	public const string G_P_OBJ_BGM = "Prefabs/Global/G_Prefab_Bgm";
	public const string G_P_OBJ_SFX = "Prefabs/Global/G_Prefab_Sfx";

	// 팝업 {
	public const string G_P_OBJ_UI_POPUP_ALERT = "Prefabs/Global/G_UIPrefab_AlertPopup";
	public const string G_P_OBJ_UI_POPUP_BG_IMG = "Contents/UIImg_Bg";

	public const string G_P_OBJ_UI_POPUP_CONTENTS = "Contents";
	public const string G_P_OBJ_UI_POPUP_CONTENTS_UIS = "Contents/UIImg_Bg/UIsContents";
	// 팝업 }

	// 응답자
	public const string G_P_OBJ_UI_RESPONDER_DRAG = "Prefabs/Global/G_UIPrefab_DragResponder";
	public const string G_P_OBJ_UI_RESPONDER_TOUCH = "Prefabs/Global/G_UIPrefab_TouchResponder";
	#endregion // 컴파일 상수
}
