using UnityEngine;
using System.Collections;

public class GameControlerScript : MonoBehaviour {

	public GameObject cube;
	public GameObject[,] fieldCubes;
	public GameObject nextCubePrefab;
	public int x,y;

	int fieldWidth = 8;
	int fieldHeight = 5;
	int score = 0;
	int nextCubeColor;

	float turnLength = 2.0f;
	float totalGameTime = 60.0f;
	float turnStart;

	bool isActive; //is this cube active?
	bool isKeyPressed; //has a key been pressed during the turn? 
	bool isNextCubeAvailable; //is there are next cube in the next cube spot?
	bool iswhiteCube;
	bool isblackCube;

	static Color[]ChooseColor = {
		Color.blue,
		Color.green,
		Color.red,
		Color.yellow,
		Color.magenta
	};
	//Choose from array and set that color to "nextCubeColor"


	public void ProcessClickedCube (GameObject clickedCube, int x, int y) {
		print (x + ", " + y);
		clickedCube.GetComponent<Renderer> ().material.color = Color.gray;
		/*if (active == true) {
			//when click on (x--,y--)(x,y--)(x++,y--)(x--,y)(x++,y)(x--,y++)(x,y++)(x++,y++)
			//when clicked on x and y, set the active cube to inactive
		}
		if (active == false) {
		}*/
	}

	void OnMouseDown (){
		ProcessClickedCube (this.gameObject, x, y);
	}


	void KeyPressed () {

		if (Input.GetKey(KeyCode.Keypad1)) {
			//choose random white cube in row 1 and chenge it to the color of the nextcube right now
			if (fieldCubes[0,fieldHeight].GetComponent<Renderer>().material.color = Color.white){
				fieldCubes [0, Random.Range(0,fieldHeight)]().material.color = ChooseColor[nextCubeColor];
				//turn nextCube color gray
				nextCubePrefab.GetComponent<Renderer>().material.color = Color.gray;
			}

			print ("Key pressed:" + 1);
		}
		else if (Input.GetKey(KeyCode.Keypad2)) {
			//choose random column in row 2 
			// of the white cubes in the row (Random.Range(0, fieldwidth), 2, 0)
			//turn nextCube color white
			print ("Key pressed:" + 2);
		}
		else if (Input.GetKey(KeyCode.Keypad3)) {
			//choose random column in row 3 
			// of the white cubes in the row (Random.Range(0, fieldwidth), 3, 0)
			//turn nextCube color white
			print ("Key pressed:" + 3);
		}
		else if (Input.GetKey(KeyCode.Keypad4)) {
			//choose random column in row 4
			// of the white cubes in the row (Random.Range(0, fieldwidth), 4, 0)
			//turn nextCube color white
			print ("Key pressed:" + 4);
		}
		else if (Input.GetKey(KeyCode.Keypad5)) {
			//choose random column in row 5 
			// of the white cubes in the row (Random.Range(0, fieldwidth), 5, 0)
			//turn nextCube color white
			print ("Key pressed:" + 5);
		}
		isKeyPressed = true;
	}



	void CheckMultiColorPlus(int x, int y) {
		//check if x,y == one color from ChooseColor
		//then are (x,y++),(x--,y),(x++,y), and (x,y--) all of the other colors from the array with no overlapping
		//maybe make a checklist for it to go through and check if they all have different RBG numbers
	}
	void CheckSingleColorPlus(int x, int y) {
		//check if x,y == one color from ChooseColor
		//then are (x,y++),(x--,y),(x++,y), and (x,y--) the same color (check for the same RBG number)
	}

	public void RandomColumn (int x, int y, int fieldWidth){
	//search for what cubes are white like if material.color == white within that y
		//then, randomly between those cubes change the color to that of the nextCube (change in x)
	}






	// Use this for initialization
	void Start () {

		nextCubeColor = Random.Range (0, ChooseColor.Length);

		GameObject nextCube	= (GameObject)Instantiate (nextCubePrefab, new Vector3 (7, 10, 0), Quaternion.identity);
		nextCube.GetComponent<Renderer> ().material.color = ChooseColor[nextCubeColor];


		fieldCubes = new GameObject [fieldWidth,fieldHeight] ;
		//- Instantiates the white cubes in an 8x5 grid
		for(int x = 0; x < fieldWidth; x++) {
			for (int y = 0; y < fieldHeight; y++){
				fieldCubes[x,y] = (GameObject) Instantiate (cube, new Vector3 (x*2, y*2, 0), Quaternion.identity);
				fieldCubes[x,y].GetComponent<Renderer> ().material.color = Color.white;
			}		//color the material put on the cube because for some reason the cubes show up as black w/o it
		}
		//set all the cubes to iswhitecube=true and isblackcube=false
		print ("Field Spawned");

	}







	// Update is called once per frame
	void Update () {

		//ProcessClickedCube

		if(Time.time >= turnStart){
		//instantiate that nextCube with the color changing
			Instantiate (nextCubePrefab, new Vector3 (7, 10, 0), Quaternion.identity);
			nextCubePrefab.GetComponent<Renderer> ().material.color = ChooseColor[nextCubeColor];
			isKeyPressed = false;

			if(isNextCubeAvailable == true && isKeyPressed == false /* && KeyPressed() */){
				//call that key press and movement
				KeyPressed();
				//set new cube to next cube color 
					//if (iswhitecube == true &&)
				//disappear the current next cube until the next turn
				DestroyObject (nextCubePrefab);
				//set once white cube to not white anymore  isWhiteCube = false;
				isNextCubeAvailable = false;
			}
			else if(isNextCubeAvailable == false && isKeyPressed == true /* && KeyPressed() */) {
			}
			else {
				//Instantiate (fieldCubes, new Vector3 (Random.Range(0,fieldWidth), Random.Range(0,fieldHeight),0), Quaternion.identity);


				//set this cube to iswhitecube=false and isblackcube=true
			}

			turnStart += turnLength;
			print ("End turn");
		}




		/*void OnMouseDown() 
			//- when clicked a cube activates
		*/
	}
}
