/*
* SHADERGRAPH_PREVIEW 심볼은 미리보기 여부를 나타내는 역할을 수행한다. (+ 즉, 미리보기에는
* 사용 가능한 기능이 제한적이기 때문에 특정 라이브러리에 존재하는 기능을 사용 할 경우 반드시 해당
* 심볼을 통해 예외 처리를 해줘야한다.
*/
#ifndef SHADERGRAPH_PREVIEW
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
#endif // #ifndef SHADERGRAPH_PREVIEW

/** 메인 광원 정보를 반환한다 */
void GetInfo_MainLight_float(out float4 a_stOutColor_Light, out float4 a_stOutDirection_Light)
{
#ifdef SHADERGRAPH_PREVIEW
	a_stOutColor_Light = float4(1.0, 1.0, 1.0, 1.0);
	a_stOutDirection_Light = float4(0.0, 0.0, -1.0, 0.0);
#else
	/*
	* GetMainLight 함수는 메인 광원 정보를 가져오는 역할을 수행한다. (+ 즉, 해당 함수를 활용하면
	* 메인 광원의 방향 등을 가져와서 활용하는 것이 가능하다.)
	*/
	Light stLight = GetMainLight();
	
	a_stOutColor_Light = float4(stLight.color, 1.0);
	a_stOutDirection_Light = float4(stLight.direction, 0.0);
#endif // #ifdef SHADERGRAPH_PREVIEW
}
