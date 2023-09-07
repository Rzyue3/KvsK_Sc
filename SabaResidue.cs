using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabaResidue : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject saba;
    [SerializeField]
    public BulletMove bulletMove;
    [SerializeField]
    private MeshCollider meshCollider;
    [SerializeField]
    private SabaDmy sabaDmy;
    [SerializeField]
    public Rigidbody rb;
    [SerializeField]
    public BoxCollider boxCollider;
    [SerializeField]
    private ParticleSystem hitEffect;
    public bool hitflag;
    public bool flag;
    public bool end;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            if(hitflag || !this.gameObject.activeSelf) return;
            StartCoroutine(fixedSaba(other.gameObject.tag));
        }
/*
        if(other.gameObject.CompareTag("Wall")||other.gameObject.CompareTag("Fishingman")||other.gameObject.CompareTag("Shoggoth")||other.gameObject.CompareTag("Offspring"))
        {
            if(hitflag || !this.gameObject.activeSelf) return;
            StartCoroutine(fixedSaba());
        }
*/
    }

    public void InitSet()
    {
        hitEffect.Stop();
        boxCollider.enabled = true;
        end = false;
        flag = false;
        hitflag = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        bulletMove.MoveFlag = true;
    }

    public IEnumerator fixedSaba(string str)
    {
        if(hitflag) yield break;
        //meshCollider.enabled = false;
        if(str == "Enemy")
            hitEffect.Play();
        hitflag = true;
        rb.useGravity = true;
        bulletMove.MoveFlag = false;
        Vector3 vec = new Vector3(-transform.forward.x,3f,-transform.forward.z);
        float forceMagnitude = 8f;
        Vector3 force = forceMagnitude * vec;
        rb.AddForce(force, ForceMode.Impulse);
        obj.transform.rotation = Quaternion.Euler(0f,Random.Range(0.0f,360.1f),Random.Range(0.0f,360.1f)) ;
        yield return new WaitForSeconds(0.15f);
        flag = true;
        rb.AddForce(new Vector3(0f,0f,0f), ForceMode.Impulse);
//        Debug.Log("Saba");
    }

    public void Gen()
    {
        Instantiate(saba,new Vector3(this.transform.position.x,this.transform.position.y + 0.25f,this.transform.position.z),this.transform.rotation);
    }

}
