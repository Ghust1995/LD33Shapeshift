using UnityEngine;
using System.Collections;

public class ShapeShifter : MultiplayerBehaviour {

	enum element{rock, paper, scissors};
	[SerializeField]
	element currElement = element.rock;

	private element GetNext(element element){
		switch(element)
			{
				case element.paper:
					return element.scissors;
				case element.scissors:
					return element.rock;
				case element.rock:
					return element.paper;
			}
			return element.rock; //Se não receber um dos 3, o default é rock
	}

	void Update(){
		if(Input.GetButton(PlayerID + "Shapeshift")){
			currElement = GetNext(currElement);
		}
	}
}
