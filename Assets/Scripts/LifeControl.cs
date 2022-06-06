using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeControl : MonoBehaviour {

    public Slider slider;
    public AudioClip crash;
    public Text HP;

    public float life = 210f;
    public GameObject self;
    public GameObject clear;
    public GameObject over;

    private Transform cam;
    private float shakeTime;
    private Rigidbody rb;
    private bool nocrash = false;

   void Start()
	{
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
        
        life -= Time.deltaTime;
        slider.value = life / 200;
        if (life < 0)
        {
            GameLogic.moving = false;
            rb.AddForce(new Vector3(0, -2000f, 0), ForceMode.Force);
            //실패 씬 이동
        }
        if(life<200) HP.text = (int)life + " / 200";
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Terrain")) //all collided objects needs to be set Terrain tag
        {
			if(!nocrash)
            {
                nocrash = true;
                life -= 10;
                OnShakeCamera();
                Camera.main.GetComponent<AudioSource>().PlayOneShot(crash, 0.7F);
            }

        }
        else if (other.collider.CompareTag("Road"))
        {
            GameLogic.moving = false;
            //성공 씬 이동
        }
    }

    public void OnShakeCamera(float t = 0.5f)
	{
        this.shakeTime = t;
        StopCoroutine("ShakeCamera");
        StartCoroutine("ShakeCamera");
	}

    private IEnumerator ShakeCamera()
	{
        cam = Camera.main.transform;
        Vector3 start = cam.eulerAngles;

		while (shakeTime > 0.0f)
		{
            float z = Random.Range(-1f, 1f);
            cam.rotation = Quaternion.Euler(start + new Vector3(0, 0, z) * 4);

            shakeTime -= Time.deltaTime;

            yield return null;
		}

        cam.rotation = Quaternion.Euler(start);
        nocrash = false;
	}



    /*
    public AudioClip Fall; //fall sound of eagle
    public ParticleSystem SplashEffect;
    public AudioClip WaterSplash;
    private int cap; 


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain")) //all collided objects needs to be set Terrain tag
        {
            Camera.main.GetComponent<GameLogic>().impacted = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Fall, 0.7F);
            StartCoroutine(Camera.main.GetComponent<GameLogic>().ResetByFall(0.2F,0));
        }
    }
     */
}
