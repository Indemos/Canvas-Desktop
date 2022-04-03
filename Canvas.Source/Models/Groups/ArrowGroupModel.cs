using System.Collections.Generic;

namespace Canvas.Source.ModelSpace
{
  public class ArrowGroupModel : GroupModel, IGroupModel
  {
    /// <summary>
    /// Render the shape
    /// </summary>
    /// <param name="position"></param>
    /// <param name="name"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public override void CreateShape(int position, string name, IList<IGroupModel> items)
    {
      var currentModel = Composer.GetGroup(position, name, items);

      if (currentModel?.Point is null)
      {
        return;
      }

      var size = Panel.IndexSize / Composer.IndexCount / 3;

      var points = new PointModel[]
      {
        Composer.GetPixels(Panel, position, currentModel.Point),
        Composer.GetPixels(Panel, position, currentModel.Point),
        Composer.GetPixels(Panel, position, currentModel.Point)
      };

      points[0].Value -= size * currentModel.Direction;
      points[1].Index += size;
      points[2].Index -= size;

      Color = currentModel.Color ?? Color;

      Panel.CreateShape(points, this);
    }
  }
}
