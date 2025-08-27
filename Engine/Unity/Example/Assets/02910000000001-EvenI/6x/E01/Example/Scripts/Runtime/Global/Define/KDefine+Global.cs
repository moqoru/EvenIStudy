using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 상수
 */
public static partial class KDefine
{
	#region 컴파일 상수
	// 이름
	public const string G_N_AXIS_VERTICAL = "Vertical";
	public const string G_N_AXIS_HORIZONTAL = "Horizontal";

	// 씬 이름 {
	public const string G_N_SCENE_EXAMPLE_01 = "_6x_E01Example_01 (Basic)";

	public const string G_N_SCENE_EXAMPLE_05 = "_6x_E01Example_05 (Turret - Title)";
	public const string G_N_SCENE_EXAMPLE_06 = "_6x_E01Example_06 (Turret - Play)";
	public const string G_N_SCENE_EXAMPLE_07 = "_6x_E01Example_07 (Turret - Result)";

	public const string G_N_SCENE_EXAMPLE_09 = "_6x_E01Example_09 (Flappy Bird - Title)";
	public const string G_N_SCENE_EXAMPLE_10 = "_6x_E01Example_10 (Flappy Bird - Play)";
	public const string G_N_SCENE_EXAMPLE_11 = "_6x_E01Example_11 (Flappy Bird - Result)";

	public const string G_N_SCENE_EXAMPLE_13 = "_6x_E01Example_13 (Moly Moly - Title)";
	public const string G_N_SCENE_EXAMPLE_14 = "_6x_E01Example_14 (Moly Moly - Play)";
	public const string G_N_SCENE_EXAMPLE_15 = "_6x_E01Example_15 (Moly Moly - Result)";

	public const string G_N_SCENE_EXAMPLE_20 = "_6x_E01Example_20 (3D Tps - Title)";
	public const string G_N_SCENE_EXAMPLE_21 = "_6x_E01Example_21 (3D Tps - Play)";
	public const string G_N_SCENE_EXAMPLE_22 = "_6x_E01Example_22 (3D Tps - Result)";
	// 씬 이름 }
	#endregion // 컴파일 상수
}

/*
 * Unity 과제 1
 * - 터렛 게임에 총알 종류 추가하기
 * - 각 터렛은 일정 확률로 푸른 총알과 노란 총알 발사
 * - 푸른 총알은 점점 크기가 커지도록 처리
 * - 노란 총알은 일정 반경 안에 플레이어가 존재 할 경우 호밍 처리
 * 
 * Unity 과제 2
 * - 플래피 버드에 장애물 종류 추가하기
 * - 일정 확률로 상/하로 움직이는 특수 장애물 구현
 * - 특수 장애물을 통과 시 점수 2 점 획득
 * 
 * Unity 과제 3
 * - 두더지 잡기에 특수 두더지 추가하기
 * - 일정 확률로 2 배의 속도 움직이는 두더지 구현 (+ 색상은 붉은색 계열로 구별)
 * - 특수 두더지를 잡을 경우 획득 or 감소하는 점수는 2 배 (+ 즉, 착한 특수 두더지를 잡으면 -40 점)
 * 
 * Unity 과제 4
 * - 두더지 잡기에 오브젝트 풀링 구현하기
 * - 점수 텍스트에 오브젝트 풀링 구조를 활용해서 생성/제거가 아닌 활성/비활성화 방식으로 점수 텍스트 출력하기
 */
