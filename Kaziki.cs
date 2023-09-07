using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Kaziki : MonoBehaviour
{
    [SerializeField]
    private GameObject kazikiObj;
    [SerializeField]
    private GameObject player;


    private PlayerAnim anim;

    private bool IsNowThrowAnim = false;

    [SerializeField]
    [Header("カジキの発射タイミング")]
    private float throwTime;
    /*
        [SerializeField]
        private AlphaTestUI alphaTestUI;
    */

    // Start is called before the first frame update
    void Start()
    {
        if(anim == null)
        {
            anim = this.transform.root.GetComponent<PlayerAnim>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && KazikiStats.KazikiNowBullet == 1 && !PlayerController.DASH)
        {
            KazikiStats.KazikiNowBullet--;
            UIManager.uiManager.KazikiUpdate();
            anim.KazikiAnim();
        }
        else if(Input.GetMouseButtonDown(1) && KazikiStats.KazikiNowBullet == 0 && !PlayerController.DASH)
        {
            GameManager.GameManagerClass.soundManager.Play("KazikiNotShot");
        }
    }

    public void KazikiThrowAnim()
    {
        Instantiate(kazikiObj, new Vector3(player.transform.position.x,0f,player.transform.position.z), player.transform.rotation);
        GameManager.GameManagerClass.soundManager.Play("KazikiShot");
    }
}
