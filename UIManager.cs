using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;  // インスタンス
    [SerializeField]
    private List<GameObject> hpImg = new List<GameObject>();    // HPイメージ
    [SerializeField]
    private TextMeshProUGUI sabaText;   // サバ残弾テキスト
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject kazikiObj;       // カジキの画像UI切り替え
    [SerializeField]
    private Slider sabaSlider;          // プレイヤー下の残弾ゲージ
    private bool kazikiFlag;            // スイッチ切り替え
    
    private int score;

    void Start()
    {
        kazikiFlag = true;              // 初期設定
        uiManager = this.gameObject.GetComponent<UIManager>();  // インスタンス格納
        sabaText.text = SabaStats.SabaNowBullet + "/" + SabaStats.SabaMaxBullet;    // 初期化
        sabaSlider.maxValue = SabaStats.SabaMaxBullet;  // 初期設定
        sabaSlider.value = SabaStats.SabaNowBullet;     // 初期化
    }

    // 弾関連更新
    public void BulletTextUpdate() 
    {
        // マガジン内 / 最大装填数
        // でテキスト更新
        sabaText.text = SabaStats.SabaNowBullet + "/" + SabaStats.SabaMaxBullet;
        // スライダーの値更新
        sabaSlider.value = SabaStats.SabaNowBullet;
    }

    // プレイヤーのHP更新
    public void PlayerHpUpdate()
    {
        // 減少処理の後に起動
        // HPIMGをActive(false)
        if(HpInvinciblyManager.PlayerHp <= -1) return;
        hpImg[HpInvinciblyManager.PlayerHp].SetActive(false);
    }

    // カジキ画像更新
    public void KazikiUpdate()
    {
        // kaziki残弾があるかどうか
        if(kazikiFlag)  // 発射
        {
            kazikiFlag = false;
            kazikiObj.SetActive(false);
        }
        else            
        {
            kazikiFlag = true;
            kazikiObj.SetActive(true);
        }
    }

    public void ScoreUpdate()
    {
        score++;
        scoreText.text = "Score:" + score;
    }
}