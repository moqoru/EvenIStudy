using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 장애물
	 */
	public partial class C6x_E01Obstacle_21 : CComponent
	{
		#region 변수
		[Header("=====> Obstacle - Etc <=====")]
		[SerializeField] private List<Texture2D> m_oList_Textures = new List<Texture2D>();
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			int nIdx = Random.Range(0, m_oList_Textures.Count);

			var oRenderer_Mesh = this.GetComponentInChildren<MeshRenderer>();

			/*
			 * material 프로퍼티는 렌더러에 설정된 메인 재질을 가져오는 역할을 수행한다. (+ 즉,
			 * 해당 프로퍼티를 활용하면 스크립트를 통해 재질에 특정 속성을 설정하는 것이 가능하다.)
			 */
			oRenderer_Mesh.material.mainTexture = m_oList_Textures[nIdx];
		}
		#endregion // 함수
	}
}
