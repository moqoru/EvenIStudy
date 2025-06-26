using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;

/**
 * 에디터 함수
 */
public static partial class Editor_Func
{
	#region 제네릭 클래스 함수
	/** 에셋을 탐색한다 */
	public static T FindAsset<T>(string a_oPath_Asset) where T : Object
	{
		Debug.Assert(a_oPath_Asset.ExIsValid());
		return AssetDatabase.LoadAssetAtPath<T>(a_oPath_Asset);
	}
	#endregion // 제네릭 클래스 함수
}
#endif // #if UNITY_EDITOR
