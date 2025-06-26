using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 사운드 관리자
 */
public partial class CManager_Snd : CSingleton<CManager_Snd>
{
	#region 변수
	private string m_oPath_Bgm = string.Empty;

	private CSnd m_oSnd_Bgm = null;
	private Dictionary<string, List<CSnd>> m_oContainerDictSounds_Sfx = new Dictionary<string, List<CSnd>>();
	#endregion // 변수

	#region 프로퍼티
	public bool IsMute_Bgm { get; private set; } = false;
	public bool IsMute_Sfxs { get; private set; } = false;

	public float Volume_Bgm { get; private set; } = 0.0f;
	public float Volume_Sfxs { get; private set; } = 0.0f;
	#endregion // 프로퍼티

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		m_oSnd_Bgm = Factory.CreateGameObj_Clone<CSnd>("Snd_Bgm",
			KDefine.G_P_OBJ_BGM, this.gameObject);
	}

	/** 배경음을 재생한다 */
	public void PlaySnd_Bgm(string a_oPath_Snd,
		bool a_bIs3D = false, bool a_bIsLoop = true)
	{
		// 배경음 재생이 불가능 할 경우
		if(a_oPath_Snd.Equals(m_oPath_Bgm))
		{
			return;
		}

		m_oSnd_Bgm.Play(Resources.Load<AudioClip>(a_oPath_Snd), a_bIs3D, a_bIsLoop);
	}

	/** 효과음을 재생한다 */
	public void PlaySnd_Sfx(string a_oPath_Snd,
		bool a_bIs3D = false, bool a_bIsLoop = false)
	{
		var oSnd_Sfx = this.FindSnd_PlayableSfx(a_oPath_Snd);
		oSnd_Sfx?.Play(Resources.Load<AudioClip>(a_oPath_Snd), a_bIs3D, a_bIsLoop);

		this.SetIsMute_Sfxs(this.IsMute_Sfxs);
		this.SetVolume_Sfxs(this.Volume_Sfxs);
	}

	/** 일회성 사운드를 재생한다 */
	public void PlaySnd_OneShot(string a_oPath_Snd, Vector3 a_stPos)
	{
		AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>(a_oPath_Snd),
			a_stPos, 1.0f);
	}

	/** 배경음을 중지한다 */
	public void StopSnd_Bgm()
	{
		m_oSnd_Bgm.Stop();
	}

	/** 효과음을 중지한다 */
	public void StopSnd_Sfxs()
	{
		this.EnumerateSfxs((a_oSnd_Sfx) => a_oSnd_Sfx.Stop());
	}

	/** 재생 가능한 효과음을 탐색한다 */
	private CSnd FindSnd_PlayableSfx(string a_oPath_Sfx)
	{
		// 효과음 풀 생성이 필요 할 경우
		if(!m_oContainerDictSounds_Sfx.TryGetValue(a_oPath_Sfx, out List<CSnd> oListSounds_Sfx))
		{
			oListSounds_Sfx = new List<CSnd>();
			m_oContainerDictSounds_Sfx.ExAddVal(a_oPath_Sfx, oListSounds_Sfx);
		}

		for(int i = 0; i < oListSounds_Sfx.Count; ++i)
		{
			// 재생 가능 할 경우
			if(!oListSounds_Sfx[i].IsPlaying)
			{
				return oListSounds_Sfx[i];
			}
		}

		// 효과음 생성이 불가능 할 경우
		if(oListSounds_Sfx.Count >= KDefine.G_MAX_NUM_SOUNDS_DUPLICATE_SFX)
		{
			return null;
		}

		return Factory.CreateGameObj_Clone<CSnd>("Snd_Sfx",
			KDefine.G_P_OBJ_SFX, this.gameObject);
	}

	/** 효과음을 순회한다 */
	private void EnumerateSfxs(System.Action<CSnd> a_oCallback)
	{
		foreach(var stKeyVal in m_oContainerDictSounds_Sfx)
		{
			for(int i = 0; i < stKeyVal.Value.Count; ++i)
			{
				a_oCallback(stKeyVal.Value[i]);
			}
		}
	}
	#endregion // 함수

	#region 접근 함수
	/** 배경음 음소거 여부를 변경한다 */
	public void SetIsMute_Bgm(bool a_bIsMute)
	{
		this.IsMute_Bgm = a_bIsMute;
		m_oSnd_Bgm.SetIsMute(this.IsMute_Bgm);
	}

	/** 효과음 음소거 여부를 변경한다 */
	public void SetIsMute_Sfxs(bool a_bIsMute)
	{
		this.IsMute_Sfxs = a_bIsMute;
		this.EnumerateSfxs((a_oSnd_Sfx) => a_oSnd_Sfx.SetIsMute(this.IsMute_Sfxs));
	}

	/** 배경음 볼륨을 변경한다 */
	public void SetVolume_Bgm(float a_fVolume)
	{
		this.Volume_Bgm = Mathf.Clamp01(a_fVolume);
		m_oSnd_Bgm.SetVolume(this.Volume_Bgm);
	}

	/** 효과음 볼륨을 변경한다 */
	public void SetVolume_Sfxs(float a_fVolume)
	{
		this.Volume_Sfxs = Mathf.Clamp01(a_fVolume);
		this.EnumerateSfxs((a_oSnd_Sfx) => a_oSnd_Sfx.SetVolume(this.Volume_Sfxs));
	}
	#endregion // 접근 함수
}
