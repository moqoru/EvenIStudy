using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;

/**
 * 에셋 후처리자
 */
[InitializeOnLoad]
public partial class CEditor_PostProcessor_Asset : AssetPostprocessor
{
	#region 함수
	/** 에셋이 추가되었을 경우 */
	public virtual void OnPreprocessAsset()
	{
		this.SetupImporter_Font(this.assetImporter as TrueTypeFontImporter);
		this.SetupImporter_Texture(this.assetImporter as TextureImporter);
	}

	/** 폰트 임포터를 설정한다 */
	protected virtual void SetupImporter_Font(TrueTypeFontImporter a_oImporter)
	{
		// 임포터 설정이 불가능 할 경우
		if(a_oImporter == null)
		{
			return;
		}

		a_oImporter.includeFontData = true;
		a_oImporter.shouldRoundAdvanceValue = true;
		a_oImporter.fontTextureCase = FontTextureCase.Dynamic;
		a_oImporter.fontRenderingMode = FontRenderingMode.HintedRaster;
		a_oImporter.ascentCalculationMode = AscentCalculationMode.FaceAscender;
	}

	/** 텍스처 임포터를 설정한다 */
	protected virtual void SetupImporter_Texture(TextureImporter a_oImporter)
	{
		// 임포터 설정이 불가능 할 경우
		if(a_oImporter == null)
		{
			return;
		}

		var oSettings_Texture = new TextureImporterSettings();
		a_oImporter.ReadTextureSettings(oSettings_Texture);

		oSettings_Texture.spriteGenerateFallbackPhysicsShape = true;
		oSettings_Texture.spriteMeshType = SpriteMeshType.FullRect;

		a_oImporter.SetTextureSettings(oSettings_Texture);
		a_oImporter.spritePixelsPerUnit = 1.0f;
	}
	#endregion // 함수
}
#endif // #if UNITY_EDITOR
