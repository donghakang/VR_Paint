using UnityEngine;
using UnityEngine.UI;

public class RightController : MonoBehaviour
{
    // Determines which controller should be used for locomotion.
    public GameObject controller;

	// The maximum movement speed in meters per second.
    private float maxSpeed = 5.0f;
	
	// The deadzone is the area close to the center of the thumbstick.
    private float moveDeadzone = 0.2f;

    // Variable to keep track of view-directed or hand-directed.
    private bool isViewDirected = true;
    private bool aButtonClicked = false;

    // Variable to keep track of snap turn.
    private bool turnThresholdLeft = false;
    private bool turnThresholdRight = false;

    // Variable for drawing.
    public GameObject sphereObject;

    private GraphicLine currentLine;
    private Material material;
    private Material defaultMaterial;

    private float red = 255;
    private float green = 255;
    private float blue = 255;

    private float deadzone = 0.2f;
    private float maximumSize = 0.2f;
    private float minimumSize = 0.001f;

    private bool isEmissive = false;
    private float emissive_red = 0;
    private float emissive_green = 0;
    private float emissive_blue = 0;
    private Color emissive_color = new Color(0, 0, 0, 1);
    private Color emissive_default = Color.black;


    OVRCameraRig cameraRig = null;

    // Start is called before the first frame update.
    void Start()
    {
		// This script is meant to be used on the OVRCameraRig game object.
        cameraRig = GetComponent<OVRCameraRig>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Switch view-directed/hand-directed when A button is pressed.
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            aButtonClicked = true;
        }

        if (!OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) && aButtonClicked)
        {
            isViewDirected = !isViewDirected;
            aButtonClicked = false;
        }

        // Stores the x and y values of the thumbstick.
        Vector2 rightThumbstickVector = new Vector2();

        // Read the thumbstick values from either the right or left controller.
        rightThumbstickVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
            
		// If the thumbstick has been pushed outside the dead zone vertically.
        if (rightThumbstickVector.y > moveDeadzone || rightThumbstickVector.y < -moveDeadzone)
        {

            // View directed steering.
            if (isViewDirected)
            {
                // Calculate speed.
                float speed = maxSpeed * rightThumbstickVector.y * Time.deltaTime;
                Vector3 movement = new Vector3(0, 0, speed);

                // Multiply by movement vector by the head orientation.
                movement = cameraRig.centerEyeAnchor.rotation * movement;

                // Add movement vector to current position of game object.
                transform.localPosition += movement;
            }
            // Hand directed steering.
            else
            {
                // Calculate speed.
                float speed = maxSpeed * rightThumbstickVector.y * Time.deltaTime;
                Vector3 movement = new Vector3(0, 0, speed);

                // Multiply by movement vector by the hand orientation.
                movement = controller.transform.rotation * movement;

                // Add movement vector to current position of game object.
                transform.localPosition += movement;
            }
        }

        // Check for snap turn.
        if (rightThumbstickVector.x <= -0.75)
        {
            turnThresholdLeft = true;
            turnThresholdRight = false;
        }

        if (rightThumbstickVector.x >= 0.75)
        {
            turnThresholdLeft = false;
            turnThresholdRight = true;
        }

        if (rightThumbstickVector.x >= -moveDeadzone && turnThresholdLeft)
        {
            Vector3 leftTurn = new Vector3(0, -45, 0);
            transform.Rotate(leftTurn);
            turnThresholdLeft = false;
        }

        if (rightThumbstickVector.x <= moveDeadzone && turnThresholdRight)
        {
            Vector3 rightTurn = new Vector3(0, 45, 0);
            transform.Rotate(rightTurn);
            turnThresholdRight = false;
        }

        // Painting.

        // Have sphere follow hand.
        sphereObject.GetComponent<MeshRenderer>().material = material;
        sphereObject.transform.SetPositionAndRotation(controller.transform.position, controller.transform.rotation);
        sphereObject.transform.localScale = new Vector3(GraphicLine.lineSize, GraphicLine.lineSize, GraphicLine.lineSize);
        sphereObject.GetComponent<MeshRenderer>().material.color = new Color(red / 255f, green / 255f, blue / 255f);

        if (isEmissive)
        {
            emissive_color = new Color(red / 255f, green / 255f, blue / 255f, 1);
            sphereObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", emissive_color);
        } else
        {
            sphereObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", emissive_default);
        }
       

        // If the secondary index finger is pressed down.
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<MeshRenderer>();
            currentLine = gameObject.AddComponent<GraphicLine>();
            currentLine.material = material;
        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            currentLine.AddPoint(controller.transform.position);
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            currentLine = null;
        }

        // Set graphics line color.
        if (currentLine != null)
        {
            currentLine.GetComponent<MeshRenderer>().material.color = new Color(red / 255f, green / 255f, blue / 255f);

            if (isEmissive)
            {
                currentLine.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", emissive_color);
            } else
            {
                currentLine.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", emissive_default);
            }
        }
    }

    public void setRed(float red)
    {
        this.red = red;
    }

    public void setGreen(float green)
    {
        this.green = green;
    }

    public void setBlue(float blue)
    {
        this.blue = blue;
    }

    public void setEmissive(bool isEmissive)
    {
        this.isEmissive = isEmissive;
    }

    public void setEmissiveRed(float emissiveRed)
    {
        this.emissive_red = emissiveRed;
    }

    public void setEmissiveGreen(float emissiveGreen)
    {
        this.emissive_green = emissiveGreen;
    }

    public void setEmissiveBlue(float emissiveBlue)
    {
        this.emissive_blue = emissiveBlue;
    }

    public void setTexture(Material lineMaterial)
    {
        material = lineMaterial;
    }

    public void setSize(float size)
    {
        GraphicLine.lineSize = size;
    }

}
