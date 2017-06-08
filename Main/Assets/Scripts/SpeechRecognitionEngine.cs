using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "grass", "rock", "wood", "zoom", "out", "more", "reload", "brick", "flip", "camera", "right", "left", "add", "start", "cube", "exit", "down", "slow", "normal", "speed", "stop", "up", "camera"};
    public ConfidenceLevel confidence = ConfidenceLevel.Low;


    protected PhraseRecognizer recognizer;
	protected string word;

	public GameObject theRockePrefabToSpawn;
	public GameObject theGrassPrefabToSpawn;
	public GameObject theWoodPrefabToSpawn;
	public GameObject theBrickPrefabToSpawn;
	public GameObject startCube;
	public Transform centrePoint;
	public float length;
	public Text youSaid;
	public AudioSource mainMusic;

	bool hasZoomed = false;
	bool spawn = true;

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();

			youSaid.GetComponent<Text> ();
        }

    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
    }

    private void Update()
    {
		youSaid.text = "You said: " + word;

		RaycastHit hitInfo;
		Ray rayforward = new Ray(transform.position, Vector3.forward);
		Ray rayback = new Ray(transform.position, Vector3.back);
		Ray rayleft = new Ray(transform.position, Vector3.left);
		Ray rayright = new Ray(transform.position, Vector3.right);
		Ray rayup = new Ray(transform.position, Vector3.up);
		Ray raydown = new Ray(transform.position, Vector3.down);

        switch (word)
        {
		case "grass":
			Debug.Log ("you said grass!");
			if (Physics.Raycast(rayforward, out hitInfo,0.1f) 
				|| Physics.Raycast(rayback, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayleft, out hitInfo, 0.1f)
				|| Physics.Raycast(rayright, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayup, out hitInfo, 0.1f) 
				|| Physics.Raycast(raydown, out hitInfo, 0.1f))
			{
				if (spawn == true)
				{
					Vector3 spawnspot = hitInfo.collider.transform.position + hitInfo.normal;
					Instantiate(theGrassPrefabToSpawn, spawnspot, Quaternion.identity);

					StartCoroutine(SpawnTimer());
					StartCoroutine (volumeIncrease ());

					spawn = false;
				}
			}
			break;

		case "rock":
			Debug.Log ("you said rock!");
			if (Physics.Raycast(rayforward, out hitInfo,0.1f) 
				|| Physics.Raycast(rayback, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayleft, out hitInfo, 0.1f)
				|| Physics.Raycast(rayright, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayup, out hitInfo, 0.1f) 
				|| Physics.Raycast(raydown, out hitInfo, 0.1f))
			{
				if (spawn == true)
				{
					Vector3 spawnspot = hitInfo.collider.transform.position + hitInfo.normal;
					Instantiate(theRockePrefabToSpawn, spawnspot, Quaternion.identity);

					StartCoroutine(SpawnTimer());
					StartCoroutine (volumeIncrease ());

					spawn = false;
				}
			}
			break;

		case "wood":
			Debug.Log ("you said wood!");
			if (Physics.Raycast(rayforward, out hitInfo,0.1f) 
				|| Physics.Raycast(rayback, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayleft, out hitInfo, 0.1f)
				|| Physics.Raycast(rayright, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayup, out hitInfo, 0.1f) 
				|| Physics.Raycast(raydown, out hitInfo, 0.1f))
			{
				if (spawn == true)
				{
					Vector3 spawnspot = hitInfo.collider.transform.position + hitInfo.normal;
					Instantiate(theWoodPrefabToSpawn, spawnspot, Quaternion.identity);

					StartCoroutine(SpawnTimer());
					StartCoroutine (volumeIncrease ());

					spawn = false;
				}
			}
			break;

		case "brick":
			Debug.Log ("you said brick!");
			if (Physics.Raycast(rayforward, out hitInfo,0.1f) 
				|| Physics.Raycast(rayback, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayleft, out hitInfo, 0.1f)
				|| Physics.Raycast(rayright, out hitInfo, 0.1f) 
				|| Physics.Raycast(rayup, out hitInfo, 0.1f) 
				|| Physics.Raycast(raydown, out hitInfo, 0.1f))
			{
				if (spawn == true)
				{
					Vector3 spawnspot = hitInfo.collider.transform.position + hitInfo.normal;
					Instantiate(theBrickPrefabToSpawn, spawnspot, Quaternion.identity);

					StartCoroutine(SpawnTimer());
					StartCoroutine (volumeIncrease ());

					spawn = false;
				}
			}
			break;

		case "zoom out":
			Debug.Log ("zooming...");
			Camera.main.fieldOfView =100;
			break;

		case "zoom out more":
			Debug.Log ("zooming...");
			Camera.main.fieldOfView = 130;
			break;

		case "reload":
			Debug.Log ("reloading...");
			SceneManager.LoadScene ("LeapDev");
			break;

		case "flip camera right":
			Debug.Log ("flipping...");
			var myCam = GameObject.Find ("Camera");
			var CamSpin = myCam.GetComponent<CameraSpin> ();
			CamSpin.flipSpin = false;
			break;

		case "blue":
			Debug.Log ("blue...");
			//Change cube colour to blue (gameobject.material)
			break;

		case "flip camera left":
			Debug.Log ("flipping...");
			var myCam1 = GameObject.Find ("Camera");
			var CamSpin1 = myCam1.GetComponent<CameraSpin> ();
			CamSpin1.flipSpin = true;
			break;

		case "add start cube":
			Debug.Log ("adding...");
			Instantiate (startCube, centrePoint.transform.position, Quaternion.identity);
			break;

		case "exit":
			Debug.Log ("exiting...");
			Application.Quit ();
			break;

		case "speed up":
			Debug.Log ("speeding up...");
			var SCam = GameObject.Find ("Camera");
			var CamSpeed = SCam.GetComponent<CameraSpin> ();
			CamSpeed.speed = 15;
			break;

		case "slow down":
			Debug.Log ("slowing down...");
			var speedCam = GameObject.Find ("Camera");
			var CamsSpeed = speedCam.GetComponent<CameraSpin> ();
			CamsSpeed.speed = 1;
			break;

		case "normal speed":
			Debug.Log ("normal speed...");
			var normalCam = GameObject.Find ("Camera");
			var normalSpeed = normalCam.GetComponent<CameraSpin> ();
			normalSpeed.speed = 5;
			break;
		case "stop":
			Debug.Log ("slowing down...");
			var stopCam = GameObject.Find ("Camera");
			var stopsSpeed = stopCam.GetComponent<CameraSpin> ();
			stopsSpeed.speed = 0;
			break;

		case "camera down":
			Debug.Log ("moving camera down...");
			Camera.main.transform.position = new Vector3 (-0.001410894f, 3.5f, 1.5f);
			break;

		case "camera up":
			Debug.Log ("moving camera up...");
			Camera.main.transform.position = new Vector3 (-0.001410894f, 7.1102255f, 1.904689f);
			break;

		}
			
    }
		

	IEnumerator SpawnTimer()
	{
		yield return new WaitForSeconds(1.2f);
		spawn = true;
	}

	IEnumerator Zoomer()
	{
		yield return new WaitForSeconds(1.2f);
		hasZoomed = false;
	}

	IEnumerator volumeIncrease()
	{
		mainMusic.volume = 0.33f;
		yield return new WaitForSeconds (0.8f);
		mainMusic.volume = 0.2f;
	}

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
