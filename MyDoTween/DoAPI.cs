using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class DoAPI : MonoBehaviour
{
	public Gradient _gradient;
	public AnimationCurve _curve;
	private Tweener _tweener;

	async void Start()
	{
		//Position 移動到座標
		transform.DOMove(Vector3.one, 2);
		transform.DOLocalMoveX(1, 2);
		transform.DOLocalMoveY(1, 2);

		//Rotate 旋轉
		transform.DORotate(new Vector3(0, 0, 180), 2);
		transform.DOLocalRotate(new Vector3(0, 90, 0), 2);
		transform.DORotateQuaternion(new Quaternion(0.1f, 0.1f, 0.1f, 0.1f), 2);
		transform.DOLookAt(Vector3.one, 2);

		//縮放 Scale
		transform.DOScale(Vector3.one * 2, 2);

		//震動 + 彈性
		//第一個參數 punch:方向 力的大小
		//第二個參數 duration:持續時間
		//第三個參數 Vibrato: 震動頻率
		//第四個參數 Elasticity 彈性
		transform.DOPunchPosition(new Vector3(0, 1, 0), 2, 10, 10);

		//Shake 震動
		transform.DOShakePosition(2, Vector3.one, 20, 0);

		//Blend(座標位置增加或減少)
		transform.DOBlendableMoveBy(Vector3.one, 2);
		transform.DOBlendableMoveBy(-Vector3.one * 2, 2);

		//Material 材質Tint顏色變化
		Material material = GetComponent<MeshRenderer>().material;
		material.DOColor(Color.red, "_Color", 2);

		//Alpha 透明
		material.DOFade(0, 2);

		//Gradient 顏色和透明度漸變
		material.DOGradientColor(_gradient, "_Color", 2);
		material.DOVector(Color.clear, "_Color", 2);

		//顏色混合
		material.DOBlendableColor(Color.red, "_Color", 2);
		material.DOBlendableColor(Color.green, "_Color", 2);

		//隊列執行
		Sequence quence = DOTween.Sequence();
		quence.Append(transform.DOMove(Vector3.one, 2));//0~2秒
		quence.AppendInterval(1);//2~3秒
		quence.AppendCallback(AppendCallBack);
		quence.Join(transform.DOScale(Vector3.one * 2, 2));
		quence.Append(transform.DOMove(new Vector3(1, 0, 0), 2));//3~5秒
		quence.Join(transform.DOScale(Vector3.one, 2));
		//插入執行(會覆蓋當前秒數的執行)
		quence.Insert(2, transform.DOMove(-Vector3.one, 1));//2秒開始
	    //插入方法執行
		quence.InsertCallback(5, InsertCallBack);

		//多種方法調用
		transform.DOMove(Vector3.one, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

		//結束點到起點
		transform.DOMove(Vector3.one, 2).From();

		//延遲調用
		transform.DOMove(Vector3.one, 2).SetDelay(3);

		//移動速度
		transform.DOMove(Vector3.one, 10).SetSpeedBased();

		//以ID調用
		transform.DOMove(Vector3.one, 10).SetId("ID");
		DOTween.Play("ID");

		//增量移動
		transform.DOMove(Vector3.one, 2).SetRelative(true);

		//幀函數
		transform.DOMove(Vector3.one, 2).SetUpdate(UpdateType.Normal, true);

		//Flash運動曲線 漸大或漸小
		transform.DOMove(Vector3.one, 2).SetEase(Ease.Flash, 10, 1);
		transform.DOMove(Vector3.one, 2).SetEase(Ease.Flash, 10, -1);

		//結合AnimationCurve使用
		transform.DOMove(Vector3.one * 2, 2).SetEase(_curve);

		//曲線運動 自訂義函數設置
		transform.DOMove(Vector3.one * 2, 2).SetEase(EaseFun);

		//回調函數
		transform.DOMove(Vector3.one * 2, 2).OnComplete(() => { Debug.Log("OnComplete"); });
		transform.DOMove(Vector3.one * 2, 2).OnKill(() => { Debug.Log("OnKill"); });
		transform.DOMove(Vector3.one * 2, 2).OnPlay(() => { Debug.Log("OnPlay"); });
		transform.DOMove(Vector3.one * 2, 2).OnPause(() => { Debug.Log("OnPause"); });
		transform.DOMove(Vector3.one * 2, 2).OnStart(() => { Debug.Log("OnStart"); });
		transform.DOMove(Vector3.one * 2, 2).OnStepComplete(() => { Debug.Log("OnStepComplete"); });
		transform.DOMove(Vector3.one * 2, 2).OnUpdate(() => { Debug.Log("OnUpdate"); });
		transform.DOMove(Vector3.one * 2, 2).OnRewind(() => { Debug.Log("OnRewind"); });

		//常見方法
		transform.DOMove(Vector3.one * 2, 2);
		await Task.Delay(TimeSpan.FromSeconds(0.0001f));
		transform.DOPause();
		transform.DOPlay();
		transform.DORestart();
		transform.DORewind();
		transform.DOSmoothRewind();
		transform.DOPlayBackwards();
		await Task.Delay(TimeSpan.FromSeconds(0.5f));
		transform.DOPlayForward();
		transform.DOTogglePause();

		//獲取數據
		var list1 = DOTween.PausedTweens();
		var list2 = DOTween.PlayingTweens();
		var list3 = DOTween.TweensById("ID");
		var list4 = DOTween.TweensByTarget(transform, true);
		var list5 = DOTween.IsTweening("ID");
		var list6 = DOTween.TotalPlayingTweens();

		//修改移動模式
		var tweener = transform.DOMove(Vector3.one * 2, 2);
		await Task.Delay(TimeSpan.FromSeconds(1));
		Debug.Log(tweener.fullPosition);
		await Task.Delay(TimeSpan.FromSeconds(0.5f));
		tweener.fullPosition = 0;

		var tweener1 = transform.DOMove(Vector3.one * 2, 1).SetLoops(3);
		await Task.Delay(TimeSpan.FromSeconds(1.1f));
		Debug.Log(tweener1.CompletedLoops());//1.1秒
		await Task.Delay(TimeSpan.FromSeconds(1.1f));
		Debug.Log(tweener1.CompletedLoops());//2.2秒
		await Task.Delay(TimeSpan.FromSeconds(1.1f));
		Debug.Log(tweener1.CompletedLoops());//3.3秒

		//獲取時間數據
		var tweener2 = transform.DOMove(Vector3.one * 2, 1).SetLoops(3);
		tweener2.Delay();//延遲
		tweener2.Duration();//持續時間
		tweener2.Elapsed();//已經播放的時間
		tweener2.ElapsedDirectionalPercentage();//過去方向百分比
		tweener2.ElapsedPercentage();//過去百分比


		//協程 指定循環次數
		_tweener = transform.DOMove(Vector3.one * 2, 1).SetLoops(3);
		StartCoroutine(Wait());
	}

	private IEnumerator Wait()
	{
		yield return _tweener.WaitForCompletion();//等待到完成調用
		yield return _tweener.WaitForKill();//等待刪除後調用
		yield return _tweener.WaitForPosition(2);//等待時間位置後調用
		yield return _tweener.WaitForRewind();//等待倒帶後調用
		yield return _tweener.WaitForStart();//先調用Start再調用Play
		yield return _tweener.WaitForElapsedLoops(2);//指定循環次數
		Debug.Log("循環兩次調用");
	}

	private float EaseFun(float time, float duration, float overshootOrAmplitude, float period)
	{
		//勻速運動
		return time / duration;
	}

	private void InsertCallBack()
	{
		Debug.Log("InsertCallBack");
	}
	private void AppendCallBack()
	{
		Debug.Log("AppendCallBack");
	}
}
