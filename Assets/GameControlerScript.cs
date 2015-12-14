using UnityEngine;
using System.Collections;

public class GameControlerScript : MonoBehaviour {
	
	public GameObject cube;
	public GameObject[,] fieldCubes;
	public GameObject nextCubePrefab;
	public int x,y;

	int fieldWidth = 8;
	int fieldHeight = 5;
	int sameColorScore = 10;
	int multiColorScore = 5;
	int noKey = -1; //make sure to subtract the 1
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


	//Choose from array and set that color to "nextCubeColor"
	static Color[]ChooseColor = {
		Color.blue,
		Color.green,
		Color.red,
		Color.yellow,
		Color.magenta
	};


	int xMoveDir, yMoveDir;
	void SetMoveDirection (int x, int y) {
		xMoveDir = x;
		yMoveDir = y;
	}
	
	void MoveCube () {
		x += xMoveDir;
		y += yMoveDir;
		xMoveDir = 0;
		yMoveDir = 0;
	}

	void ProcessClickedCube (GameObject clickedCube, int x, int y) {
		print (x + ", " + y);

		if (isActive == false) {
			isActive = true;
			activeCubeColor = clickedCube.GetComponent<Renderer> ().material.color;
			//set that cube to center of grid and only allow to movement to squares around it
			//(x--,y--)(x,y--)(x++,y--)(x--,y)(x++,y)(x--,y++)(x,y++)(x++,y++)
			if (clickedCube (1 >= xMoveDir >= 0, 1>= yMoveDir >= 0)){
				//move in that direction
			}
			else {
			}
		}

		if (isActive == true) {
			isActive = false;
		}
	}


	void OnMouseDown (){
		ProcessClickedCube (this.gameObject, x, y);
	}

	bool IsSameColorPlus (int x, int y){
		//set myColor equal to the color of whatever the current fieldCube is
		Color myColor = fieldCubes [x, y].GetComponent<Renderer> ().material.color;

		if (myColor == Color.white || myColor == Color.black){
			return false;
		}

		/*if (){
		}*/
		return false;
	
	}

	int MyColorValue (Color myColor){

		//check what the color of that cube is and set it a number value for some sick math later
		if (myColor == Color.red){
			return 1;
		}
		if (myColor == Color.blue){
			return 10;
		}
		if (myColor == Color.yellow){
			return 100;
		}
		if (myColor == Color.green){
			return 1000;
		}
		if (myColor == Color.magenta){
			return 10000;
		}
		//screw every other color
		return 0;
	}

	bool IsMultiColorPlus (int x, int y){
		int myTotalColor = 0;
		//the total equals the current total plus this new color value at this location, then checking the values of cubes around it
		myTotalColor += MyColorValue (fieldCubes[x,y].GetComponent<Renderer>().material.color);
		myTotalColor += MyColorValue (fieldCubes[x++,y].GetComponent<Renderer>().material.color);
		myTotalColor += MyColorValue (fieldCubes[x--,y].GetComponent<Renderer>().material.color);
		myTotalColor += MyColorValue (fieldCubes[x,y++].GetComponent<Renderer>().material.color);
		myTotalColor += MyColorValue (fieldCubes[x,y--].GetComponent<Renderer>().material.color);

		if (myTotalColor == 11111){
			return true;
		}

		else {
			return false;
		}
	}



	void KeyPressed () {

		if (Input.GetKey(KeyCode.Keypad1)) {
			//choose random white cube in row 1 and change it to the color of the nextcube right now, destroy the next cube
			if (myColor == Color.white){
				fieldCubes [Random.Range(fieldWidth,1), 1].GetComponent<Renderer>().material.color = ChooseColor[nextCubeColor];
				Destroy (nextCubePrefab);
			}
			print ("Key pressed:" + 1);
		}
		else if (Input.GetKey(KeyCode.Keypad2)) {
			//choose random white cube in row 2 and change it to the color of the nextcube right now, destroy the next cube
			if (myColor == Color.white){
				fieldCubes [Random.Range(fieldWidth,2), 2].GetComponent<Renderer>().material.color = ChooseColor[nextCubeColor];
				Destroy (nextCubePrefab);
			}
			print ("Key pressed:" + 2);
		}
		else if (Input.GetKey(KeyCode.Keypad3)) {
			//choose random white cube in row 3 and change it to the color of the nextcube right now, destroy the next cube
			if (myColor == Color.white){
				fieldCubes [Random.Range(fieldWidth,3), 3].GetComponent<Renderer>().material.color = ChooseColor[nextCubeColor];
				Destroy (nextCubePrefab);
			//}
			print ("Key pressed:" + 3);
		}
		else if (Input.GetKey(KeyCode.Keypad4)) {
			//choose random white cube in row 4 and change it to the color of the nextcube right now, destroy the next cube
			if (myColor == Color.white){
				fieldCubes [Random.Range(fieldWidth,4), 4].GetComponent<Renderer>().material.color = ChooseColor[nextCubeColor];
				Destroy (nextCubePrefab);
			}
			print ("Key pressed:" + 4);
		}
		else if (Input.GetKey(KeyCode.Keypad5)) {
			//choose random white cube in row 5 and change it to the color of the nextcube right now, destroy the next cube
			if (myColor == Color.white){
				fieldCubes [Random.Range(fieldWidth,5), 5].GetComponent<Renderer>().material.color = ChooseColor[nextCubeColor];
				Destroy(nextCubePrefab);
			}
			print ("Key pressed:" + 5);
		}
		isKeyPressed = true;
		isNextCubeAvailable = false;
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
		//check if there are any scorable pluses
		IsSameColorPlus ();
		IsMultiColorPlus ();

		if (IsSameColorPlus == true){
			score += sameColorScore;
		}
		if (IsMultiColorPlus == true) {
			score += multiColorScore;
		}

		//ProcessClickedCube
		//make sure keys register
		KeyPressed ();

		if(Time.time >= turnStart){
		//instantiate that nextCube with the color changing
			//parenthesis game object makes new thing into an object
			GameObject nextCube = (GameObject)Instantiate (nextCubePrefab, new Vector3 (7, 10, 0), Quaternion.identity);
			nextCube.GetComponent<Renderer> ().material.color = ChooseColor[nextCubeColor];

			isNextCubeAvailable= true;
			isKeyPressed = false;

			/*if(isNextCubeAvailable == true && isKeyPressed == false){
				//call that key press and movement
				KeyPressed (x,y);
				//set new cube to next cube color 
					//if (iswhitecube == true &&)
				//disappear the current next cube until the next turn
				DestroyObject (nextCubePrefab);
				//set once white cube to not white anymore  isWhiteCube = false;
				isNextCubeAvailable = false;
				isKeyPressed = true;
				print ("Next cube has been used.");
			}*/

			//if after all this time at the end of the turn there is still no key pressed, turn a cube black
			if (Time.time > turnStart && isKeyPressed == false){
				fieldCubes[Random.Range(0,fieldWidth),Random.Range(0,fieldHeight)].GetComponent<Renderer>().material.color = Color.black;
				print ("Screw you I'm a black cube!");
			}

			else {
			}
				//Instantiate (fieldCubes, new Vector3 (Random.Range(0,fieldWidth), Random.Range(0,fieldHeight),0), Quaternion.identity);


				//set this cube to iswhitecube=false and isblackcube=true


			turnStart += turnLength;
			isKeyPressed = false;
			print ("End turn");
		}




		/*void OnMouseDown() 
			//- when clicked a cube activates
		*/
	}
}
