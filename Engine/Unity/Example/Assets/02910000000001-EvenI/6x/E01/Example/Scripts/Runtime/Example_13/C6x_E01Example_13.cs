using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * Example 13
	 */
	public partial class C6x_E01Example_13 : CManager_Scene
	{
		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}

		/** 플레이 버튼을 처리한다 */
		public void UIHandleOnBtn_Play()
		{
			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_14);
		}
		#endregion // 함수
	}
}
