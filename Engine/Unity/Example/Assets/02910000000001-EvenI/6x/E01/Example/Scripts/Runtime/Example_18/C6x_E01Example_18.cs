using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * Unity 사운드 관련 컴포넌트
 * - 오디오 소스 (Audio Source)
 * - 오디오 리스너 (Audio Listener)
 * 
 * 오디오 소스 (Audio Source) 컴포넌트란?
 * - 사운드를 발생 시키는 역할을 수행하는 컴포넌트이다. (+ 즉, 해당 컴포넌트를 활용하면 
 * 간단하게 사운드를 재생하는 것이 가능하다.)
 * 
 * 오디오 소스 컴포넌트는 사운드를 재생하기 위해서 해당 컴포넌트를 직접적으로 사용하는 방법과
 * PlayClipAtPoint 메서드를 사용하는 방법을 제공한다.
 * 
 * 단, 오디오 소스 컴포넌트를 직접적으로 사용하는 방법은 한번에 하나의 사운드만 재생 가능하기 
 * 때문에 2 개 이상의 사운드를 재생하고 싶다면 재생하고 싶은 사운드 개수만큼 오디오 소스 컴포넌트를 
 * 생성해야한다. (+ 즉, PlayClipAtPoint 메서드는 사운드 중첩이 가능하다는 것을 알 수 있다.)
 * 
 * 오디오 리스너 (Audio Listener) 컴포넌트란?
 * - 사운드를 듣는 역할을 수행하는 컴포넌트이다. (+ 즉, 해당 컴포넌트는 Unity 씬 상에 존재하는 
 * 사람의 귀에 해당한다는 것을 알 수 있다.)
 * 
 * 오디오 리스너 컴포넌트는 오디오 소스 컴포넌트와 달리 현재 로드가 된 Unity 씬 중에서 1 개만 
 * 존재해야한다. (+ 즉, 중복을 허용하지 않는다는 것을 알 수 있다.)
 * 
 * 오디오 소스 컴포넌트 vs PlayClipAtPoint 메서드
 * - 오디오 소스 컴포넌트를 직접적으로 사용하는 방법은 PlayClipAtPoint 메서드 방식에 비해서 
 * 좀 더 복잡하지만 사운드를 재생하는 과정에서 임시 객체가 생성되지 않기 때문에 사운드를 빈번하게 
 * 재생해야 될 경우 적접하다는 것을 알 수 있다.
 * 
 * 단, 오디오 소스 컴포넌트는 1 개의 사운드만 재생하는 것이 가능하기 때문에 여러 사운드를 중첩으로
 * 재생하고 싶다면 재생하고 싶은 사운드 개수만큼 오디오 소스 컴포넌트가 필요하다는 단점이 존재한다.
 * 
 * 반면 PlayClipAtPoint 메서드를 활용하면 간단하게 3 차원 사운드를 중첩으로 재생하는 것이 가능하다.
 * (+ 즉, 해당 메서드를 호출하면 간단하게 사운드가 중첩으로 재생된다는 것을 알 수 있다.)
 * 
 * 단, 해당 방식을 통한 사운드 재생은 임시 객체를 생성하고 제거하기 때문에 사운드를 빈번하게 
 * 재생해야 될 경우 해당 방식은 적합하지 않다는 단점이 존재한다.
 */
namespace _6x_E01Example
{
	/**
	 * Example 18
	 */
	public partial class C6x_E01Example_18 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 18 - Etc <=====")]
		[SerializeField] private AudioClip m_oAudioClip_Sfx = null;

		[SerializeField] private AudioSource m_oAudioSource_Bgm = null;
		[SerializeField] private AudioSource m_oAudioSource_Sfx = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			m_oAudioSource_Bgm.loop = true;
			m_oAudioSource_Bgm.playOnAwake = false;

			m_oAudioSource_Sfx.loop = false;
			m_oAudioSource_Sfx.playOnAwake = false;
		}

		/** 배경음 버튼을 처리한다 */
		public void UIHandleOnBtn_Bgm()
		{
			m_oAudioSource_Bgm.Play();
		}

		/** 효과음 버튼을 처리한다 */
		public void UIHandleOnBtn_SfxA()
		{
			m_oAudioSource_Sfx.Play();
		}

		/** 효과음 버튼을 처리한다 */
		public void UIHandleOnBtn_SfxB()
		{
			AudioSource.PlayClipAtPoint(m_oAudioClip_Sfx,
				this.Camera_Main.transform.position, 1.0f);
		}

		/** 사운드 중지 버튼을 처리한다 */
		public void UIHandleOnBtn_StopSounds()
		{
			m_oAudioSource_Bgm.Stop();
			m_oAudioSource_Sfx.Stop();
		}
		#endregion // 함수
	}
}
