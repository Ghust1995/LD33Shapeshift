using UnityEngine;
using System.Collections;

public class ShapeShifter : MultiplayerBehaviour {


	float timeSinceLast = 0.0f;
	float cooldown = 1.0f;

	Sprite spriteRock;
	Sprite spritePaper;
	Sprite spriteScissors;

	void Start(){
		spriteRock = Resources.Load<Sprite>("Sprites/placeholderPaper");
		spritePaper = Resources.Load<Sprite>("Sprites/placeholderRock");
		spriteScissors = Resources.Load<Sprite>("Sprites/placeholderScissors");
	}

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
			this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteRock;
		if(element.Equals(element.rock))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = spritePaper;
		if(element.Equals(element.scissors))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteScissors;
	}

	void Update(){
		if(timeSinceLast > cooldown && Input.GetButtonDown(AxisString("Shapeshift"))){
			currElement = GetNext(currElement);
			ChangeSprite(currElement);
			timeSinceLast = 0;
		}

		timeSinceLast+= Time.deltaTime;
	}
}
