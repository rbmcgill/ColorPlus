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

	bool CheckForSamePlus (int x, int y){
		//set myColor equal to the color of whatever the current fieldCube is
		Color myColor = fieldCubes [x, y].GetComponent<Renderer> ().material.color;

		if (myColor == Color.white || myColor == Color.black){
			return false;
		}

		/*if (){
		}*/
		return false;
	
	}

	bool CheckForMultiPlus (Color myColor){
		//set myColor equal to the color of whatever the current fieldCube is
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




		if (myTotalColor == 11111){
			return true;
		}
		else {
			return false;
		}
	}



	void KeyPressed () {

		if (Input.GetKey(KeyCode.Keypad1)) {
			//choose random white cube in row 1 and chenge it to the color of the nextcube right now
			/*if (){
				fieldCubes [0, Random.Range(0,fieldWidth)].GetComponent<Renderer>().material.color = ChooseColor[nextCubeColor];
				//turn nextCube color gray
				Destroy (nextCubePrefab);
			}*/

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
			//parenthesis game object makes new thing into an object
			GameObject nextCube = (GameObject)Instantiate (nextCubePrefab, new Vector3 (7, 10, 0), Quaternion.identity);
			nextCube.GetComponent<Renderer> ().material.color = ChooseColor[nextCubeColor];
			isKeyPressed = false;

			if(isNextCubeAvailable == true && isKeyPressed == false){
				//call that key press and movement
				KeyPressed();
				//set new cube to next cube color 
					//if (iswhitecube == true &&)
				//disappear the current next cube until the next turn
				DestroyObject (nextCubePrefab);
				//set once white cube to not white anymore  isWhiteCube = false;
				isNextCubeAvailable = false;
			}
			//if after all this time at the end of the turn there is still no key pressed, turn a cube black
			else if (Time.time > turnStart && isKeyPressed == false){
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
