using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100.0f;
    public float MaxHealth = 100.0f;
    public float SelfControl = 100.0f;
    public float LoseControlTime = 15.0f;
	public float Transformation;
	public float TransformationBack;
    public GameObject Hudba;
	public int NumOfScenes;
    public bool Enraged;
	
	public GameObject UserInterface;
    public GameObject endGamePopup;

	private Music hudba;
    private GameObject playerObject;
	private float LastHealth;
    private bool controlLost = false;
    private float transformationCooldown;
	private GameObject UI;


    void Start()
    {
		if (GameObject.FindGameObjectsWithTag ("GameController").Length > 1) {
			Destroy(gameObject);
			return;
		}
		UI = GameObject.FindGameObjectWithTag ("User Interface");
		if (UI == null && Application.loadedLevel != 0) {
			UI = Instantiate(UserInterface, Vector3.zero, Quaternion.identity) as GameObject;
		}
        hudba = (Instantiate(Hudba, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<Music>();
        DontDestroyOnLoad(gameObject);
    }

    public void RestartLevel()
    {
        UI = GameObject.FindGameObjectWithTag("User Interface");
        if (UI == null && Application.loadedLevel != 8)
        {
            UI = Instantiate(UserInterface, Vector3.zero, Quaternion.identity) as GameObject;
        }
        SelfControl = 100f;
        controlLost = false;
        Enraged = (LastHealth > -75f) ? false : true;
        Health = LastHealth;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadNextLevel()
    {
        controlLost = false;
        SelfControl = 100f;
        Enraged = (LastHealth > -75f) ? false : true;
        Health = LastHealth;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    void Update()
    {
		if (CrossPlatformInputManager.GetButtonDown("Restart")) {
            RestartLevel();
		}
		if (CrossPlatformInputManager.GetButtonDown("Cheat1") && Application.loadedLevel < NumOfScenes-1) {
            LoadNextLevel();
		}
		if (playerObject == null && Application.loadedLevel != 0)
		{
			UI = GameObject.FindGameObjectWithTag ("User Interface");
			if (UI == null) {
				UI = Instantiate(UserInterface, Vector3.zero, Quaternion.identity) as GameObject;
			}
            playerObject = GameObject.Find("CharacterHero");
			controlLost = false;
			SelfControl = 100.0f;
			LastHealth = Health;
			switch(Application.loadedLevel) {
			case 1:
				Health = 60.0f;
				MaxHealth = 60.0f;
				break;
			case 3:
			case 4:
				MaxHealth = 60.0f;
				break;
			case 2:
				Health = 0.0f;
				MaxHealth = 100.0f;
				SelfControl = 50.0f;
				break;
			default:
				MaxHealth = 100.0f;
				break;
			}
            TransformPlayer(Enraged);
        }

        if (Health < 0)
        {
            float percent = (-Health / MaxHealth);
            //Debug.Log(percent);
            LoseControl(percent * Time.deltaTime * 100f / LoseControlTime);
        }
        else
        {
            float percent = (Health / MaxHealth);
            //Debug.Log(percent);
            GainControl(percent * Time.deltaTime * 100f / LoseControlTime);
        }
    }

    public void DealDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Max(-MaxHealth, Health);
        if (Health < -(Transformation * MaxHealth) && !Enraged)
        {
            Enraged = true;
            TransformPlayer(Enraged);
        }
    }

    public void HealDamage(float heal)
    {
        Health += heal;
        Health = Mathf.Min(Health, MaxHealth);
        if (Health >= -(TransformationBack * MaxHealth) && Enraged)
        {
            Enraged = false;
            TransformPlayer(Enraged);
        }
    }

    /*public void AddMaxHealth(float hp)
    {
        MaxHealth += hp;
        Health += hp;
    }*/

    public void LoseControl(float control)
    {
        SelfControl -= control;
        if (SelfControl <= 0 && !controlLost)
        {
            // Game Over
            SelfControl = 0;
            HeroUserControl controller = playerObject.GetComponent<HeroUserControl>();
            controller.enabled = false;
            Instantiate(endGamePopup);
            controlLost = true;
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            GameObject.FindGameObjectWithTag("User Interface").SetActive(false);
            Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
            playerObject.GetComponent<HeroCharacter2D>().enabled = false;
            Destroy(rb);
            RunTheFuckAway runAway = GameObject.FindGameObjectWithTag("Player").AddComponent<RunTheFuckAway>();
            runAway.SetDirection(playerObject.transform.localScale.x);
        }
    }

    public void GainControl(float control)
    {
        SelfControl += control;
        SelfControl = Mathf.Clamp(SelfControl, 0f, 100f);
    }

    public void TransformPlayer(bool enraged)
    {
        if (enraged)
        {
			this.Enraged = true;
            playerObject.transform.Find("HumanHero").gameObject.SetActive(false);
            playerObject.transform.Find("MonsterHero").gameObject.SetActive(true);
			hudba.Human = false;
        }
        else
        {
			this.Enraged = false;
            playerObject.transform.Find("HumanHero").gameObject.SetActive(true);
            playerObject.transform.Find("MonsterHero").gameObject.SetActive(false);
			hudba.Human = true;
        }
    }
}
