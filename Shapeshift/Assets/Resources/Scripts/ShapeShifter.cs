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

	private void ChangeSprite(element element){
		if(element.Equals(element.paper))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/placeholderPaper");
		if(element.Equals(element.rock))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/placeholderRock");
		if(element.Equals(element.scissors))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/placeholderScissors");
	}

	void Update(){
		if(Input.GetButtonDown(AxisString("Shapeshift"))){
			currElement = GetNext(currElement);
			ChangeSprite(currElement);
		}
	}
}
