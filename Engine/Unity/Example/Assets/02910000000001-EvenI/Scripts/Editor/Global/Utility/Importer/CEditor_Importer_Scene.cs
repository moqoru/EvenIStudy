using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using System.IO;
using UnityEditor;

/**
 * 씬 임포터
 */
[InitializeOnLoad]
public static partial class CEditor_Importer_Scene
{
	#region 클래스 함수
	/** 생성자 */
	static CEditor_Importer_Scene()
	{
		// 플레이 모드 일 경우
		if(EditorApplication.isPlaying)
		{
			return;
		}

		EditorApplication.projectChanged -= CEditor_Importer_Scene.ImportScenes_All;
		EditorApplication.projectChanged += CEditor_Importer_Scene.ImportScenes_All;
	}

	/** 씬을 추가한다 */
	public static void ImportScenes_All()
	{
		var oListPaths_Search = new List<string>(KEditor_Define.G_LIST_PATHS_SCENE_SEARCH);
		var oListScenes_EditorBuildSettings = new List<EditorBuildSettingsScene>();

		string oPath_Scenes = string.Format("{0}/",
			KEditor_Define.G_N_DIR_SCENES);

		for(int i = 0; i < oListPaths_Search.Count; ++i)
		{
			// 씬 추가가 불가능 할 경우
			if(!AssetDatabase.IsValidFolder(oListPaths_Search[i]))
			{
				continue;
			}

			var oGUIDs = AssetDatabase.FindAssets(KEditor_Define.G_PATTERN_NAME_SCENE, 
				new string[]
			{
				oListPaths_Search[i]
			});

			for(int j = 0; j < oGUIDs.Length; ++j)
			{
				string oPath_File = AssetDatabase.GUIDToAssetPath(oGUIDs[j]);
				string oExtension_File = Path.GetExtension(oPath_File);

				bool bIsValid = oPath_File.Contains(oPath_Scenes);
				bIsValid = bIsValid && oExtension_File.Equals(KEditor_Define.G_E_FILE_UNITY);
				bIsValid = bIsValid && Editor_Func.FindAsset<SceneAsset>(oPath_File) != null;

				// 씬 추가가 불가능 할 경우
				if(!bIsValid)
				{
					continue;
				}

				var oScene_EditorBuildSettings = new EditorBuildSettingsScene(oPath_File,
					true);

				oListScenes_EditorBuildSettings.ExAddVal(oScene_EditorBuildSettings);
			}
		}

		EditorBuildSettings.scenes = oListScenes_EditorBuildSettings.ToArray();
	}
	#endregion // 클래스 함수
}
#endif // #if UNITY_EDITOR
