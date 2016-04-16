using UnityEngine;
using System.Collections;

public class ShapeShifter : MultiplayerBehaviour {

	[SerializeField]
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
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/placeholderPaper");
		if(element.Equals(ShapeType.rock))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/placeholderRock");
		if(element.Equals(ShapeType.scissors))
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/placeholderScissors");
	}

	void Update(){
		if(Input.GetButtonDown(AxisString("Shapeshift"))){
			_currShape = GetNext(_currShape);
			ChangeSprite(_currShape);
		}
	}
}
