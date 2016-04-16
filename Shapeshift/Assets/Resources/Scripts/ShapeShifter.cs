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

	ShapeType _currShape = ShapeType.rock;

    public ShapeType CurrentShape
    {
        get
        {
            return _currShape;
        }
    }

	private ShapeType GetNext(ShapeType element){
		switch(element)
			{
				case ShapeType.paper:
					return ShapeType.scissors;
				case ShapeType.scissors:
					return ShapeType.rock;
				case ShapeType.rock:
					return ShapeType.paper;
			}
			return ShapeType.rock; //Se não receber um dos 3, o default é rock
	}


	private void ChangeSprite(ShapeType element){
		if(element.Equals(ShapeType.paper))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteRock;
		if(element.Equals(ShapeType.rock))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = spritePaper;
		if(element.Equals(ShapeType.scissors))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteScissors;
	}

	void Update(){
		if(timeSinceLast > cooldown && Input.GetButtonDown(AxisString("Shapeshift"))){
            //ShiftShape();
        }

		timeSinceLast+= Time.deltaTime;
	}

    public void ShiftShape()
    {
        _currShape = GetNext(_currShape);
        ChangeSprite(_currShape);
        timeSinceLast = 0;
    }
}
