[System.Serializable]
public struct ShapeInstance
{
    public Shape Shape { get; private set; }

    int instanceIdOrSaveIndex;

    public bool IsValid
    {
        get
        {
            return Shape && instanceIdOrSaveIndex == Shape.InstanceId;
        }
    }

    public ShapeInstance (Shape shape)
    {
        Shape = shape;
        instanceIdOrSaveIndex = shape.InstanceId;
    }

    public static implicit operator ShapeInstance (Shape shape)
    {
        return new ShapeInstance(shape);
    }

    public ShapeInstance (int saveIndex)
    {
        Shape = null;
        instanceIdOrSaveIndex = saveIndex;
    }

    public void Resolve ()
    {
        if (instanceIdOrSaveIndex >= 0)
        {
            Shape = Game.Instance.GetShape(instanceIdOrSaveIndex);
            instanceIdOrSaveIndex = Shape.InstanceId;
        }     
    }
}