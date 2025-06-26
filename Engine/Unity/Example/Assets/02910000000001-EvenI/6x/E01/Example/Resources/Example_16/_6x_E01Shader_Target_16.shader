Shader "6x/E01/Example/6x_E01Shader_Target_16"
{
	Properties
	{
		[MainColor] _Color_Main("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
		[MainTexture] _Texture_Main("Main Texture", 2D) = "white" { }
	}
	
	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
			"RenderQueue" = "Geometry+1"
			"RenderPipeline" = "UniversalPipeline"
		}

		Pass
		{
			HLSLPROGRAM
			#pragma vertex VS_Main
			#pragma fragment PS_Main

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

			CBUFFER_START(UnityPerMaterial)
			float4 _Color_Main;
			float4 _Texture_Main_ST;

			TEXTURE2D(_Texture_Main);
			SAMPLER(sampler_Texture_Main);
			CBUFFER_END

			/**
			* 정점 입력
			*/
			struct ST6x_E01VS_Input
			{
				float3 m_stPos: POSITION;
				float3 m_stNormal: NORMAL;
			};

			/**
			* 정점 출력
			*/
			struct ST6x_E01VS_Output
			{
				float4 m_stPos: SV_POSITION;
				float3 m_stNormal: NORMAL;
			};

			/** 정점 쉐이더 */
			ST6x_E01VS_Output VS_Main(ST6x_E01VS_Input a_stVS_Input)
			{
				ST6x_E01VS_Output stVS_Output = (ST6x_E01VS_Output)0;
				float3 stPos_World = TransformObjectToWorld(a_stVS_Input.m_stPos);

				stVS_Output.m_stPos = TransformObjectToHClip(a_stVS_Input.m_stPos);
				return stVS_Output;
			}

			/** 픽셀 쉐이더 */
			float4 PS_Main(ST6x_E01VS_Output a_stInput) : SV_TARGET
			{
				float4 stPS_Output = float4(1.0f, 0.0f, 0.0f, 1.0f);
				return stPS_Output;
			}
			ENDHLSL
		}
	}
	
	FallBack "Packages/com.unity.render-pipelines.universal/Shaders/SimpleLit"
}
