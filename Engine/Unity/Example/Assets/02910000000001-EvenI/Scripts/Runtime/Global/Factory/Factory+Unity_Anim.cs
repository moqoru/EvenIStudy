using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using DG.Tweening;
using DG.Tweening.Core;

/**
 * 팩토리 - 애니메이션
 */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 애니메이션을 생성한다 */
	public static Tween MakeAnim(DOGetter<float> a_oGetter,
		DOSetter<float> a_oSetter, System.Action a_oCallback_Start, System.Action<float> a_oCallback_Setter, float a_fVal, float a_fDuration, Ease a_eEase = Ease.OutQuad, bool a_bIsRealtime = false)
	{
		Debug.Assert(a_oGetter != null && a_oSetter != null);
		a_oCallback_Start?.Invoke();

		return DOTween.To(a_oGetter, (a_fAniVal) =>
		{
			a_oSetter(a_fAniVal);
			a_oCallback_Setter?.Invoke(a_fAniVal);
		}, a_fVal, a_fDuration).SetEase(a_eEase).SetUpdate(a_bIsRealtime);
	}

	/** 시퀀스를 생성한다 */
	public static Sequence MakeSequence(Tween a_oAnim,
		System.Action<Sequence> a_oCallback, float a_fDelay = 0.0f, bool a_bIsJoin = false, bool a_bIsRealtime = false)
	{
		Debug.Assert(a_oAnim != null);

		return Factory.MakeSequence(new List<Tween>()
		{
			a_oAnim
		}, a_oCallback, a_fDelay, a_bIsJoin, a_bIsRealtime);
	}

	/** 시퀀스를 생성한다 */
	public static Sequence MakeSequence(List<Tween> a_oListAnimations,
		System.Action<Sequence> a_oCallback, float a_fDelay = 0.0f, bool a_bIsJoin = false, bool a_bIsRealtime = false)
	{
		Debug.Assert(a_oListAnimations != null);
		var oAnim = DOTween.Sequence().SetUpdate(a_bIsRealtime);

		for(int i = 0; i < a_oListAnimations.Count; ++i)
		{
			// 조인 모드 일 경우
			if(a_bIsJoin)
			{
				oAnim.Join(a_oListAnimations[i]);
			}
			else
			{
				oAnim.Append(a_oListAnimations[i]);
			}
		}

		var oSequence = DOTween.Sequence().SetDelay(a_fDelay).SetUpdate(a_bIsRealtime).Append(oAnim);
		return oSequence.AppendCallback(() => a_oCallback?.Invoke(oSequence));
	}
	#endregion // 클래스 팩토리 함수
}
