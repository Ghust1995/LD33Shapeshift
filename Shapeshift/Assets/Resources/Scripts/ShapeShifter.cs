using UnityEngine;
using System.Collections;

public class ShapeShifter : MultiplayerBehaviour {

	float timeSinceLast = 0.0f;
	float cooldown = 1.0f;

    Material materialRock;
    Material materialPaper;
    Material materialScissors;

	void Start(){
		materialRock = Resources.Load<Material>("Materials/placeholderPaperMaterial");
		materialPaper = Resources.Load<Material>("Materials/placeholderRockMaterial");
		materialScissors = Resources.Load<Material>("Materials/placeholderScissorsMaterial");
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
			this.gameObject.GetComponent<MeshRenderer>().material = materialRock;
		if(element.Equals(ShapeType.rock))
			this.gameObject.GetComponent<MeshRenderer>().material = materialPaper;
		if(element.Equals(ShapeType.scissors))
			this.gameObject.GetComponent<MeshRenderer>().material = materialScissors;
	}

	void Update(){
		if(Input.GetButtonDown(AxisString("Shapeshift"))){
            //ShiftShape();
        }

        timeSinceLast += Time.deltaTime;
	}

    public void ShiftShape()
    {
        GetComponent<Animator>().SetTrigger("ChangeState");
        _currShape = GetNext(_currShape);
        //ChangeSprite(_currShape);
        timeSinceLast = 0;
    }
}
