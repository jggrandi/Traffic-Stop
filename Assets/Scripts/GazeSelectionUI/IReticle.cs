internal interface IReticle
{
    bool IsReadyToClick { get; set; }
    bool IsReticleHovering { get; set; }

    void Reset();
}