using Canvas.Source.ControlSpace;

namespace Canvas.Source.ModelSpace
{
  public interface IPointModel
  {
    /// <summary>
    /// Index
    /// </summary>
    double? Index { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    dynamic Value { get; set; }

    /// <summary>
    /// Reference to composer
    /// </summary>
    Composer Composer { get; set; }

    /// <summary>
    /// Reference to panel
    /// </summary>
    ICanvasControl Panel { get; set; }
  }

  public class PointModel : IPointModel
  {
    /// <summary>
    /// Index
    /// </summary>
    public virtual double? Index { get; set; }

    /// <summary>
    /// Model that may contain arbitrary data needed to draw the shape
    /// </summary>
    public virtual dynamic Value { get; set; }

    /// <summary>
    /// Reference to composer
    /// </summary>
    public virtual Composer Composer { get; set; }

    /// <summary>
    /// Reference to panel
    /// </summary>
    public virtual ICanvasControl Panel { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public PointModel()
    {
    }
  }
}
