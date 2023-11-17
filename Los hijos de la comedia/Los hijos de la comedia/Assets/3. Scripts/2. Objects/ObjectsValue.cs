
using UnityEngine;

[CreateAssetMenu(fileName = "New Objects Data", menuName = "Object Data")]
public class ObjectsValue : ScriptableObject
{
    [SerializeField] private string objectName;
    [SerializeField] private int objectWeightSpeed, objectWeightJump;
    [SerializeField] private int positionX, positionY, positionZ;

    public string ObjectName { get { return objectName; } }
    public int ObjectWeightSpeed { get { return objectWeightSpeed; } }
    public int ObjectWeightJump { get { return objectWeightJump; } }

    public int PositionX { get { return positionX; } }
    public int PositionY { get { return positionY; } }
    public int PositionZ { get { return positionZ; } }
}
