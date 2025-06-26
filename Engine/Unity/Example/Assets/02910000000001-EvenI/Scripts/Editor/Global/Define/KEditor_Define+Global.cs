using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
/**
 * 에디터 상수
 */
public static partial class KEditor_Define
{
	#region 컴파일 상수
	// 기타
	public const string G_E_FILE_UNITY = ".unity";
	public const string G_PATTERN_NAME_SCENE = "t:Example t:Scene";

	// 이름
	public const string G_N_DIR_SCENES = "Scenes";
	#endregion // 컴파일 상수

	#region 런타임 상수
	// 경로
	public static readonly List<string> G_LIST_PATHS_SCENE_SEARCH = new List<string>()
	{
		"Assets/02910000000001-EvenI/6x/E01/Example/" + KEditor_Define.G_N_DIR_SCENES + "/",
		"Assets/02910000000001-EvenI/6x/E01/Practice/" + KEditor_Define.G_N_DIR_SCENES + "/",
		"Assets/02910000000001-EvenI/6x/E01/Solution/" + KEditor_Define.G_N_DIR_SCENES + "/"
	};
	#endregion // 런타임 상수
}
#endif // #if UNITY_EDITOR
